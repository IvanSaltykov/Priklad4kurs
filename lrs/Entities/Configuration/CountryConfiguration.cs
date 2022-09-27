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
                    PatrWorldId = new Guid("D7D92EC3-7BE7-4E53-862B-086F83640617"),
                }
            );
        }
    }
}
