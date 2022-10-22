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
    public class CountryRepository : RepositoryBase<Country>, ICountryRepository
    {
        public CountryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateCountry(Guid partWordId, Country country)
        {
            country.PartWorldId = partWordId;
            Create(country);
        }

        public void DeleteCountry(Country country)
        {
            Delete(country);
        }

        public async Task<IEnumerable<Country>> GetCountriesAsync(Guid partWorldId, bool trackChanges) =>
            await FindByCondition(e => e.PartWorldId.Equals(partWorldId), trackChanges).OrderBy(e => e.Name).ToListAsync();

        public async Task<Country> GetCountryAsync(Guid partWorldId, Guid id, bool trackChanges) =>
            await FindByCondition(e => e.PartWorldId.Equals(partWorldId) && e.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
    }
}
