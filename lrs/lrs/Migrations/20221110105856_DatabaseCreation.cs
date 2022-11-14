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
                keyValue: "839f14f6-643f-490f-ac01-380d1d158f76");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9449d4c7-af38-4b8b-a23b-42d90e47ceb2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c2439a11-1354-4282-99b4-c1fbaffbe95f", "af5fbd62-2905-4bd6-b00c-c9fbb1dff852", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "efc59b80-6e81-452f-acfe-704677cb2dea", "4d4d7305-ca41-4b25-b7d0-284fb1ec13b5", "Manager", "MANAGER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2439a11-1354-4282-99b4-c1fbaffbe95f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "efc59b80-6e81-452f-acfe-704677cb2dea");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "839f14f6-643f-490f-ac01-380d1d158f76", "f85cc8c6-bde5-4a59-97c3-e8ba91a1a11d", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9449d4c7-af38-4b8b-a23b-42d90e47ceb2", "9b1828da-8a7d-498b-bbf4-d69a23c78e37", "Manager", "MANAGER" });
        }
    }
}
