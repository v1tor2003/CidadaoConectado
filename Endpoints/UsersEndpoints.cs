using CidadaoConectado.API.Data.Dtos.User;
using CidadaoConectado.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

public static class UsersEndpoints
{
    private const string RESOURCE = "users";
    public static void MapUsersEndpoints(this IEndpointRouteBuilder app, string apiVersion)
    {
        string url = string.Format("{0}/{1}", apiVersion, RESOURCE);

        app.MapGet(url, async ([FromServices] IUserService userService) => {
            var data = await userService.GetAllAsync<UserResponse>();
            if(!data.Any()) return Results.NotFound();

            return Results.Json(data);
        })
        .WithName("GetUsers")
        .WithOpenApi();

        app.MapPost(url, async (
            [FromServices] IUserService userService,
            [FromBody] UserRequest userRequest
        ) => {
            await userService.Register(userRequest);

            return Results.Created();
        })
        .WithName("RegisterPost")
        .WithOpenApi();
    }
}