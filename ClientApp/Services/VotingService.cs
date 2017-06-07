using ClientApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Services
{
    public class VotingService : BaseService
    {
        public VotingService() : base(ServiceConstants.VotingServiceUrl)
        {

        }

        public async Task<List<Voting>> GetRelevantVotingsByHouseId(int houseId)
        {
            return await base.GetData<List<Voting>>("house/" + houseId.ToString());
        }

        public async Task<List<Vote>> GetPossibleVotesByVotingId(int votingId)
        {
            return await base.GetData<List<Vote>>("votes/" + votingId.ToString());
        }

        public async Task<List<VotingResults>> GetResultsByVotingId(int votingId)
        {
            return await base.GetData<List<VotingResults>>("results/" + votingId.ToString());
        }

        public async Task<ApartmentOwnersVote> PostApartmentOwnersVote(ApartmentOwnersVote aov)
        {
            return await base.PostData<ApartmentOwnersVote>("addresult", aov);
        }
    }
}
