using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
