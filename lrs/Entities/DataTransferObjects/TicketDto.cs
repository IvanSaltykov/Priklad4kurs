using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class TicketDto
    {
        public Guid Id { get; set; }
        public Guid World { get; set; }
        public Guid Country { get; set; }
        public Guid City { get; set; }
        public Guid Hotel { get; set; }
        public ushort Week { get; set; }
        public int User { get; set; }
        public int Price { get; set; }
    }
}
