using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lrs.Migrations
{
    public partial class DlaTRZBD : Migration
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "839f14f6-643f-490f-ac01-380d1d158f76", "f85cc8c6-bde5-4a59-97c3-e8ba91a1a11d", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9449d4c7-af38-4b8b-a23b-42d90e47ceb2", "9b1828da-8a7d-498b-bbf4-d69a23c78e37", "Manager", "MANAGER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "839f14f6-643f-490f-ac01-380d1d158f76");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9449d4c7-af38-4b8b-a23b-42d90e47ceb2");

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
