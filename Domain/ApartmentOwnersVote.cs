using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ApartmentOwnersVote
    {
        [Required]
        public int ApartmentOwnersVoteId { get; set; }
        public int? OwnershipId { get; set; }
        public virtual Ownership Ownership { get; set; }
        public int? VotingId { get; set; }
        public virtual Voting Voting { get; set; }
        public int? VoteId { get; set; }
        public virtual Vote Vote { get; set; }
        public string Reason { get; set; }
    }
}
