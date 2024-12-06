namespace CidadaoConectado.API.Data.Dtos.User;

public sealed record UserRequest
{
    public string Id { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}