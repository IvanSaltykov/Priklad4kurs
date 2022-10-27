using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
