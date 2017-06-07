using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PossibleVote
    {
        [Required]
        public int PossibleVoteId { get; set; }
        public int? VotingId { get; set; }
        public virtual Voting Voting { get; set; }
        public int? VoteId { get; set; }
        public virtual Vote Vote { get; set; }
    }
}
