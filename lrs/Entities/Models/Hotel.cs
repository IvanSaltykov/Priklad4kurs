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
        [MaxLength(20, ErrorMessage = "Максимальное количество символов 20")]
        public string Name { get; set; }

        [ForeignKey(nameof(City))]
        public Guid CityId { get; set; }
        public City City { get; set; }
    }
}
