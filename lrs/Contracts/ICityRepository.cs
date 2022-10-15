using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICityRepository
    {
        IEnumerable<City> GetCities(Guid countryId, bool trackChanges);
        City GetCity(Guid countryId, Guid id, bool trackChanges);
        void CreateCity(Guid countryId, City city);
    }
}
