using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Voting
    {
        [Required]
        public int VotingId { get; set; }
        public int? HouseId { get; set; }
        public virtual House House { get; set; }
        [Required]
        [MaxLength(256)]
        public string Suggestion { get; set; }
        [Required]
        public DateTime FromDate { get; set; }
        [Required]
        public DateTime ToDate { get; set; }
        public virtual List<ApartmentOwnersVote> ApartmentOwnersVotes { get; set; }
        public virtual List<PossibleVote> PossibleVotes { get; set; }
    }
}
