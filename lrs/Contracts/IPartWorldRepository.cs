using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPartWorldRepository
    {
        Task<PagedList<PartWorld>> GetAllPartWorldsAsync(bool trackChanges, PartWorldParameters parameters);
        Task<PartWorld> GetPartWorldAsync(Guid partWorldId, bool trackChanges);
        void DeletePartWorld(PartWorld partWorld);
        void CreatePartWorld(PartWorld partWorld);
    }
}
