using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public abstract class TicketManipulationDto
    {
        [Required]
        public ushort Week { get; set; }
        [Required]
        public int User { get; set; }
        [Required]
        [Range(18, int.MaxValue, ErrorMessage = "Age is required and it can't be lower than 18")]
        public int Price { get; set; }
    }
}
