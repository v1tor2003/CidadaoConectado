namespace CidadaoConectado.API.Data.Dtos.Like;

public sealed record LikeRequest
{
    public int PostId { get; set; } 
    public string UserId { get; set; } = string.Empty;
}