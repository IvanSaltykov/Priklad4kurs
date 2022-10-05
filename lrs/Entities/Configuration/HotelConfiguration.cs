using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData
            (
                new Hotel
                {
                    Id = new Guid("6873c93f-3d2b-4f14-92c6-7397d12a9000"),
                    Name = "Саранск",
                    CityId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47002")
                }
            );
        }
    }
}
