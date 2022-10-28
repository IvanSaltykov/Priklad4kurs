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
    public static class RepositoryCityExtensions
    {
        public static IQueryable<City> Search(this IQueryable<City> cities, string search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return cities;
            var lowerCase = search.Trim().ToLower();
            return cities.Where(e => e.Name.ToLower().Contains(lowerCase));
        }
        public static IQueryable<City> Sort(this IQueryable<City> cities, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return cities.OrderBy(e => e.Name);
            var orderQuery = OrderQueryBuilder.CreateOrderQuery<City>(orderByQueryString);
            if (string.IsNullOrWhiteSpace(orderQuery))
                return cities.OrderBy(e => e.Name);
            return cities.OrderBy(orderQuery);
        }
    }
}
