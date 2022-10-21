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
        [Range(1, 10, ErrorMessage = "Значение должно быть от 1 до 10")]
        public int Week { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Значение должно быть положительным")]
        public int User { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Значение должно быть положительным")]
        public int Price { get; set; }
    }
}
