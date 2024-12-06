namespace CidadaoConectado.API.Data.Dtos.Post;

public sealed record PostResponse
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Desc { get; set; } = string.Empty;
    public string Tags { get; set; } = string.Empty;
    public DateTime PubDate { get; set; }

    public int LikesCount { get; set; }
}