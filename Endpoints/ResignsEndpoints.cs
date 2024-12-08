using System.Text.Json;
using CidadaoConectado.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

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
                return Results.Problem("Internal Error while fetching data.");

            return Results.Json(data);
        })
        .WithName("GetResignsValues")
        .WithOpenApi();

        app.MapGet(url + "/{id}", async (
            [FromServices] IDistributedCache cache,
            [FromRoute] int id
        ) => {
            var cachedCollection = await cache.GetStringAsync(url); // url is the cache key
            
            if (string.IsNullOrEmpty(cachedCollection))
                return Results.NotFound("No resigns available in the cache.");

            var jsonDocument = JsonDocument.Parse(cachedCollection);
            var rootElement = jsonDocument.RootElement;

            var resign = rootElement.EnumerateArray()
                                    .FirstOrDefault(e => e.GetProperty("id").GetInt32() == id);

            if(resign.ValueKind == JsonValueKind.Undefined)
                return Results.NotFound($"resign with ID {id} not found.");

            return Results.Json(resign);
        })
        .WithName("GetResignValue")
        .WithOpenApi();
    }
}
