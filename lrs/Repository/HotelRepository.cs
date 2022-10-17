using Contracts;
using Entities;
using Entities.Models;
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

        public Hotel GetHotel(Guid cityId, Guid id, bool trackChanges) =>
            FindByCondition(e => e.CityId.Equals(cityId) && e.Id.Equals(id), trackChanges).SingleOrDefault();

        public IEnumerable<Hotel> GetHotels(Guid cityId, bool trackChanges) =>
            FindByCondition(e => e.CityId.Equals(cityId), trackChanges).OrderBy(e => e.Name);
    }
}
