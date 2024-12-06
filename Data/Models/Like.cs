namespace CidadaoConectado.API.Data.Models;

public class Like 
{
    public int Id { get; set; }
    public required string UserId { get; set; }
    public virtual User User { get; set; } = null!;
    public required int PostId { get;set; }
    public virtual Post Post { get; set; } = null!;
}