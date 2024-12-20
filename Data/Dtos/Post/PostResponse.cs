using CidadaoConectado.API.Data.Dtos.Like;

namespace CidadaoConectado.API.Data.Dtos.Post;

public sealed record PostResponse
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Desc { get; set; } = string.Empty;
    public string Tags { get; set; } = string.Empty;
    public DateTime PubDate { get; set; }
    public string PostImage { get; set; } = string.Empty;
    public string UserId {get; set;} = string.Empty;
    public List<LikeResponse> Likes { get; set; } = [];
}