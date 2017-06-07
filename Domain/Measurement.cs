using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Measurement
    {
        [Required]
        public int MeasurementId { get; set; }
        public int? ServiceId { get; set; }
        public virtual Service Service { get; set; }
        public int? OwnershipId { get; set; }
        public virtual Ownership Ownership { get; set; }
        [Required]
        public DateTime MeasurementDate { get; set; }
        [Required]
        public double MeasurementValue { get; set; }
    }
}
