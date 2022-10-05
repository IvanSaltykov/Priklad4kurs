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
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasData
            (
                new Ticket
                {
                    Id = new Guid("adcead95-068e-448a-b0e2-3f6a4c64a000"),
                    World = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47120"),
                    Country = new Guid("d075f092-113c-487a-8d25-1da6f29de000"),
                    City = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47002"),
                    Hotel = new Guid("6873c93f-3d2b-4f14-92c6-7397d12a9000"),
                    Week = 2,
                    User = 1,
                    Price = 10000
                }
            );
        }
    }
}
