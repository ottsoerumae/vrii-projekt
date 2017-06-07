using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ApartmentsService
    {
        [Required]
        public int ApartmentsServiceId { get; set; }
        public int? ServiceId { get; set; }
        public virtual Service Service { get; set; }
        public int? ApartmentId { get; set; }
        public virtual Apartment Apartment { get; set; }
        [Required]
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
