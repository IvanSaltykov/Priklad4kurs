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
                    Id = Guid.NewGuid(),
                    Name = "Европа"
                },
                new PartWorld
                {
                    Id= Guid.NewGuid(),
                    Name = "Азия"
                },
                new PartWorld
                {
                    Id = Guid.NewGuid(),
                    Name = "Африка"
                },
                new PartWorld
                {
                    Id = Guid.NewGuid(),
                    Name = "Австралия"
                },
                new PartWorld
                {
                    Id = Guid.NewGuid(),
                    Name = "Америка"
                }
            );

        }
    }
}
