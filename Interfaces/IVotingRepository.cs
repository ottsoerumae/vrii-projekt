using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IVotingRepository : IRepository<Voting>
    {
        List<Voting> GetRelevantVotingsByHouseId(int houseId);
    }
}
