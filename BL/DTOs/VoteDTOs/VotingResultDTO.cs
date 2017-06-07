using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs.VoteDTOs
{
    public class VotingResultDTO
    {
        //public int VoteId { get; set; } //Ei tea kas on vaja aga miks mitte :D
        public string VoteChoice { get; set; }//ilmselt pole settereid vaja!!!
        public int VoteCount { get; set; }
    }
}
