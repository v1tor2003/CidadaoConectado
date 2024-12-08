using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CidadaoConectado.API.Migrations
{
    /// <inheritdoc />
    public partial class AddNameToUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "PubDate",
                value: new DateTime(2024, 11, 26, 18, 58, 7, 501, DateTimeKind.Utc).AddTicks(1343));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "PubDate",
                value: new DateTime(2024, 11, 29, 18, 58, 7, 501, DateTimeKind.Utc).AddTicks(1818));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "PubDate",
                value: new DateTime(2024, 12, 3, 18, 58, 7, 501, DateTimeKind.Utc).AddTicks(1824));
        }
    }
}
