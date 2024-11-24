using CidadaoConectado.API.Interfaces;
using CidadaoConectado.API.Middlewares;
using CidadaoConectado.API.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<IGovTransparencyApiService, GovTransparencyApiService>(client => 
{
    var configuration = builder.Configuration;
    var baseUrl = configuration["TransparencyApiSettings:BaseUrl"];
    var apiKeyName = configuration["TransparencyApiSettings:ApiKey:Name"];
    var apiKeyValue = configuration["TransparencyApiSettings:ApiKey:Value"];
    
    if(!IsApiCredentialsValid([baseUrl, apiKeyName, apiKeyValue]))
    {
        throw new InvalidOperationException("API credentials are not configured properly.");
    }

    client.BaseAddress = new Uri(baseUrl!);
    client.DefaultRequestHeaders.Add(apiKeyName!, apiKeyValue);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlingMiddleware>();

string apiVersion = "/api/v1";
app.MapGet($"{apiVersion}/resigns", async ([FromServices] IGovTransparencyApiService apiService) =>
{
    var data = await apiService.GetResignValuesAsync();

    if(data is null) 
        return Results.Problem("Error while fetching data from external API.");

    return Results.Json(data);
})
.WithName("GetResignsValues")
.WithOpenApi();

app.MapGet($"{apiVersion}/adments", async ([FromServices] IGovTransparencyApiService apiService) => {
    var data = await apiService.GetParliamentaryAmendmentAsync();
    
    if(data is null) 
        return Results.Problem("Error while fetching data from external API.");
    
    return Results.Json(data);
})
.WithName("GetParlamentaryAdments")
.WithOpenApi();

app.MapGet($"{apiVersion}/family-scholarships", 
    async (
        [FromQuery] string yearMonthDate, 
        [FromQuery] string cityIbgeCode, 
        [FromServices] IGovTransparencyApiService apiService
    ) => 
{
    var data = await apiService.GetFamilyScholarshipsAsync(yearMonthDate, cityIbgeCode);
    
    if(data is null) 
        return Results.Problem("Error while fetching data from external API.");
    
    return Results.Json(data);
})
.WithName("GetTest")
.WithOpenApi();

app.Run();

static bool IsApiCredentialsValid(string[] credentials)
{
    foreach(string credential in credentials)
        if(string.IsNullOrEmpty(credential))
            return false;

    return true;
}