using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs.VoteDTOs
{
    public class ApartmentOwnersVoteDTO
    {
        public int ApartmentOwnersVoteId { get; set; }
        public int? OwnershipId { get; set; }
        public int? VotingId { get; set; }
        public int? VoteId { get; set; }
    }
}
