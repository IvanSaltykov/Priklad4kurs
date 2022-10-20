using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public abstract class PartWorldManipulationDto
    {
        [Required]
        [MaxLength(15, ErrorMessage = "Максимальное количество символов 15")]
        public string Name { get; set; }
    }
}
