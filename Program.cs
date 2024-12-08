using CidadaoConectado.API;
using CidadaoConectado.API.Endpoints;
using CidadaoConectado.API.Middlewares;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;

builder.Services.ConfigureMapper();
builder.Services.ConfigureCache(configuration);
builder.Services.ConfigureDatabase(configuration);
builder.Services.ConfigureRepositories();
builder.Services.ConfigureCrudServices();
builder.Services.ConfigureHttpClient(configuration);
builder.Services.ConfigureCors(configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAngularApp");
app.UseImageUploads();
// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseMiddleware<CacheMiddleware>();

const string API_VERSION = "/api/v1";

app.MapResignsEndpoints(API_VERSION);
app.MapAdmentsEndpoints(API_VERSION);
app.MapFamilyScholarshipsEndpoints(API_VERSION);
app.MapUsersEndpoints(API_VERSION);
app.MapPostsEndpoints(API_VERSION);

app.MapGet(API_VERSION+"/uploads/{fileName}", ([FromRoute] string fileName) => {
    var filePath = Path.Combine(AppExtensions.GetUploadsFolder(), fileName);
    
    if(File.Exists(filePath))
    {
        var fileBytes = File.ReadAllBytes(filePath);
        return Results.File(fileBytes, "image/jpeg");
    }

    return Results.NotFound();
});

app.Run();


