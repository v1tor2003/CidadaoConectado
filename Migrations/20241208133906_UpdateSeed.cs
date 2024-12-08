using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CidadaoConectado.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "PubDate",
                value: new DateTime(2024, 11, 28, 13, 39, 6, 78, DateTimeKind.Utc).AddTicks(7609));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "PubDate",
                value: new DateTime(2024, 12, 1, 13, 39, 6, 78, DateTimeKind.Utc).AddTicks(8091));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "PubDate",
                value: new DateTime(2024, 12, 5, 13, 39, 6, 78, DateTimeKind.Utc).AddTicks(8097));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                column: "Name",
                value: "User Name1");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                column: "Name",
                value: "User Name2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3",
                column: "Name",
                value: "User Name3");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "PubDate",
                value: new DateTime(2024, 11, 28, 13, 37, 40, 466, DateTimeKind.Utc).AddTicks(3007));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "PubDate",
                value: new DateTime(2024, 12, 1, 13, 37, 40, 466, DateTimeKind.Utc).AddTicks(3497));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "PubDate",
                value: new DateTime(2024, 12, 5, 13, 37, 40, 466, DateTimeKind.Utc).AddTicks(3503));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                column: "Name",
                value: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                column: "Name",
                value: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3",
                column: "Name",
                value: "");
        }
    }
}
