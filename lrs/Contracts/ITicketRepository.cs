using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ITicketRepository
    {
        IEnumerable<Ticket> GetTickets(Guid hotelId, bool trackChanges);
        Ticket GetTicket(Guid hotelId, Guid id, bool trackChanges);
    }
}
