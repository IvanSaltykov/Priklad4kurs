using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Extensions
{
    public static class RepositoryTicketExtensions
    {
        public static IQueryable<Ticket> Search(this IQueryable<Ticket> tickets, string search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return tickets;
            var lowerCase = search.Trim().ToLower();
            return tickets.Where(e => e.User.ToString().Trim().ToLower().Contains(lowerCase));
        }
    }
}
