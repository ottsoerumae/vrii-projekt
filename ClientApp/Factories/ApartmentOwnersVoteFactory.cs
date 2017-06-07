using ClientApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Factories
{
    public class ApartmentOwnersVoteFactory
    {
        public ApartmentOwnersVote CreateApartmentOwnersVote(int ownershipId, int votingId, int voteId)
        {
            return new ApartmentOwnersVote()
            {
                OwnershipId = ownershipId,
                VotingId = votingId,
                VoteId = voteId
            };
        }
    }
}
