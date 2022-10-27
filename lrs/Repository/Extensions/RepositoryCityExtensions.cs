using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
