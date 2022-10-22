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
        Task<IEnumerable<Ticket>> GetTicketsAsync(Guid hotelId, bool trackChanges);
        Task<Ticket> GetTicketAsync(Guid hotelId, Guid id, bool trackChanges);
        void CreateTicket(Guid partWorldId, Guid countryId, Guid cityId, Guid hotelId, Ticket ticket);
        void DeleteTicket(Ticket ticket);   
    }
}
