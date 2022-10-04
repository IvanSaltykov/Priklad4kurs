using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Country
    {
        [Required]
        [Column("CountryId")]
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Максимальное количество символов 20")]
        public string Name { get; set; }

        //[Required]
        //[ForeignKey(nameof(PartWorld))]
        //public Guid PatrWorldId { get; set; }
        //public PartWorld World { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}
