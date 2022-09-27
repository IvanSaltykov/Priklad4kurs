using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lrs.Migrations
{
    public partial class UpdateDatabase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PartWorlds",
                newName: "PartWorldId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Hotels",
                newName: "HotelId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Countries",
                newName: "CountryId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cities",
                newName: "CityId");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Cities",
                newName: "CountrId");

            migrationBuilder.InsertData(
                table: "PartWorlds",
                columns: new[] { "PartWorldId", "Name" },
                values: new object[,]
                {
                    { new Guid("0bb98096-7c1c-4b0d-98e9-c35c71656a9c"), "Америка" },
                    { new Guid("318c9129-301d-4608-ba00-8b06c1cbb2bc"), "Австралия" },
                    { new Guid("b11e6aab-92dd-4a60-8719-7a964b4a7f25"), "Азия" },
                    { new Guid("d7d92ec3-7be7-4e53-862b-086f83640617"), "Европа" },
                    { new Guid("fb4bcfa9-4c0e-4fd2-aa88-a1dcce7233d8"), "Африка" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PartWorlds",
                keyColumn: "PartWorldId",
                keyValue: new Guid("0bb98096-7c1c-4b0d-98e9-c35c71656a9c"));

            migrationBuilder.DeleteData(
                table: "PartWorlds",
                keyColumn: "PartWorldId",
                keyValue: new Guid("318c9129-301d-4608-ba00-8b06c1cbb2bc"));

            migrationBuilder.DeleteData(
                table: "PartWorlds",
                keyColumn: "PartWorldId",
                keyValue: new Guid("b11e6aab-92dd-4a60-8719-7a964b4a7f25"));

            migrationBuilder.DeleteData(
                table: "PartWorlds",
                keyColumn: "PartWorldId",
                keyValue: new Guid("d7d92ec3-7be7-4e53-862b-086f83640617"));

            migrationBuilder.DeleteData(
                table: "PartWorlds",
                keyColumn: "PartWorldId",
                keyValue: new Guid("fb4bcfa9-4c0e-4fd2-aa88-a1dcce7233d8"));

            migrationBuilder.RenameColumn(
                name: "PartWorldId",
                table: "PartWorlds",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "HotelId",
                table: "Hotels",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Countries",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Cities",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CountrId",
                table: "Cities",
                newName: "CountryId");
        }
    }
}
