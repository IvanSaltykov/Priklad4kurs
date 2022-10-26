using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICityRepository
    {
        Task<PagedList<City>> GetCitiesAsync(Guid countryId, CityParameters parameters, bool trackChanges);
        Task<City> GetCityAsync(Guid countryId, Guid id, bool trackChanges);
        void CreateCity(Guid countryId, City city);
        void DeleteCity(City city);
    }
}
