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
        IEnumerable<Hotel> GetHotels(Guid cityId, bool trackChanges);
        Hotel GetHotel(Guid cityId, Guid id, bool trackChanges);
        void CreateHotel(Guid cityId, Hotel hotel);
    }
}
