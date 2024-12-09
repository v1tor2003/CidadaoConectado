using System.Text.RegularExpressions;
using Microsoft.Extensions.Caching.Distributed;

namespace CidadaoConectado.API.Middlewares;

public class CacheMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IDistributedCache _cache;
    private readonly IConfiguration _configuration;

    public CacheMiddleware(RequestDelegate next, IDistributedCache cache, IConfiguration configuration)
    {
        _next = next;
        _cache = cache;
        _configuration = configuration;
    }

    public async Task InvokeAsync(HttpContext context)
    {   
        if (!IsCacheableRoute(context))
        {
            await _next(context);
            return;
        }

        Console.WriteLine($"At cacheable route: {context.Request.Path}");
        var cacheKey = GenerateCacheKey(context);
        var cachedResponse = await _cache.GetStringAsync(cacheKey);

        if(!string.IsNullOrEmpty(cachedResponse))
        {
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(cachedResponse);
            return;
        }

        var originalBodyStream = context.Response.Body;

        try
        {
            using var memoryStream = new MemoryStream();
            context.Response.Body = memoryStream;

            await _next(context); 

            if (context.Response.StatusCode == StatusCodes.Status200OK)
            {
                memoryStream.Seek(0, SeekOrigin.Begin);
                var responseBody = await new StreamReader(memoryStream).ReadToEndAsync();

                await _cache.SetStringAsync(cacheKey, responseBody, new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(
                        _configuration.GetValue<int>("CacheLifeTime"))
                });

                memoryStream.Seek(0, SeekOrigin.Begin);
                await memoryStream.CopyToAsync(originalBodyStream);
            }
        }
        finally
        {
            context.Response.Body = originalBodyStream; 
        }
    }

    private string GenerateCacheKey(HttpContext context)
    {
        var path = context.Request.Path.ToString();
        var query = context.Request.QueryString.ToString();
        return $"{path}{query}";
    }

    private bool IsCacheableRoute(HttpContext context)
    {
        if(context.Request.Method != HttpMethod.Get.ToString()) return false;

        string[] cacheableRoutes = _configuration.GetSection("CacheableRoutes").Get<string[]>() ?? [];
        string requestPath = context.Request.Path.ToString();
         
        return cacheableRoutes.Any(route => requestPath.StartsWith(route, StringComparison.OrdinalIgnoreCase));
    }
}