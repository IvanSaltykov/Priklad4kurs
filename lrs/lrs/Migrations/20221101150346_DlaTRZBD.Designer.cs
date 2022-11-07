﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace lrs.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20221101150346_DlaTRZBD")]
    partial class DlaTRZBD
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Models.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CityId");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47000"),
                            CountryId = new Guid("d075f092-113c-487a-8d25-1da6f29de000"),
                            Name = "Анапа"
                        },
                        new
                        {
                            Id = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47001"),
                            CountryId = new Guid("d075f092-113c-487a-8d25-1da6f29de004"),
                            Name = "Мадрид"
                        },
                        new
                        {
                            Id = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47002"),
                            CountryId = new Guid("d075f092-113c-487a-8d25-1da6f29de000"),
                            Name = "Саранск"
                        });
                });

            modelBuilder.Entity("Entities.Models.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CompanyId");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                            Address = "583 Wall Dr. Gwynn Oak, MD 21207",
                            Country = "USA",
                            Name = "IT_Solutions Ltd"
                        },
                        new
                        {
                            Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                            Address = "312 Forest Avenue, BF 923",
                            Country = "USA",
                            Name = "Admin_Solutions Ltd"
                        });
                });

            modelBuilder.Entity("Entities.Models.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CountryId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<Guid>("PartWorldId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PartWorldId");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d075f092-113c-487a-8d25-1da6f29de000"),
                            Name = "Россия",
                            PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47120")
                        },
                        new
                        {
                            Id = new Guid("d075f092-113c-487a-8d25-1da6f29de001"),
                            Name = "Китай",
                            PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47121")
                        },
                        new
                        {
                            Id = new Guid("d075f092-113c-487a-8d25-1da6f29de002"),
                            Name = "Индия",
                            PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47121")
                        },
                        new
                        {
                            Id = new Guid("d075f092-113c-487a-8d25-1da6f29de003"),
                            Name = "Италия",
                            PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47120")
                        },
                        new
                        {
                            Id = new Guid("d075f092-113c-487a-8d25-1da6f29de004"),
                            Name = "Испания",
                            PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47120")
                        },
                        new
                        {
                            Id = new Guid("d075f092-113c-487a-8d25-1da6f29de005"),
                            Name = "Канада",
                            PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47124")
                        },
                        new
                        {
                            Id = new Guid("d075f092-113c-487a-8d25-1da6f29de006"),
                            Name = "США",
                            PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47124")
                        },
                        new
                        {
                            Id = new Guid("d075f092-113c-487a-8d25-1da6f29de007"),
                            Name = "Бразилия",
                            PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47124")
                        },
                        new
                        {
                            Id = new Guid("d075f092-113c-487a-8d25-1da6f29de008"),
                            Name = "Австралия",
                            PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47123")
                        },
                        new
                        {
                            Id = new Guid("d075f092-113c-487a-8d25-1da6f29de009"),
                            Name = "Португалия",
                            PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47120")
                        },
                        new
                        {
                            Id = new Guid("d075f092-113c-487a-8d25-1da6f29de010"),
                            Name = "Грузия",
                            PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47121")
                        },
                        new
                        {
                            Id = new Guid("d075f092-113c-487a-8d25-1da6f29de011"),
                            Name = "Англия",
                            PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47120")
                        },
                        new
                        {
                            Id = new Guid("d075f092-113c-487a-8d25-1da6f29de012"),
                            Name = "Япония",
                            PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47121")
                        },
                        new
                        {
                            Id = new Guid("d075f092-113c-487a-8d25-1da6f29de013"),
                            Name = "Германия",
                            PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47120")
                        },
                        new
                        {
                            Id = new Guid("d075f092-113c-487a-8d25-1da6f29de014"),
                            Name = "Армения",
                            PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47120")
                        },
                        new
                        {
                            Id = new Guid("d075f092-113c-487a-8d25-1da6f29de015"),
                            Name = "Франция",
                            PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47120")
                        },
                        new
                        {
                            Id = new Guid("d075f092-113c-487a-8d25-1da6f29de016"),
                            Name = "Чили",
                            PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47124")
                        },
                        new
                        {
                            Id = new Guid("d075f092-113c-487a-8d25-1da6f29de017"),
                            Name = "Египет",
                            PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47122")
                        },
                        new
                        {
                            Id = new Guid("d075f092-113c-487a-8d25-1da6f29de018"),
                            Name = "Тунис",
                            PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47122")
                        },
                        new
                        {
                            Id = new Guid("d075f092-113c-487a-8d25-1da6f29de019"),
                            Name = "Марокко",
                            PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47122")
                        },
                        new
                        {
                            Id = new Guid("d075f092-113c-487a-8d25-1da6f29de020"),
                            Name = "ЮАР",
                            PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47122")
                        });
                });

            modelBuilder.Entity("Entities.Models.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("EmployeeId");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                            Age = 26,
                            CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                            Name = "Sam Raiden",
                            Position = "Software developer"
                        },
                        new
                        {
                            Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                            Age = 30,
                            CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                            Name = "Jana McLeaf",
                            Position = "Software developer"
                        },
                        new
                        {
                            Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                            Age = 35,
                            CompanyId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                            Name = "Kane Miller",
                            Position = "Administrator"
                        });
                });

            modelBuilder.Entity("Entities.Models.Hotel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("HotelId");

                    b.Property<Guid>("CityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6873c93f-3d2b-4f14-92c6-7397d12a9000"),
                            CityId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47002"),
                            Name = "Саранск"
                        });
                });

            modelBuilder.Entity("Entities.Models.PartWorld", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("PartWorldId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("PartWorlds");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47120"),
                            Name = "Европа"
                        },
                        new
                        {
                            Id = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47121"),
                            Name = "Азия"
                        },
                        new
                        {
                            Id = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47122"),
                            Name = "Африка"
                        },
                        new
                        {
                            Id = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47123"),
                            Name = "Австралия"
                        },
                        new
                        {
                            Id = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47124"),
                            Name = "Америка"
                        });
                });

            modelBuilder.Entity("Entities.Models.Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("TicketId");

                    b.Property<Guid>("City")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Country")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Hotel")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("User")
                        .HasColumnType("int");

                    b.Property<int>("Week")
                        .HasColumnType("int");

                    b.Property<Guid>("World")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Ticket");

                    b.HasData(
                        new
                        {
                            Id = new Guid("adcead95-068e-448a-b0e2-3f6a4c64a000"),
                            City = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47002"),
                            Country = new Guid("d075f092-113c-487a-8d25-1da6f29de000"),
                            Hotel = new Guid("6873c93f-3d2b-4f14-92c6-7397d12a9000"),
                            Price = 10000,
                            User = 1,
                            Week = 2,
                            World = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47120")
                        });
                });

            modelBuilder.Entity("Entities.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "9449d4c7-af38-4b8b-a23b-42d90e47ceb2",
                            ConcurrencyStamp = "9b1828da-8a7d-498b-bbf4-d69a23c78e37",
                            Name = "Manager",
                            NormalizedName = "MANAGER"
                        },
                        new
                        {
                            Id = "839f14f6-643f-490f-ac01-380d1d158f76",
                            ConcurrencyStamp = "f85cc8c6-bde5-4a59-97c3-e8ba91a1a11d",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Entities.Models.City", b =>
                {
                    b.HasOne("Entities.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Entities.Models.Country", b =>
                {
                    b.HasOne("Entities.Models.PartWorld", "PartWorld")
                        .WithMany("Countries")
                        .HasForeignKey("PartWorldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PartWorld");
                });

            modelBuilder.Entity("Entities.Models.Employee", b =>
                {
                    b.HasOne("Entities.Models.Company", "Company")
                        .WithMany("Employees")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Entities.Models.Hotel", b =>
                {
                    b.HasOne("Entities.Models.City", "City")
                        .WithMany("Hotels")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Entities.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Entities.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Entities.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Models.City", b =>
                {
                    b.Navigation("Hotels");
                });

            modelBuilder.Entity("Entities.Models.Company", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Entities.Models.Country", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("Entities.Models.PartWorld", b =>
                {
                    b.Navigation("Countries");
                });
#pragma warning restore 612, 618
        }
    }
}
