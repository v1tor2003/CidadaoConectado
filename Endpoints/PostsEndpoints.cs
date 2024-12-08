using CidadaoConectado.API.Data.Dtos.Like;
using CidadaoConectado.API.Data.Dtos.Post;
using CidadaoConectado.API.Data.Models;
using CidadaoConectado.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CidadaoConectado.API.Endpoints;
public static class PostsEndpoints
{
    private const string RESOURCE = "posts";
    public static void MapPostsEndpoints(this IEndpointRouteBuilder app, string apiVersion)
    {
        string url = string.Format("{0}/{1}", apiVersion, RESOURCE);

        app.MapGet(url, async ([FromServices] IPostService postService) => {
            var posts = await postService.GetAllAsync<PostResponse>();
            if(!posts.Any()) return Results.NotFound();

            return Results.Ok(posts);
        })
        .WithName("GetPosts")
        .WithOpenApi();

        app.MapGet(url + "/{postId}", async (
            [FromServices] IPostService postService,
            [FromRoute] int postId
        ) => {
            var post = await postService.GetByIdAsync<PostResponse>(postId);
            if(post is null) return Results.NotFound();

            return Results.Ok(post);
        })
        .WithName("GetPost")
        .WithOpenApi();

        app.MapPost(url, async (
            [FromServices] IPostService postService,
            [FromServices] IUserService userService,
            [FromBody] PostRequest postRequest
        ) => {
            var userId = postRequest.UserId;
            var user = await userService.GetByIdAsync(userId);
            if(user is null) return BadRequestForResource("user", userId.ToString());

            await postService.CreateAsync(postRequest);

            return Results.Created();
        })
        .WithName("CreatePost")
        .WithOpenApi();

        app.MapPatch(url + "/{postId}/likes", async (
            [FromServices] IPostService postService,
            [FromBody] LikeRequest likeRequest,
            [FromRoute] int postId
        ) => {
            var post = await postService.GetByIdAsync(postId);
            if(post is null) return BadRequestForResource("post", postId.ToString());
        
            if(post.Likes.Any(l => l.UserId == likeRequest.UserId)) return Results.NoContent();
           
            post.Likes.Add(new Like { PostId = postId, UserId = likeRequest.UserId });
            await postService.UpdateAsync(post);
            
            return Results.NoContent();
        })
        .WithName("LikePost")
        .WithOpenApi();

        app.MapDelete(url + "/{postId}/likes/{likeId}", async (
            [FromServices] IPostService postService,
            [FromRoute] int postId,
            [FromRoute] int likeId
        ) => {
            var post = await postService.GetByIdAsync(postId);
            if(post is null) return BadRequestForResource("post", postId.ToString());

            var likeToRemove = post.Likes.FirstOrDefault(l => l.Id == likeId);
            if(likeToRemove is null) return BadRequestForResource("like", likeId.ToString()); 
            
            post.Likes.Remove(likeToRemove);
            await postService.UpdateAsync(post);

            return Results.NoContent();
        })
        .WithName("UnlikePost")
        .WithOpenApi();
    }

    private static IResult BadRequestForResource(string resourceName, string id)
    {
        return Results.BadRequest($"{resourceName} with given id: {id} does not exists");
    }
}