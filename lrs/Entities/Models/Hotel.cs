using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Hotel
    {
        [Required]
        [Column("HotelId")]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey(nameof(City))]
        public string CityId { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Максимальное количество символов 20")]
        public string Name { get; set; }
        public City city { get; set; }
    }
}
