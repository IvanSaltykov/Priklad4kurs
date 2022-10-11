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
        IEnumerable<PartWorld> GetAllPartWorlds(bool trackChanges);
        PartWorld GetPartWorld(Guid partWorldId, bool trackChanges);
    }
}
