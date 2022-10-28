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
    public class PartWorldRepository : RepositoryBase<PartWorld>, IPartWorldRepository
    {
        public PartWorldRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreatePartWorld(PartWorld partWorld)
        {
            Create(partWorld);
        }

        public void DeletePartWorld(PartWorld partWorld)
        {
            Delete(partWorld);
        }

        public async Task<PagedList<PartWorld>> GetAllPartWorldsAsync(bool trackChanges, PartWorldParameters parameters)
        {
            var partWorlds = await FindAll(trackChanges)
                .Search(parameters.Search)
                .Sort(parameters.OrderBy)
                .ToListAsync();
            return PagedList<PartWorld>.ToPagedList(partWorlds, parameters.PageNumber, parameters.PageSize);
        }


        public async Task<PartWorld> GetPartWorldAsync(Guid partWorldId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(partWorldId), trackChanges).SingleOrDefaultAsync();
    }
}
