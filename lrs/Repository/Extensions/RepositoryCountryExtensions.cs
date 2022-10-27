using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
    }
}
