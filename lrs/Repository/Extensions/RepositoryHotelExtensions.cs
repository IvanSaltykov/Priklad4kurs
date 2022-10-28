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
    public static class RepositoryHotelExtensions
    {
        public static IQueryable<Hotel> Search(this IQueryable<Hotel> hotels, string search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return hotels;
            var lowerCase = search.Trim().ToLower();
            return hotels.Where(e => e.Name.ToLower().Contains(lowerCase));
        }
        public static IQueryable<Hotel> Sort(this IQueryable<Hotel> hotels, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return hotels.OrderBy(e => e.Name);
            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Hotel>(orderByQueryString);
            if (string.IsNullOrWhiteSpace(orderQuery))
                return hotels.OrderBy(e => e.Name);
            return hotels.OrderBy(orderQuery);
        }
    }
}
