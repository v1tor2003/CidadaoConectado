using CidadaoConectado.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

public static class FamilyScholarshipsEndpoints
{
    private const string RESOURCE = "family-scholarships";
    public static void MapFamilyScholarshipsEndpoints(this IEndpointRouteBuilder app, string apiVersion)
    {
        string url = string.Format("{0}/{1}", apiVersion, RESOURCE);
        app.MapGet(url, 
            async (
                [FromQuery] string yearMonthDate, 
                [FromQuery] string cityIbgeCode, 
                [FromServices] IGovTransparencyApiService apiService
            ) =>
        {
            var data = await apiService.GetFamilyScholarshipsAsync(yearMonthDate, cityIbgeCode);

            if (data is null)
                return Results.Problem("Error while fetching data from external API.");

            return Results.Json(data);
        })
        .WithName("GetTest")
        .WithOpenApi();
    }
}
