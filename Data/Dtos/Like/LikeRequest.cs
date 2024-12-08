namespace CidadaoConectado.API.Data.Dtos.Like;

public sealed record LikeRequest
{
    public required string UserId { get; set; }
}