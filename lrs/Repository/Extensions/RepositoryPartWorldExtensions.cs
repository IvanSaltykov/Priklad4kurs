using Entities.Models;
using Repository.Extensions.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Repository.Extensions
{
    public static class RepositoryPartWorldExtensions
    {
        public static IQueryable<PartWorld> Search(this IQueryable<PartWorld> partWorlds, string search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return partWorlds;
            var lowerCase = search.Trim().ToLower();
            return partWorlds.Where(e => e.Name.ToLower().Contains(lowerCase));
        }
        public static IQueryable<PartWorld> Sort(this IQueryable<PartWorld> partWorlds, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return partWorlds.OrderBy(e => e.Name);
            var orderQuery = OrderQueryBuilder.CreateOrderQuery<PartWorld>(orderByQueryString);
            if (string.IsNullOrWhiteSpace(orderQuery))
                return partWorlds.OrderBy(e => e.Name);
            return partWorlds.OrderBy(orderQuery);
        }
    }
}
