using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetCountriesAsync(Guid partWorldId, bool trackChanges);
        Task<Country> GetCountryAsync(Guid partWorldId, Guid id, bool trackChanges);
        void CreateCountry(Guid partWordId, Country country);
        void DeleteCountry(Country country);
    }
}
