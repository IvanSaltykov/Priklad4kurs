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
    public class PartWorldRepository : RepositoryBase<PartWorld>, IPartWorldRepository
    {
        public PartWorldRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
