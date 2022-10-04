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
                    Id = Guid.NewGuid(),
                    Name = "Россия",
                    //PatrWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47128")
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Китай",
                    //PatrWorldId = new Guid("d075f092-113c-487a-8d25-1da6f29de001")
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Индия",
                    //PatrWorldId = new Guid("d075f092-113c-487a-8d25-1da6f29de001")
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Италия",
                    //PatrWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47128")
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Испания",
                    //PatrWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47128")
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Канада",
                    //PatrWorldId = new Guid("adcead95-068e-448a-b0e2-3f6a4c64abe0")
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "США",
                    //PatrWorldId = new Guid("adcead95-068e-448a-b0e2-3f6a4c64abe0")
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Бразилия",
                    //PatrWorldId = new Guid("adcead95-068e-448a-b0e2-3f6a4c64abe0")
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Австралия",
                    //PatrWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47128")
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Португалия",
                    //PatrWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47128")
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Грузия",
                    //PatrWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47128")
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Англия",
                    //PatrWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47128")
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Япония",
                    //PatrWorldId = new Guid("d075f092-113c-487a-8d25-1da6f29de001")
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Германия",
                    //PatrWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47128")
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Армения",
                    //PatrWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47128")
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Франция",
                    //PatrWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47128")
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Чили",
                    //PatrWorldId = new Guid("adcead95-068e-448a-b0e2-3f6a4c64abe0")
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Египет",
                    //PatrWorldId = new Guid("6873c93f-3d2b-4f14-92c6-7397d12a9b30")
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Тунис",
                    //PatrWorldId = new Guid("6873c93f-3d2b-4f14-92c6-7397d12a9b30")
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Марокко",
                    //PatrWorldId = new Guid("6873c93f-3d2b-4f14-92c6-7397d12a9b30")
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "ЮАР",
                    //PatrWorldId = new Guid("6873c93f-3d2b-4f14-92c6-7397d12a9b30")
                }
            );
        }
    }
}
