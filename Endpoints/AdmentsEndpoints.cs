using CidadaoConectado.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
                return Results.Problem("Error while fetching data from external API.");

            return Results.Json(data);
        })
        .WithName("GetParlamentaryAdments")
        .WithOpenApi();
    }
}
