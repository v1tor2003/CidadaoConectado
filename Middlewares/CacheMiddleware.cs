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
        var cacheKey = GenerateCacheKey(context);
        
        var cachedResponse = await _cache.GetStringAsync(cacheKey);
        if(!string.IsNullOrEmpty(cachedResponse))
        {
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(cachedResponse);
            return;
        }

        var originalBodyStream = context.Response.Body;
        using var memoryStream = new MemoryStream();
        context.Response.Body = memoryStream;

        await _next(context);

        if(context.Response.StatusCode == StatusCodes.Status200OK)
        {
            memoryStream.Seek(0, SeekOrigin.Begin);
            var responseBody = new StreamReader(memoryStream).ReadToEnd();
            memoryStream.Seek(0, SeekOrigin.Begin);

            await _cache.SetStringAsync(cacheKey, responseBody, new DistributedCacheEntryOptions {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(_configuration.GetValue<int>("CacheLifeTime"))
            });

            await memoryStream.CopyToAsync(originalBodyStream);
        }

        context.Response.Body = originalBodyStream;
    }

    private string GenerateCacheKey(HttpContext context)
    {
        var path = context.Request.Path.ToString();
        var query = context.Request.QueryString.ToString();
        return $"{path}{query}";
    }
}