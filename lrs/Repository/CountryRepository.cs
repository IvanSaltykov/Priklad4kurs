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

        public IEnumerable<Country> GetCountries(Guid partWorldId, bool trackChanges) =>
            FindByCondition(e => e.PartWorldId.Equals(partWorldId), trackChanges).OrderBy(e => e.Name);

        public Country GetCountry(Guid partWorldId, Guid id, bool trackChanges) =>
            FindByCondition(e => e.PartWorldId.Equals(partWorldId) && e.Id.Equals(id), trackChanges).SingleOrDefault();
    }
}
