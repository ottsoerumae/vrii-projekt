using BL.DTOs.VoteDTOs;
using BL.Services.VotingService;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Factories
{
    public class VotingFactory
    {
        public VoteDTO ShowPossibleVotes(PossibleVote possibleVote)
        {
            return new VoteDTO
            {
                VoteId = possibleVote.Vote.VoteId,
                VoteChoice = possibleVote.Vote.VoteChoice
            };
        }

        public VotingResultDTO CreateVotingResults(PossibleVote pVote) //Vt nimi üle, see create on veits eksitav (ikkagi get päring)
        {
            return new VotingResultDTO //Nimi võiks olla pigem VotingResultDTO, see liiga eksitav!!!
            {
                VoteChoice = pVote.Vote.VoteChoice,
                VoteCount = pVote.Vote.ApartmentOwnersVotes
                                .Count(ownersVote => ownersVote.VotingId == pVote.VotingId)                 
            };
        }

        public VotingDTO CreateVoting(Voting voting)
        {
            return new VotingDTO
            {
                VotingId = voting.VotingId,
                HouseId = voting.HouseId,
                Suggestion = voting.Suggestion,
                FromDate = voting.FromDate,
                ToDate = voting.ToDate
            };
        }

        public VotingWithPossibleVotesDTO GetVotingWithPossibleVotes(Voting voting, List<VoteDTO> possibilities)
        {
            return new VotingWithPossibleVotesDTO
            {
                VotingId = voting.VotingId,
                HouseId = voting.HouseId,
                Suggestion = voting.Suggestion,
                PossibleVotes = possibilities,
                FromDate = voting.FromDate,
                ToDate = voting.ToDate
            };
        }

        public Voting CreateDomainVoting(VotingDTO votingDTO)
        {
            return new Voting()
            {
                VotingId = votingDTO.VotingId,
                HouseId = votingDTO.HouseId,
                Suggestion = votingDTO.Suggestion,
                FromDate = votingDTO.FromDate,
                ToDate = votingDTO.ToDate
            };
        }

        public Voting CreateDomainVoting(VotingWithPossibleVotesDTO votingDTO)
        {
            return new Voting()
            {
                VotingId = votingDTO.VotingId,
                HouseId = votingDTO.HouseId,
                Suggestion = votingDTO.Suggestion,
                FromDate = votingDTO.FromDate,
                ToDate = votingDTO.ToDate
            };
        }

        public PossibleVote CreateDomainPossibleVote(PossibleVoteDTO possibleVoteDTO)
        {
            return new PossibleVote()
            {
                PossibleVoteId = possibleVoteDTO.PossibleVoteId,
                VotingId = possibleVoteDTO.VotingId,
                VoteId = possibleVoteDTO.VoteId
            };
        }

        public PossibleVoteDTO CreatePossibleVote(PossibleVote possibleVote)
        {
            return new PossibleVoteDTO()
            {
                PossibleVoteId = possibleVote.PossibleVoteId,
                VotingId = possibleVote.VotingId,
                VoteId = possibleVote.VoteId
            };
        }

        public Vote CreateDomainVoteChoice(VoteDTO voteDTO)
        {
            return new Vote()
            {
                VoteId = voteDTO.VoteId,
                VoteChoice = voteDTO.VoteChoice
            };
        }

        public VoteDTO CreateVoteDTO(Vote vote)
        {
            return new VoteDTO()
            {
                VoteId = vote.VoteId,
                VoteChoice = vote.VoteChoice
            };
        }

        public ApartmentOwnersVote CreateDomainApartmentOwnersVote(ApartmentOwnersVoteDTO vote)
        {
            return new ApartmentOwnersVote()
            {
                ApartmentOwnersVoteId = vote.ApartmentOwnersVoteId,
                OwnershipId = vote.OwnershipId,
                VotingId = vote.VotingId,
                VoteId = vote.VoteId
            };
        }

        public ApartmentOwnersVoteDTO CreateApartmentOwnersVoteDTO(ApartmentOwnersVote vote)
        {
            return new ApartmentOwnersVoteDTO()
            {
                ApartmentOwnersVoteId = vote.ApartmentOwnersVoteId,
                OwnershipId = vote.OwnershipId,
                VotingId = vote.VotingId,
                VoteId = vote.VoteId
            };
        }
    }
}
