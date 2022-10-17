using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class TicketRepository : RepositoryBase<Ticket>, ITicketRepository
    {
        public TicketRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Ticket> GetTickets(Guid hotelId, bool trackChanges) =>
            FindByCondition(e => e.Hotel.Equals(hotelId), trackChanges).OrderBy(e => e.Id);

        public Ticket GetTicket(Guid hotelId, Guid id, bool trackChanges) =>
            FindByCondition(e => e.Hotel.Equals(hotelId) && e.Id.Equals(id), trackChanges).SingleOrDefault();

        public void CreateTicket(Guid partWorldId, Guid countryId, Guid cityId, Guid hotelId, Ticket ticket)
        {
            ticket.World = partWorldId;
            ticket.Country = countryId;
            ticket.City = cityId;
            ticket.Hotel = hotelId;
            Create(ticket);
        }

        public void DeleteTicket(Ticket ticket)
        {
            Delete(ticket);
        }
    }
}
