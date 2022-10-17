using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class TicketUpdateDto
    {
        public ushort Week { get; set; }
        public int User { get; set; }
        public int Price { get; set; }
    }
}
