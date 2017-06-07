using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IPossibleVoteRepository : IRepository<PossibleVote>
    {
        List<PossibleVote> GetPossibleVotesByVotingId(int votingId);
    }
}
