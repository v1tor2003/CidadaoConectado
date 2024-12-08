
namespace CidadaoConectado.API.Services;

public class ImageUploadService : IImageUploadService
{
    private readonly string[] _allowedExtensions = { ".jpg", ".jpeg", ".png" };
    private readonly string _uploadsDirectory;
    public ImageUploadService(string uploadsDirectory) => _uploadsDirectory = uploadsDirectory;
    public string CreateImageFilePath(IFormFile? file)
    {
        if(file is null) return string.Empty;
        var fileExtension = Path.GetExtension(file.FileName).ToLower();
        if(!_allowedExtensions.Contains(fileExtension)) return string.Empty;
 
        var fileName = Guid.NewGuid().ToString() + fileExtension;
        var filePath = Path.Combine(GetUploadsDirectory(), fileName);

        return filePath;
    }

    public string GetUploadsDirectory()
    {
        return _uploadsDirectory;
    }

    public async Task Save(IFormFile file, string filePath)
    {
        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }
    }
}