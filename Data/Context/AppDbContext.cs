using CidadaoConectado.API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CidadaoConectado.API.Data.Context;
public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Post> Posts { get; set; } = null!;
    public DbSet<Like> Likes { get; set; } = null!;
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
        optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
                    .HasMany(p => p.Posts)
                    .WithOne(u => u.User)
                    .HasForeignKey(u => u.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Post>()
                    .HasMany(l => l.Likes)
                    .WithOne(p => p.Post)
                    .HasForeignKey(p => p.PostId)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Seed();
        base.OnModelCreating(modelBuilder);
    }
}