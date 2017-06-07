using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Ownership
    {
        [Required]
        public int OwnershipId { get; set; }
        public int? ApartmentId { get; set; }
        public virtual Apartment Apartment { get; set; }
        public int? PersonId { get; set; }
        public virtual Person Person { get; set; }
        [Required]
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public virtual List<Measurement> Measurements { get; set; }
        public virtual List<ApartmentOwnersVote> ApartmentOwnersVotes { get; set; }
        public virtual List<ApartmentsService> ApartmentsServices { get; set; }
    }
}
