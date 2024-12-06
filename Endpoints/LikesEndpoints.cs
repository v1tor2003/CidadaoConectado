using CidadaoConectado.API.Data.Dtos.Like;
using CidadaoConectado.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

public static class LikesEndpoints
{
    private const string RESOURCE = "likes";
    public static void MapLikesEndpoints(this IEndpointRouteBuilder app, string apiVersion)
    {
        string url = string.Format("{0}/{1}", apiVersion, RESOURCE);
        
        app.MapPost(url, async (
            [FromServices] IPostService postService,
            [FromServices] IUserService userService,
            [FromServices] ILikeService likeService,
            [FromBody] LikeRequest likeRequest
        ) => {
            var userId = likeRequest.UserId;
            var user = await userService.GetByIdAsync(userId);
            if(user is null) return Results.BadRequest($"user with given like.userId: {userId} does not exists");

            var postId = likeRequest.PostId;
            var post = await postService.GetByIdAsync(postId);
            if(post is null) return Results.BadRequest($"post with given like.postId: {postId} does not exists");

            await likeService.CreateAsync(likeRequest);

            return Results.Created();
        })
        .WithName("LikePost")
        .WithOpenApi();
    }
}