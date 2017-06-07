using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Vote
    {
        [Required]
        public int VoteId { get; set; }
        [Required]
        [MaxLength(128)]
        public string VoteChoice { get; set; }
        public virtual List<ApartmentOwnersVote> ApartmentOwnersVotes { get; set; }
        public virtual List<PossibleVote> PossibleVotes { get; set; }
    }
}
