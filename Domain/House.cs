using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class House
    {
        [Required]
        public int HouseId { get; set; }
        [Required]
        [MaxLength(128)]
        public string County { get; set; }
        [Required]
        [MaxLength(128)]
        public string City { get; set; }
        [Required]
        [MaxLength(128)]
        public string Street { get; set; }
        [Required]
        public int HouseNo { get; set; }
        [Required]
        public int ZipCode { get; set; }
        public virtual List<Apartment> Apartments { get; set; }
        public virtual List<Notice> Notices { get; set; }
        public virtual List<Voting> Votings { get; set; }
        public virtual List<Board> Boards { get; set; }
    }
}
