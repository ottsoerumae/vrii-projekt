using ClientConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConsole.Services
{
    public class VotingService : BaseService
    {
        public VotingService():base(ServiceConstants.VotingServiceUrl) //Paneme uri paika juba konstruktoris, et seda ei peaks igal pool eraldi täpselt samamoodi tegema.
        {

        }

        public async Task<Voting> AddNewVoting(Voting voting)
        {
            return await base.PostData<Voting>("", voting);
        }

        public async Task<Vote> AddNewVote(Vote vote)
        {
            return await base.PostData<Vote>("vote", vote);
        }

        public async Task<PossibleVote> AddNewPossibleVote(PossibleVote possibleVote)
        {
            return await base.PostData<PossibleVote>("possibility", possibleVote);
        }

        public async Task<ApartmentOwnersVote> AddApartmentOwnersVote(ApartmentOwnersVote aov)
        {
            return await base.PostData<ApartmentOwnersVote>("addresult", aov);
        }

        public List<PossibleVote> MakeListOfPossibleVotes(List<Vote> votes, Voting voting)
        {
            List<PossibleVote> possibilities = new List<PossibleVote>();
            //siin võiks äkki hiljem jagada miskit factorytesse
            foreach(var vote in votes)
            {
                var possibleVote = new PossibleVote()
                {
                    VotingId = voting.VotingId,
                    VoteId = vote.VoteId
                };
                possibilities.Add(possibleVote);
            }
            return possibilities;
        }
    }
}
