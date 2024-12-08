using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CidadaoConectado.API.Migrations
{
    /// <inheritdoc />
    public partial class AddImageToTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.AddColumn<string>(
                name: "AvatarPath",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostImagePath",
                table: "Posts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarPath",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PostImagePath",
                table: "Posts");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { "1", "user1@example.com", "User Name1", "password123" },
                    { "2", "user2@example.com", "User Name2", "password456" },
                    { "3", "user3@example.com", "User Name3", "password789" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Desc", "PubDate", "Tags", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "Detalhamento do orçamento público para o próximo ano, incluindo áreas prioritárias.", new DateTime(2024, 11, 28, 13, 39, 6, 78, DateTimeKind.Utc).AddTicks(7609), "Orçamento, Governo, Transparência", "Orçamento Público 2024", "1" },
                    { 2, "Participe da consulta sobre melhorias no transporte público e infraestrutura urbana.", new DateTime(2024, 12, 1, 13, 39, 6, 78, DateTimeKind.Utc).AddTicks(8091), "Consulta Pública, Mobilidade Urbana, Participação", "Consulta Pública: Mobilidade Urbana", "2" },
                    { 3, "Veja os indicadores ambientais e as ações realizadas no último trimestre.", new DateTime(2024, 12, 5, 13, 39, 6, 78, DateTimeKind.Utc).AddTicks(8097), "Meio Ambiente, Relatório, Sustentabilidade", "Relatório de Desempenho Ambiental", "3" }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "PostId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "2" },
                    { 2, 1, "3" },
                    { 3, 2, "1" },
                    { 4, 2, "3" },
                    { 5, 3, "1" }
                });
        }
    }
}
