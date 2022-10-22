using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPartWorldRepository
    {
        Task<IEnumerable<PartWorld>> GetAllPartWorldsAsync(bool trackChanges);
        Task<PartWorld> GetPartWorldAsync(Guid partWorldId, bool trackChanges);
        void DeletePartWorld(PartWorld partWorld);
        void CreatePartWorld(PartWorld partWorld);
    }
}
