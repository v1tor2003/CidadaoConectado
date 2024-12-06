namespace CidadaoConectado.API.Data.Dtos.Post;

public sealed record PostRequest
{
    public required string UserId { get; set; }
    public required string Title { get; set; }
    public string Desc { get; set; } = string.Empty;
    public string Tags { get; set; } = string.Empty;
}