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

        public async Task<IEnumerable<PartWorld>> GetAllPartWorldsAsync(bool trackChanges) =>
            await FindAll(trackChanges).OrderBy(c => c.Name).ToListAsync();

        public async Task<PartWorld> GetPartWorldAsync(Guid partWorldId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(partWorldId), trackChanges).SingleOrDefaultAsync();
    }
}
