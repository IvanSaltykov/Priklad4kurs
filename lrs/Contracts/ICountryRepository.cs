using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICountryRepository
    {
        Task<PagedList<Country>> GetCountriesAsync(Guid partWorldId, CountryParameters parameters, bool trackChanges);
        Task<Country> GetCountryAsync(Guid partWorldId, Guid id, bool trackChanges);
        void CreateCountry(Guid partWordId, Country country);
        void DeleteCountry(Country country);
    }
}
