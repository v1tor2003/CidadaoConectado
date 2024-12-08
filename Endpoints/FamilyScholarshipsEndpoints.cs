using CidadaoConectado.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

public static class FamilyScholarshipsEndpoints
{
    private const string RESOURCE = "family-scholarships";
    public static void MapFamilyScholarshipsEndpoints(this IEndpointRouteBuilder app, string apiVersion)
    {
        string url = string.Format("{0}/{1}", apiVersion, RESOURCE);

        app.MapGet(url + "/{ibgeCode}", async (
            [FromServices] IGovTransparencyApiService apiService,
            [FromServices] IDistributedCache cache,
            [FromRoute] string ibgeCode,
            [FromQuery] string? yearMonth
        ) => {
            var cached = await cache.GetStringAsync(url); // url is the cache key
            
            if (!string.IsNullOrEmpty(cached))
                return Results.Json(cached);

            var data = await apiService.GetFamilyScholarshipsAsync(yearMonth ?? DateTime.Now.ToString("yyyyMM"), ibgeCode);
            if(data is null) return Results.Problem("Internal Server Error while fetching data.");

            return Results.Json(apiService.MapFamilyScholarshipAsync(data));
        })
        .WithName("GetFamilyScholarship")
        .WithOpenApi();
    }
}
