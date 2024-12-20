﻿// <auto-generated />
using System;
using CidadaoConectado.API.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CidadaoConectado.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241208133742_AddNameToUserTable")]
    partial class AddNameToUserTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true);

            modelBuilder.Entity("CidadaoConectado.API.Data.Models.Like", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PostId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Likes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PostId = 1,
                            UserId = "2"
                        },
                        new
                        {
                            Id = 2,
                            PostId = 1,
                            UserId = "3"
                        },
                        new
                        {
                            Id = 3,
                            PostId = 2,
                            UserId = "1"
                        },
                        new
                        {
                            Id = 4,
                            PostId = 2,
                            UserId = "3"
                        },
                        new
                        {
                            Id = 5,
                            PostId = 3,
                            UserId = "1"
                        });
                });

            modelBuilder.Entity("CidadaoConectado.API.Data.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Desc")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PubDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Desc = "Detalhamento do orçamento público para o próximo ano, incluindo áreas prioritárias.",
                            PubDate = new DateTime(2024, 11, 28, 13, 37, 40, 466, DateTimeKind.Utc).AddTicks(3007),
                            Tags = "Orçamento, Governo, Transparência",
                            Title = "Orçamento Público 2024",
                            UserId = "1"
                        },
                        new
                        {
                            Id = 2,
                            Desc = "Participe da consulta sobre melhorias no transporte público e infraestrutura urbana.",
                            PubDate = new DateTime(2024, 12, 1, 13, 37, 40, 466, DateTimeKind.Utc).AddTicks(3497),
                            Tags = "Consulta Pública, Mobilidade Urbana, Participação",
                            Title = "Consulta Pública: Mobilidade Urbana",
                            UserId = "2"
                        },
                        new
                        {
                            Id = 3,
                            Desc = "Veja os indicadores ambientais e as ações realizadas no último trimestre.",
                            PubDate = new DateTime(2024, 12, 5, 13, 37, 40, 466, DateTimeKind.Utc).AddTicks(3503),
                            Tags = "Meio Ambiente, Relatório, Sustentabilidade",
                            Title = "Relatório de Desempenho Ambiental",
                            UserId = "3"
                        });
                });

            modelBuilder.Entity("CidadaoConectado.API.Data.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Email = "user1@example.com",
                            Name = "",
                            Password = "password123"
                        },
                        new
                        {
                            Id = "2",
                            Email = "user2@example.com",
                            Name = "",
                            Password = "password456"
                        },
                        new
                        {
                            Id = "3",
                            Email = "user3@example.com",
                            Name = "",
                            Password = "password789"
                        });
                });

            modelBuilder.Entity("CidadaoConectado.API.Data.Models.Like", b =>
                {
                    b.HasOne("CidadaoConectado.API.Data.Models.Post", "Post")
                        .WithMany("Likes")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CidadaoConectado.API.Data.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CidadaoConectado.API.Data.Models.Post", b =>
                {
                    b.HasOne("CidadaoConectado.API.Data.Models.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CidadaoConectado.API.Data.Models.Post", b =>
                {
                    b.Navigation("Likes");
                });

            modelBuilder.Entity("CidadaoConectado.API.Data.Models.User", b =>
                {
                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
