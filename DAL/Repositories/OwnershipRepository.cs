using DAL.Repositories;
using Domain;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class OwnershipRepository : Repository<Ownership>, IOwnershipRepository
    {
        public OwnershipRepository(ICooperationContext dbContext) : base(dbContext)
        {
        }
    }
}
