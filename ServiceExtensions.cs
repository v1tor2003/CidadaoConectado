using CidadaoConectado.API.Data.Context;
using CidadaoConectado.API.Data.Repositories;
using CidadaoConectado.API.Interfaces;
using CidadaoConectado.API.Services;
using Microsoft.EntityFrameworkCore;

namespace CidadaoConectado.API;

public static class ServiceExtensions
{
    public static void ConfigureHttpClient(
        this IServiceCollection services, 
        IConfiguration configuration
    )
    {
        services.AddHttpClient<IGovTransparencyApiService, GovTransparencyApiService>(client => {
            var baseUrl = configuration["TransparencyApiSettings:BaseUrl"];
            var apiKeyName = configuration["TransparencyApiSettings:ApiKey:Name"];
            var apiKeyValue = configuration["TransparencyApiSettings:ApiKey:Value"];
            
            if(!IsApiCredentialsValid(baseUrl, apiKeyName, apiKeyValue))
            {
                throw new InvalidOperationException("API credentials are not configured properly.");
            }

            client.BaseAddress = new Uri(baseUrl!);
            client.DefaultRequestHeaders.Add(apiKeyName!, apiKeyValue);
        });
    }

    public static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<ILikeRepository, LikeRepository>();

    }

    public static void ConfigureCrudServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IPostService, PostService>();
        services.AddScoped<ILikeService, LikeService>();
    }

    public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => {
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
        });
    }

    public static void ConfigureMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }

    private static bool IsApiCredentialsValid(string? baseUrl, string? apiKeyName, string? apiKeyValue)
    {
        return !string.IsNullOrEmpty(baseUrl) &&
               !string.IsNullOrEmpty(apiKeyName) &&
               !string.IsNullOrEmpty(apiKeyValue);
    }
}