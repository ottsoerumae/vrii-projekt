using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs.VoteDTOs
{
    public class VotingDTO
    {
        public int VotingId { get; set; }
        public int? HouseId { get; set; }
        public string Suggestion { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
