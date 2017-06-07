using BL.DTOs.VoteDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.VotingService
{
    public interface IVotingService
    {
        List<VotingResultDTO> GetResultsByVotingId(int id);
        List<VotingDTO> GetRelevantVotingsByHouseId(int id);
        List<VoteDTO> GetPossibleVotesByVotingId(int id);
        VotingWithPossibleVotesDTO GetVotingWithPossibleVotesByVotingId(int id);
        VotingDTO AddNewVoting(VotingDTO votingDto);
        VoteDTO AddNewVote(VoteDTO voteDTO);
        PossibleVoteDTO AddNewPossibleVote(PossibleVoteDTO possibleVoteDTO);
        VoteDTO AddVoteChoiceForVoting(VoteDTO voteDTO, VotingDTO votingDTO);
        VotingWithPossibleVotesDTO AddVotingWithPossibleVotes(VotingWithPossibleVotesDTO votingDTO);
        ApartmentOwnersVoteDTO AddApartmentOwnersVote(ApartmentOwnersVoteDTO aov);
    }
}
