using Domain;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class VotingRepository : Repository<Voting>, IVotingRepository
    {
        public VotingRepository(ICooperationContext dbContext) : base(dbContext)
        {
        }

        public List<Voting> GetRelevantVotingsByHouseId(int houseId)
        {
            return RepositoryDbSet.Where(voting => voting.HouseId == houseId
                                  && voting.FromDate <= DateTime.Now
                                  && voting.ToDate >= DateTime.Now).ToList();
        }
    }
}
