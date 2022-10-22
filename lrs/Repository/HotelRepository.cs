using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class HotelRepository : RepositoryBase<Hotel>, IHotelRepository
    {
        public HotelRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateHotel(Guid cityId, Hotel hotel)
        {
            hotel.CityId = cityId;
            Create(hotel);
        }
        public void DeleteHotel(Hotel hotel)
        {
            Delete(hotel);
        }

        public async Task<Hotel> GetHotelAsync(Guid cityId, Guid id, bool trackChanges) =>
            await FindByCondition(e => e.CityId.Equals(cityId) && e.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

        public async Task<IEnumerable<Hotel>> GetHotelsAsync(Guid cityId, bool trackChanges) =>
            await FindByCondition(e => e.CityId.Equals(cityId), trackChanges).OrderBy(e => e.Name).ToListAsync();
    }
}
