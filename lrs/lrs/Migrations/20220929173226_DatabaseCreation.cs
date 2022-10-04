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
                    PartWorldId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                    table.ForeignKey(
                        name: "FK_Countries_PartWorlds_PartWorldId",
                        column: x => x.PartWorldId,
                        principalTable: "PartWorlds",
                        principalColumn: "PartWorldId");
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId");
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    HotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.HotelId);
                    table.ForeignKey(
                        name: "FK_Hotels_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId");
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CountryId", "Name" },
                values: new object[] { new Guid("3a4156b4-6368-4808-8ca0-898edc8f4615"), null, "Анапа" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "Address", "Country", "Name" },
                values: new object[,]
                {
                    { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "312 Forest Avenue, BF 923", "USA", "Admin_Solutions Ltd" },
                    { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "583 Wall Dr. Gwynn Oak, MD 21207", "USA", "IT_Solutions Ltd" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "Name", "PartWorldId" },
                values: new object[,]
                {
                    { new Guid("0afb027f-c88f-4671-b8c1-0fc98dabc446"), "Португалия", null },
                    { new Guid("1fbd32e1-1d16-41f4-b5c0-59778602243a"), "Германия", null },
                    { new Guid("20aa4f75-ee9f-447d-80ef-c50cbec55bfd"), "Франция", null },
                    { new Guid("30ac4b5d-f73c-452b-93c3-0af8ba31129a"), "Россия", null },
                    { new Guid("3f559611-e30a-4927-83ac-2b4b55e35336"), "Чили", null },
                    { new Guid("3fdc31a1-7f45-4102-ba94-7f75c77264e9"), "Марокко", null },
                    { new Guid("4045fa2b-02c6-4add-9d56-8d0d17d870b5"), "Япония", null },
                    { new Guid("515ac902-4f8a-49e1-a2ad-7a76592c9786"), "Индия", null },
                    { new Guid("600d3f5a-415f-44ef-b123-a71df57fd299"), "США", null },
                    { new Guid("69b84acb-8159-4aef-a57d-d357f4d890dc"), "Бразилия", null },
                    { new Guid("8cb64f0c-8068-465f-9bdc-7b2ff2fdbc39"), "Грузия", null },
                    { new Guid("908e9dda-0daa-4668-acd4-350b4e273a1a"), "ЮАР", null },
                    { new Guid("965bdc2a-aea2-4170-9fd2-f70c1baedcbf"), "Италия", null },
                    { new Guid("c11e1c93-1f0c-4bad-8b10-eadae5db99a6"), "Англия", null },
                    { new Guid("dea5d47c-2c86-47b6-9c70-6d9e2a38b20d"), "Египет", null },
                    { new Guid("e2ee981b-13d8-4252-94e9-1038ac1f3bf0"), "Канада", null },
                    { new Guid("e9752849-1302-476f-89bb-63f76ed69b58"), "Армения", null },
                    { new Guid("ef581d2f-bc3e-4b3d-a0cd-03389b10aa80"), "Испания", null },
                    { new Guid("f44bfd5d-b398-4bf4-9df2-7dbb987435cb"), "Австралия", null },
                    { new Guid("f9ede011-01c7-4ee7-abd0-084e7762634d"), "Китай", null },
                    { new Guid("ff8372e8-ac6d-41b7-aab8-6de6e16e6c10"), "Тунис", null }
                });

            migrationBuilder.InsertData(
                table: "PartWorlds",
                columns: new[] { "PartWorldId", "Name" },
                values: new object[,]
                {
                    { new Guid("07900f58-5836-4765-a6ff-e3d6fc2d88b8"), "Австралия" },
                    { new Guid("1239cd80-60b0-41cb-a3a2-9e2cce94ce11"), "Азия" },
                    { new Guid("b111fac4-5b5c-40e2-a68d-53c2907e1d2e"), "Европа" },
                    { new Guid("dceb4d64-723e-4086-a95e-423421b30bfd"), "Африка" },
                    { new Guid("e21357cb-6126-4fee-9fb0-14c2020b14bb"), "Америка" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "CompanyId", "Name", "Position" },
                values: new object[] { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), 35, new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Kane Miller", "Administrator" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "CompanyId", "Name", "Position" },
                values: new object[] { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), 26, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Sam Raiden", "Software developer" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "CompanyId", "Name", "Position" },
                values: new object[] { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), 30, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Jana McLeaf", "Software developer" });

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
