using System.ComponentModel.DataAnnotations;

namespace CidadaoConectado.API.Data.Models;

public class User 
{
    public string Id { get; set; } = string.Empty;
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string AvatarPath { get; set; } = string.Empty;
    public virtual ICollection<Post> Posts { get; set; } = [];
}