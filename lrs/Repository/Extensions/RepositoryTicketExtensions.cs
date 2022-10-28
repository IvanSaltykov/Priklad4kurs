using Entities.Models;
using Repository.Extensions.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

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
        public static IQueryable<Ticket> Sort(this IQueryable<Ticket> tickets, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return tickets.OrderBy(e => e.Price);
            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Ticket>(orderByQueryString);
            if (string.IsNullOrWhiteSpace(orderQuery))
                return tickets.OrderBy(e => e.Price);
            return tickets.OrderBy(orderQuery);
        }
    }
}
