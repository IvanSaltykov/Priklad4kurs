using Entities.Models;
using Repository.Extensions.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace Repository.Extensions
{
    public static class RepositoryCountryExtensions
    {
        public static IQueryable<Country> Search(this IQueryable<Country> countries, string search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return countries;
            var lowerCase = search.Trim().ToLower();
            return countries.Where(e => e.Name.ToLower().Contains(lowerCase));
        }
        public static IQueryable<Country> Sort(this IQueryable<Country> countries, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return countries.OrderBy(e => e.Name);
            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Country>(orderByQueryString);
            if (string.IsNullOrWhiteSpace(orderQuery))
                return countries.OrderBy(e => e.Name);
            return countries.OrderBy(orderQuery);
        }
    }
}
