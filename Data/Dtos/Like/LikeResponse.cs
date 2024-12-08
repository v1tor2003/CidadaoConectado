namespace CidadaoConectado.API.Data.Dtos.Like;

public sealed record LikeResponse
{
    public int LikeId { get; set; }
    public required string UserId { get; set; }
}