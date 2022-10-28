using Contracts;
using Entities;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
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

        public async Task<PagedList<Country>> GetCountriesAsync(Guid partWorldId, CountryParameters parameters, bool trackChanges)
        {
            var countries = await FindByCondition(e => e.PartWorldId.Equals(partWorldId), trackChanges)
                .Search(parameters.Search)
                .Sort(parameters.OrderBy)
                .ToListAsync();
            return PagedList<Country>.ToPagedList(countries, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<Country> GetCountryAsync(Guid partWorldId, Guid id, bool trackChanges) =>
            await FindByCondition(e => e.PartWorldId.Equals(partWorldId) && e.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
    }
}
