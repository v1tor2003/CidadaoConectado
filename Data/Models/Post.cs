using System.ComponentModel.DataAnnotations;

namespace CidadaoConectado.API.Data.Models;

public class Post
{
    public int Id { get; set; }
    [MaxLength(50)]
    public string Title { get; set; } = string.Empty;
    [DataType(DataType.Text)]
    public string Desc { get; set; } = string.Empty;
    public string Tags { get; set; } = string.Empty;
    public DateTime PubDate { get; set; } = DateTime.UtcNow;
    
    public required string UserId { get; set; }
    public virtual User User { get; set; } = null!;

    public virtual ICollection<Like> Likes { get; set; } = [];
}