namespace CidadaoConectado.API.Data.Dtos.User;

public sealed record UserResponse 
{
    public string Id { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}