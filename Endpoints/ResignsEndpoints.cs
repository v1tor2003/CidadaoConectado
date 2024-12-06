using CidadaoConectado.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CidadaoConectado.API.Endpoints;
public static class ResignsEndpoints
{
    private const string RESOURCE = "resigns";
    public static void MapResignsEndpoints(this IEndpointRouteBuilder app, string apiVersion)
    {
        string url = string.Format("{0}/{1}", apiVersion, RESOURCE);
        
        app.MapGet(url, async ([FromServices] IGovTransparencyApiService apiService) =>
        {
            var data = await apiService.GetResignValuesAsync();

            if (data is null)
                return Results.Problem("Error while fetching data from external API.");

            return Results.Json(data);
        })
        .WithName("GetResignsValues")
        .WithOpenApi();
    }
}
