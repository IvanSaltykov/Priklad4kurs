using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class CountryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid PartWorldId { get; set; }
    }
}
