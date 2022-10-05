using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class PartWorld
    {
        [Required]
        [Column("PartWorldId")]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "Максимальное количество символов 15")]
        public string Name { get; set; }
        public ICollection<Country> Countries { get; set; }
    }
}
