using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lrs.Migrations
{
    public partial class DatabaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "PartWorlds",
                columns: table => new
                {
                    PartWorldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartWorlds", x => x.PartWorldId);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    World = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Country = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Hotel = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Week = table.Column<int>(type: "int", nullable: false),
                    User = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.TicketId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PartWorldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                    table.ForeignKey(
                        name: "FK_Countries_PartWorlds_PartWorldId",
                        column: x => x.PartWorldId,
                        principalTable: "PartWorlds",
                        principalColumn: "PartWorldId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    HotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.HotelId);
                    table.ForeignKey(
                        name: "FK_Hotels_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "Address", "Country", "Name" },
                values: new object[,]
                {
                    { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "312 Forest Avenue, BF 923", "USA", "Admin_Solutions Ltd" },
                    { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "583 Wall Dr. Gwynn Oak, MD 21207", "USA", "IT_Solutions Ltd" }
                });

            migrationBuilder.InsertData(
                table: "PartWorlds",
                columns: new[] { "PartWorldId", "Name" },
                values: new object[,]
                {
                    { new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47120"), "Европа" },
                    { new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47121"), "Азия" },
                    { new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47122"), "Африка" },
                    { new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47123"), "Австралия" },
                    { new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47124"), "Америка" }
                });

            migrationBuilder.InsertData(
                table: "Ticket",
                columns: new[] { "TicketId", "City", "Country", "Hotel", "Price", "User", "Week", "World" },
                values: new object[] { new Guid("adcead95-068e-448a-b0e2-3f6a4c64a000"), new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47002"), new Guid("d075f092-113c-487a-8d25-1da6f29de000"), new Guid("6873c93f-3d2b-4f14-92c6-7397d12a9000"), 10000, 1, 2, new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47120") });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "Name", "PartWorldId" },
                values: new object[,]
                {
                    { new Guid("d075f092-113c-487a-8d25-1da6f29de000"), "Россия", new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47120") },
                    { new Guid("d075f092-113c-487a-8d25-1da6f29de001"), "Китай", new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47121") },
                    { new Guid("d075f092-113c-487a-8d25-1da6f29de002"), "Индия", new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47121") },
                    { new Guid("d075f092-113c-487a-8d25-1da6f29de003"), "Италия", new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47120") },
                    { new Guid("d075f092-113c-487a-8d25-1da6f29de004"), "Испания", new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47120") },
                    { new Guid("d075f092-113c-487a-8d25-1da6f29de005"), "Канада", new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47124") },
                    { new Guid("d075f092-113c-487a-8d25-1da6f29de006"), "США", new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47124") },
                    { new Guid("d075f092-113c-487a-8d25-1da6f29de007"), "Бразилия", new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47124") },
                    { new Guid("d075f092-113c-487a-8d25-1da6f29de008"), "Австралия", new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47123") },
                    { new Guid("d075f092-113c-487a-8d25-1da6f29de009"), "Португалия", new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47120") },
                    { new Guid("d075f092-113c-487a-8d25-1da6f29de010"), "Грузия", new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47121") },
                    { new Guid("d075f092-113c-487a-8d25-1da6f29de011"), "Англия", new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47120") },
                    { new Guid("d075f092-113c-487a-8d25-1da6f29de012"), "Япония", new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47121") },
                    { new Guid("d075f092-113c-487a-8d25-1da6f29de013"), "Германия", new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47120") },
                    { new Guid("d075f092-113c-487a-8d25-1da6f29de014"), "Армения", new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47120") },
                    { new Guid("d075f092-113c-487a-8d25-1da6f29de015"), "Франция", new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47120") },
                    { new Guid("d075f092-113c-487a-8d25-1da6f29de016"), "Чили", new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47124") },
                    { new Guid("d075f092-113c-487a-8d25-1da6f29de017"), "Египет", new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47122") },
                    { new Guid("d075f092-113c-487a-8d25-1da6f29de018"), "Тунис", new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47122") },
                    { new Guid("d075f092-113c-487a-8d25-1da6f29de019"), "Марокко", new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47122") },
                    { new Guid("d075f092-113c-487a-8d25-1da6f29de020"), "ЮАР", new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47122") }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "CompanyId", "Name", "Position" },
                values: new object[,]
                {
                    { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), 35, new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Kane Miller", "Administrator" },
                    { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), 26, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Sam Raiden", "Software developer" },
                    { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), 30, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Jana McLeaf", "Software developer" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CountryId", "Name" },
                values: new object[] { new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47000"), new Guid("d075f092-113c-487a-8d25-1da6f29de000"), "Анапа" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CountryId", "Name" },
                values: new object[] { new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47001"), new Guid("d075f092-113c-487a-8d25-1da6f29de004"), "Мадрид" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CountryId", "Name" },
                values: new object[] { new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47002"), new Guid("d075f092-113c-487a-8d25-1da6f29de000"), "Саранск" });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "CityId", "Name" },
                values: new object[] { new Guid("6873c93f-3d2b-4f14-92c6-7397d12a9000"), new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47002"), "Саранск" });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_PartWorldId",
                table: "Countries",
                column: "PartWorldId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyId",
                table: "Employees",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_CityId",
                table: "Hotels",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "PartWorlds");
        }
    }
}
