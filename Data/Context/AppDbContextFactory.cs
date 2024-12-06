using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CidadaoConectado.API.Data.Context;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var appSettingsFullPath = GetAppSettingsFullFilePath();

        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile(appSettingsFullPath, optional: false, reloadOnChange: true)
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        optionsBuilder.UseSqlite(connectionString);

        return new AppDbContext(optionsBuilder.Options);
    }

    private static string GetAppSettingsFullFilePath()
    {
        var currentDirectory = Directory.GetCurrentDirectory();

            // Traverse up until we find the appsettings.json or reach the system root
        while (currentDirectory != null && !File.Exists(Path.Combine(currentDirectory, "appsettings.json")))
        {
            var parentDirectory = Directory.GetParent(currentDirectory);
            if (parentDirectory is null) break; // Stop if we've reached the system root
            currentDirectory = parentDirectory.FullName;
        }

        if (currentDirectory is null)
            throw new InvalidOperationException("Could not locate the appsettings.json file within the project structure.");

        return Path.Combine(currentDirectory, "appsettings.json");
    }
}