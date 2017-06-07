using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.DTOs.VoteDTOs;
using Interfaces;
using BL.Factories;
using Domain;

namespace BL.Services.VotingService
{
    public class VotingService : IVotingService
    {
        private readonly IVotingRepository _votingRepository;
        private readonly IVoteRepository _voteRepository;
        private readonly VotingFactory _votingFactory;
        private readonly IApartmentOwnersVoteRepository _apartmentOwnersVoteRepository;
        private readonly IPossibleVoteRepository _possibleVoteRepository;

        public VotingService(IVotingRepository votingRepository,
                             IVoteRepository voteRepository,
                             VotingFactory votingFactory,
                             IApartmentOwnersVoteRepository apartmentOwnersVoteRepository,
                             IPossibleVoteRepository possibleVoteRepository)
        {
            _votingRepository = votingRepository;
            _voteRepository = voteRepository;
            _apartmentOwnersVoteRepository = apartmentOwnersVoteRepository;
            _possibleVoteRepository = possibleVoteRepository;
            _votingFactory = votingFactory;
        }
        public List<VoteDTO> GetPossibleVotesByVotingId(int id)
        {
            return _possibleVoteRepository.GetPossibleVotesByVotingId(id)
                                          .Select(vote => _votingFactory.ShowPossibleVotes(vote))
                                          .ToList();
        }
        public List<VotingResultDTO> GetResultsByVotingId(int id)
        {
            return _possibleVoteRepository.GetPossibleVotesByVotingId(id)
                                          .Select(x => _votingFactory.CreateVotingResults(x))
                                          .ToList();
        }

        public List<VotingDTO> GetRelevantVotingsByHouseId(int id)
        {
            return _votingRepository.GetRelevantVotingsByHouseId(id)
                                    .Select(voting => _votingFactory.CreateVoting(voting))
                                    .ToList();
        }
        public VotingWithPossibleVotesDTO GetVotingWithPossibleVotesByVotingId (int id)
        {
            var voting = _votingRepository.Find(id);
            var possibilities = _possibleVoteRepository.GetPossibleVotesByVotingId(id)
                                                       .Select(vote => _votingFactory.ShowPossibleVotes(vote))
                                                       .ToList();
            return _votingFactory.GetVotingWithPossibleVotes(voting, possibilities);
        }

        public VotingDTO AddNewVoting(VotingDTO votingDTO)
        {
            var domainVoting = _votingFactory.CreateDomainVoting(votingDTO);
            var ret = _votingRepository.Add(domainVoting);
            _votingRepository.SaveChanges();
            return _votingFactory.CreateVoting(ret);
        }

        //Purpose is to add new votes to the database, so that when filling the datatable PossibleVotes, we don't need to add anything to Vote table
        public VoteDTO AddNewVote(VoteDTO voteDTO)
        {
            if (_voteRepository.VoteWithGivenChoiceTextExists(voteDTO.VoteChoice) == false)
            {
                var domainVote = _votingFactory.CreateDomainVoteChoice(voteDTO);
                var ret = _voteRepository.Add(domainVote);
                _voteRepository.SaveChanges();
                return _votingFactory.CreateVoteDTO(ret);
            }
            else
            {
                var ret = _voteRepository.FindVoteByChoiceText(voteDTO.VoteChoice);
                return _votingFactory.CreateVoteDTO(ret);
            }
        }

        public PossibleVoteDTO AddNewPossibleVote(PossibleVoteDTO possibleVoteDTO)
        {
            var domainPossibleVote = _votingFactory.CreateDomainPossibleVote(possibleVoteDTO);
            var ret = _possibleVoteRepository.Add(domainPossibleVote);
            _possibleVoteRepository.SaveChanges();
            return _votingFactory.CreatePossibleVote(ret);
        }



        //Method not defined in interface yet!!!
        //public PossibleVoteDTO AssignVotesToVoting(VotingDTO votingDTO) { }

        //Makes changes to two tables: Vote and PossibleVote
        public VoteDTO AddVoteChoiceForVoting(VoteDTO voteDTO, VotingDTO votingDTO)
        {

            bool choiceAlreadyInDB = _voteRepository.VoteWithGivenChoiceTextExists(voteDTO.VoteChoice);
            if (choiceAlreadyInDB == true)
            {
                var existingVote = _voteRepository.FindVoteByChoiceText(voteDTO.VoteChoice);
                _possibleVoteRepository.Add(new PossibleVote()
                {
                    VotingId = votingDTO.VotingId,
                    VoteId = existingVote.VoteId
                }
                );
                _possibleVoteRepository.SaveChanges();
                return null;
            }
            else
            {
                var domainVote = _votingFactory.CreateDomainVoteChoice(voteDTO);
                var ret = _voteRepository.Add(domainVote);
                _voteRepository.SaveChanges();
                _possibleVoteRepository.Add(new PossibleVote()
                {
                    VotingId = votingDTO.VotingId,
                    VoteId = ret.VoteId
                }
               );
                _possibleVoteRepository.SaveChanges();
                return _votingFactory.CreateVoteDTO(ret);
            }
        }

        public VotingWithPossibleVotesDTO AddVotingWithPossibleVotes(VotingWithPossibleVotesDTO votingDTO)
        {
            var domainVoting = _votingFactory.CreateDomainVoting(votingDTO);
            var ret = _votingRepository.Add(domainVoting);
            _votingRepository.SaveChanges();
            //Voting ilma variantideta peaks olema siinkohal lisatud

            //paneme suurest votingDTO-st kokku listi voteDTO-sid 
            List<VoteDTO> possibleVotes = new List<VoteDTO>();
            possibleVotes = votingDTO.PossibleVotes;

            //Iga vote-i puhul kontrollime, kas ta on AB-s
            foreach (var voteDTO in possibleVotes)
            {
                bool choiceAlreadyInDB = _voteRepository.VoteWithGivenChoiceTextExists(voteDTO.VoteChoice);
                if (choiceAlreadyInDB == true)
                {
                    //Kui vote on ab-s olemas, me midagi juurde ei lisa, vaid otsime ta üles ja viitame temale tabelis PossibleVotes
                    var existingVote = _voteRepository.FindVoteByChoiceText(voteDTO.VoteChoice);
                    _possibleVoteRepository.Add(new PossibleVote()
                    {
                        VotingId = votingDTO.VotingId,
                        VoteId = existingVote.VoteId
                    }
                    );
                    _possibleVoteRepository.SaveChanges();
                }
                else
                {
                    //Lisame uue lisatud valikuvariandi andmebaasi
                    var domainVote = _votingFactory.CreateDomainVoteChoice(voteDTO);
                    var addedVote = _voteRepository.Add(domainVote);
                    _voteRepository.SaveChanges();

                    //Lisame viite sellele variandile ka tabelisse, kus on kirjas just lisatud hääletuse võimalikud variandid
                    _possibleVoteRepository.Add(new PossibleVote()
                    {
                        VotingId = votingDTO.VotingId,
                        VoteId = addedVote.VoteId
                    }
                   );
                    _possibleVoteRepository.SaveChanges();
                }
            }
            return _votingFactory.GetVotingWithPossibleVotes(ret, possibleVotes);
        }

        public ApartmentOwnersVoteDTO AddApartmentOwnersVote(ApartmentOwnersVoteDTO aov)
        {
            if (_apartmentOwnersVoteRepository.HasAlreadyGivenVote(aov.VotingId))
            {
                return null;
            }
            else
            {
                var domainAOV = _votingFactory.CreateDomainApartmentOwnersVote(aov);
                var ret = _apartmentOwnersVoteRepository.Add(domainAOV);
                _apartmentOwnersVoteRepository.SaveChanges();
                return _votingFactory.CreateApartmentOwnersVoteDTO(ret);
            }
        }

        //var domainVoting = _votingFactory.CreateDomainVoting(votingDTO);
        //var ret = _votingRepository.Add(domainVoting);
        //_votingRepository.SaveChanges();
        //    return _votingFactory.CreateVoting(ret);
    }
}