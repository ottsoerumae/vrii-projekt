using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs.VoteDTOs
{
    public class PossibleVoteDTO
    {
        public int PossibleVoteId { get; set; }
        public int? VotingId { get; set; }
        public int? VoteId { get; set; }
    }
}
