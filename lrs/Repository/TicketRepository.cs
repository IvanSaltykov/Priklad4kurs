using Contracts;
using Entities;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
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

        public async Task<PagedList<Ticket>> GetTicketsAsync(Guid hotelId, TicketParameters parameters, bool trackChanges)
        {
            var tickets = await FindByCondition(
                e => e.Hotel.Equals(hotelId) && (e.Price >= parameters.MinPrice && e.Price <= parameters.MaxPrice),
                trackChanges
            ).Search(parameters.Search)
            .Sort(parameters.OrderBy)
            .ToListAsync();
            return PagedList<Ticket>.ToPagedList(tickets, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<Ticket> GetTicketAsync(Guid hotelId, Guid id, bool trackChanges) =>
            await FindByCondition(e => e.Hotel.Equals(hotelId) && e.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

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
