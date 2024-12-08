using System.Text.Json;
using CidadaoConectado.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

public static class AdmentsEndpoints
{
    private const string RESOURCE = "adments";    
    public static void MapAdmentsEndpoints(this IEndpointRouteBuilder app, string apiVersion)
    {
        string url = string.Format("{0}/{1}", apiVersion, RESOURCE);
        
        app.MapGet(url, async ([FromServices] IGovTransparencyApiService apiService) =>
        {
            var data = await apiService.GetParliamentaryAmendmentAsync();

            if (data is null)
                return Results.Problem("Internal Error while fetching data.");

            return Results.Json(data);
        })
        .WithName("GetParlamentaryAdments")
        .WithOpenApi();

        app.MapGet(url + "/{id}", async (
            [FromServices] IDistributedCache cache,
            [FromRoute] int id
        ) => {
            var cachedCollection = await cache.GetStringAsync(url); // url is the cache key
            
            if (string.IsNullOrEmpty(cachedCollection))
                return Results.NotFound("No amendments available in the cache.");

            var jsonDocument = JsonDocument.Parse(cachedCollection);
            var rootElement = jsonDocument.RootElement;

            var adment = rootElement.EnumerateArray()
                                    .FirstOrDefault(e => e.GetProperty("id").GetInt32() == id);

            if(adment.ValueKind == JsonValueKind.Undefined)
                return Results.NotFound($"Adment with ID {id} not found.");

            return Results.Json(adment);
        })
        .WithName("GetParlamentaryAdment")
        .WithOpenApi();
    }
}
