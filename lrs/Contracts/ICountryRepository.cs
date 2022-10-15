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
        IEnumerable<Country> GetCountries(Guid partWorldId, bool trackChanges);
        Country GetCountry(Guid partWorldId, Guid id, bool trackChanges);
        void CreateCountry(Guid partWordId, Country country);
    }
}
