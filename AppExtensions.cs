using Microsoft.Extensions.FileProviders;

namespace CidadaoConectado.API;

public static class AppExtensions
{
    public static void UseImageUploads(this WebApplication app)
    {
        var uploads = GetUploadsFolder();
        
        if (!Directory.Exists(uploads))
        {
            Directory.CreateDirectory(uploads);
        }

        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(uploads),
            RequestPath = "/uploads"
        });
    }

    public static string GetUploadsFolder()
    {
        var dataPath = GetDataPath();
        return Path.Combine(dataPath, "Uploads");
    }

    private static string GetDataPath()
    {
        var projectPath = Directory.GetCurrentDirectory();
        return Path.Combine(projectPath, "Data");
    }
}