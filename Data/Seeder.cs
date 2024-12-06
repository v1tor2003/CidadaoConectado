using CidadaoConectado.API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CidadaoConectado.API.Data;

public static class Seeder
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        SeedUsers(modelBuilder);
        SeedPosts(modelBuilder);
        SeedLikes(modelBuilder);
    }

    private static void SeedUsers(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
                    .HasData(
                        new User { Id = "1", Email = "user1@example.com", Password = "password123" },
                        new User { Id = "2", Email = "user2@example.com", Password = "password456" },
                        new User { Id = "3", Email = "user3@example.com", Password = "password789" }
                    );
    }

    private static void SeedLikes(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Like>()
                    .HasData(
                        new Like { Id = 1, UserId = "2", PostId = 1 },
                        new Like { Id = 2, UserId = "3", PostId = 1 },
                        new Like { Id = 3, UserId = "1", PostId = 2 },
                        new Like { Id = 4, UserId = "3", PostId = 2 },
                        new Like { Id = 5, UserId = "1", PostId = 3 }
                    );
    }

    private static void SeedPosts(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>()
                    .HasData(
                        new Post 
                        { 
                            Id = 1, 
                            Title = "Orçamento Público 2024", 
                            Desc = "Detalhamento do orçamento público para o próximo ano, incluindo áreas prioritárias.", 
                            Tags = "Orçamento, Governo, Transparência", 
                            PubDate = DateTime.UtcNow.AddDays(-10), 
                            UserId = "1" 
                        },
                        new Post 
                        { 
                            Id = 2, 
                            Title = "Consulta Pública: Mobilidade Urbana", 
                            Desc = "Participe da consulta sobre melhorias no transporte público e infraestrutura urbana.", 
                            Tags = "Consulta Pública, Mobilidade Urbana, Participação", 
                            PubDate = DateTime.UtcNow.AddDays(-7), 
                            UserId = "2" 
                        },
                        new Post 
                        { 
                            Id = 3, 
                            Title = "Relatório de Desempenho Ambiental", 
                            Desc = "Veja os indicadores ambientais e as ações realizadas no último trimestre.", 
                            Tags = "Meio Ambiente, Relatório, Sustentabilidade", 
                            PubDate = DateTime.UtcNow.AddDays(-3), 
                            UserId = "3" 
                        }
                    );
    }
}