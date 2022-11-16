using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lrs.Migrations
{
    public partial class DatabaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0534923-d271-4df7-b038-5427439baa7b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dcdacf60-361d-4c4a-afa4-c2c88f338f26");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "87ad3079-4f1e-4604-ad14-fa8185a5e493", "2c92ba8b-c77b-45d3-b2a1-9725e5ef3280", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eeac7f53-ead8-4ab3-8177-985a7123b1cd", "60ac1589-d09b-45a3-9510-ebf11e33a7e1", "Manager", "MANAGER" });

            migrationBuilder.UpdateData(
                table: "Ticket",
                keyColumn: "TicketId",
                keyValue: new Guid("adcead95-068e-448a-b0e2-3f6a4c64a000"),
                column: "UserId",
                value: "6873c93f-310b-487a-acf4-3f6a4c64a000");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87ad3079-4f1e-4604-ad14-fa8185a5e493");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eeac7f53-ead8-4ab3-8177-985a7123b1cd");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Ticket");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b0534923-d271-4df7-b038-5427439baa7b", "28fd32cc-d352-4bec-ae7c-1f952bf7a7a2", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dcdacf60-361d-4c4a-afa4-c2c88f338f26", "d6b14aa0-4def-4037-8a55-26c9eafc9230", "Manager", "MANAGER" });
        }
    }
}
