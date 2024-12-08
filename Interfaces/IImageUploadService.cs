namespace CidadaoConectado.API.Services;

public interface IImageUploadService
{
    Task Save(IFormFile file, string filePath);
    string GetUploadsDirectory(); 
    string CreateImageFilePath(IFormFile? file);
}