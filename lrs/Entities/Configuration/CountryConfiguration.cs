using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData
            (
                new Country
                {
                    Id = new Guid("d075f092-113c-487a-8d25-1da6f29de000"),
                    Name = "Россия",
                    PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47120")
                },
                new Country
                {
                    Id = new Guid("d075f092-113c-487a-8d25-1da6f29de001"),
                    Name = "Китай",
                    PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47121")
                },
                new Country
                {
                    Id = new Guid("d075f092-113c-487a-8d25-1da6f29de002"),
                    Name = "Индия",
                    PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47121")
                },
                new Country
                {
                    Id = new Guid("d075f092-113c-487a-8d25-1da6f29de003"),
                    Name = "Италия",
                    PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47120")
                },
                new Country
                {
                    Id = new Guid("d075f092-113c-487a-8d25-1da6f29de004"),
                    Name = "Испания",
                    PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47120")
                },
                new Country
                {
                    Id = new Guid("d075f092-113c-487a-8d25-1da6f29de005"),
                    Name = "Канада",
                    PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47124")
                },
                new Country
                {
                    Id = new Guid("d075f092-113c-487a-8d25-1da6f29de006"),
                    Name = "США",
                    PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47124")
                },
                new Country
                {
                    Id = new Guid("d075f092-113c-487a-8d25-1da6f29de007"),
                    Name = "Бразилия",
                    PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47124")
                },
                new Country
                {
                    Id = new Guid("d075f092-113c-487a-8d25-1da6f29de008"),
                    Name = "Австралия",
                    PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47123")
                },
                new Country
                {
                    Id = new Guid("d075f092-113c-487a-8d25-1da6f29de009"),
                    Name = "Португалия",
                    PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47120")
                },
                new Country
                {
                    Id = new Guid("d075f092-113c-487a-8d25-1da6f29de010"),
                    Name = "Грузия",
                    PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47121")
                },
                new Country
                {
                    Id = new Guid("d075f092-113c-487a-8d25-1da6f29de011"),
                    Name = "Англия",
                    PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47120")
                },
                new Country
                {
                    Id = new Guid("d075f092-113c-487a-8d25-1da6f29de012"),
                    Name = "Япония",
                    PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47121")
                },
                new Country
                {
                    Id = new Guid("d075f092-113c-487a-8d25-1da6f29de013"),
                    Name = "Германия",
                    PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47120")
                },
                new Country
                {
                    Id = new Guid("d075f092-113c-487a-8d25-1da6f29de014"),
                    Name = "Армения",
                    PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47120")
                },
                new Country
                {
                    Id = new Guid("d075f092-113c-487a-8d25-1da6f29de015"),
                    Name = "Франция",
                    PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47120")
                },
                new Country
                {
                    Id = new Guid("d075f092-113c-487a-8d25-1da6f29de016"),
                    Name = "Чили",
                    PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47124")
                },
                new Country
                {
                    Id = new Guid("d075f092-113c-487a-8d25-1da6f29de017"),
                    Name = "Египет",
                    PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47122")
                },
                new Country
                {
                    Id = new Guid("d075f092-113c-487a-8d25-1da6f29de018"),
                    Name = "Тунис",
                    PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47122")
                },
                new Country
                {
                    Id = new Guid("d075f092-113c-487a-8d25-1da6f29de019"),
                    Name = "Марокко",
                    PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47122")
                },
                new Country
                {
                    Id = new Guid("d075f092-113c-487a-8d25-1da6f29de020"),
                    Name = "ЮАР",
                    PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47122")
                }
            );
        }
    }
}
