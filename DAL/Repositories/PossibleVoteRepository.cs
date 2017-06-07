using Domain;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PossibleVoteRepository : Repository<PossibleVote>, IPossibleVoteRepository
    {
        public PossibleVoteRepository(ICooperationContext dbContext) : base(dbContext)
        {
        }

        public List<PossibleVote> GetPossibleVotesByVotingId(int votingId)
        {
            return RepositoryDbSet.Where(p => p.VotingId == votingId).ToList();
        }
    }
}
