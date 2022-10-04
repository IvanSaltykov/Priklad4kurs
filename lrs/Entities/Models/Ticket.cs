using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Ticket
    {
        [Required]
        [Column("TicketId")]
        [Key]
        public Guid Id { get; set; }
        [Required]
        [ForeignKey(nameof(PartWorld))]
        public Guid World { get; set; }
        [Required]
        [ForeignKey(nameof(Country))]
        public Guid Country { get; set; }
        [Required]
        [ForeignKey(nameof(City))]
        public Guid City { get; set; }
        [Required]
        [ForeignKey(nameof(Hotel))]
        public Guid Hotel { get; set; }
        [Required]
        public ushort Week { get; set; }
        [Required]
        public int User { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
