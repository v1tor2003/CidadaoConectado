using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CidadaoConectado.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password" },
                values: new object[,]
                {
                    { "1", "user1@example.com", "password123" },
                    { "2", "user2@example.com", "password456" },
                    { "3", "user3@example.com", "password789" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Desc", "PubDate", "Tags", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "Detalhamento do orçamento público para o próximo ano, incluindo áreas prioritárias.", new DateTime(2024, 11, 26, 18, 58, 7, 501, DateTimeKind.Utc).AddTicks(1343), "Orçamento, Governo, Transparência", "Orçamento Público 2024", "1" },
                    { 2, "Participe da consulta sobre melhorias no transporte público e infraestrutura urbana.", new DateTime(2024, 11, 29, 18, 58, 7, 501, DateTimeKind.Utc).AddTicks(1818), "Consulta Pública, Mobilidade Urbana, Participação", "Consulta Pública: Mobilidade Urbana", "2" },
                    { 3, "Veja os indicadores ambientais e as ações realizadas no último trimestre.", new DateTime(2024, 12, 3, 18, 58, 7, 501, DateTimeKind.Utc).AddTicks(1824), "Meio Ambiente, Relatório, Sustentabilidade", "Relatório de Desempenho Ambiental", "3" }
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
