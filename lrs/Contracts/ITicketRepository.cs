using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ITicketRepository
    {
        Task<PagedList<Ticket>> GetTicketsAsync(string userId, Guid hotelId, TicketParameters parameters, bool trackChanges);
        Task<Ticket> GetTicketAsync(string userId, Guid hotelId, Guid id, bool trackChanges);
        Task<Ticket> GetTicketAsync(Guid hotelId, Guid id, bool trackChanges);
        void CreateTicket(string userId, Guid partWorldId, Guid countryId, Guid cityId, Guid hotelId, Ticket ticket);
        void DeleteTicket(Ticket ticket);   
    }
}
