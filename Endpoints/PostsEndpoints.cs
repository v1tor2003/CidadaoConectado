using CidadaoConectado.API.Data.Dtos.Post;
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

        app.MapPost(url, async (
            [FromServices] IPostService postService,
            [FromServices] IUserService userService,
            [FromBody] PostRequest postRequest
        ) => {
            var userId = postRequest.UserId;
            var user = await userService.GetByIdAsync(userId);
            if(user is null) return Results.BadRequest($"user with given id: {userId} does not exists");

            await postService.CreateAsync(postRequest);

            return Results.Created();
        })
        .WithName("CreatePost")
        .WithOpenApi();
    }
}