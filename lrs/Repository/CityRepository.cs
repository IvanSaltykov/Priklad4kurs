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
    public class CityRepository : RepositoryBase<City>, ICityRepository
    {
        public CityRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateCity(Guid countryId, City city)
        {
            city.CountryId = countryId;
            Create(city);
        }

        public void DeleteCity(City city)
        {
            Delete(city);
        }

        public async Task<IEnumerable<City>> GetCitiesAsync(Guid countryId, bool trackChanges) =>
            await FindByCondition(e => e.CountryId.Equals(countryId), trackChanges).OrderBy(e => e.Name).ToListAsync();

        public async Task<City> GetCityAsync(Guid countryId, Guid id, bool trackChanges) =>
            await FindByCondition(e => e.CountryId.Equals(countryId) && e.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
    }
}
