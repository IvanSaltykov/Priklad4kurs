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
    public class CityRepository : RepositoryBase<City>, ICityRepository
    {
        public CityRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<City> GetCities(Guid countryId, bool trackChanges) =>
            FindByCondition(e => e.CountryId.Equals(countryId), trackChanges).OrderBy(e => e.Name);

        public City GetCity(Guid countryId, Guid id, bool trackChanges) =>
            FindByCondition(e => e.CountryId.Equals(countryId) && e.Id.Equals(id), trackChanges).SingleOrDefault();
    }
}
