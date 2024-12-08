using CidadaoConectado.API;
using CidadaoConectado.API.Endpoints;
using CidadaoConectado.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;

builder.Services.ConfigureMapper();
builder.Services.ConfigureDatabase(configuration);
builder.Services.ConfigureRepositories();
builder.Services.ConfigureCrudServices();

builder.Services.ConfigureHttpClient(configuration);

builder.Services.AddCors(options => {
    options.AddPolicy("AllowAngularApp", policy => {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("AllowAngularApp");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlingMiddleware>();

const string API_VERSION = "/api/v1";

app.MapResignsEndpoints(API_VERSION);
app.MapAdmentsEndpoints(API_VERSION);
app.MapFamilyScholarshipsEndpoints(API_VERSION);
app.MapUsersEndpoints(API_VERSION);
app.MapPostsEndpoints(API_VERSION);

app.Run();

