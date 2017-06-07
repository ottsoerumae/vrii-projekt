using Domain;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ApartmentOwnersVoteRepository : Repository<ApartmentOwnersVote>, IApartmentOwnersVoteRepository
    {
        public ApartmentOwnersVoteRepository(ICooperationContext dbContext) : base(dbContext)
        {
        }

        public bool HasAlreadyGivenVote(int? votingId)
        {
            return RepositoryDbSet.Any(x => x.VotingId == votingId);
        }
    }
}
