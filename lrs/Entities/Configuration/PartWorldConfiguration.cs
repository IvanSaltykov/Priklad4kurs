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
    public class PartWorldConfiguration : IEntityTypeConfiguration<PartWorld>
    {
        public void Configure(EntityTypeBuilder<PartWorld> builder)
        {
            builder.HasData
            (
                new PartWorld
                {
                    Id = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47120"),
                    Name = "Европа"
                },
                new PartWorld
                {
                    Id = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47121"),
                    Name = "Азия"
                },
                new PartWorld
                {
                    Id = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47122"),
                    Name = "Африка"
                },
                new PartWorld
                {
                    Id = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47123"),
                    Name = "Австралия"
                },
                new PartWorld
                {
                    Id = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47124"),
                    Name = "Америка"
                }
            );

        }
    }
}
