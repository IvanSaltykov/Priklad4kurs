using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class City
    {
        [Required]
        [Column("CityId")]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey(nameof(Country))]
        public string CountrId { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Максимальное количество символов 20")]
        public string Name { get; set; }

        public Country country { get; set; }
        public ICollection<Hotel> hotels { get; set; }
    }
}
