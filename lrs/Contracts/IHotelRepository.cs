using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IHotelRepository
    {
        Task<IEnumerable<Hotel>> GetHotelsAsync(Guid cityId, bool trackChanges);
        Task<Hotel> GetHotelAsync(Guid cityId, Guid id, bool trackChanges);
        void CreateHotel(Guid cityId, Hotel hotel);
        void DeleteHotel(Hotel hotel);
    }
}
