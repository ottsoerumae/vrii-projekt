using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Board
    {
        [Required]
        public int BoardId { get; set; }
        public int? HouseId { get; set; }
        public virtual House House { get; set; }
        public int? PersonId { get; set; }
        public virtual Person Person { get; set; }
        public int? RoleId { get; set; }
        public virtual Role Role { get; set; }
        [Required]
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
