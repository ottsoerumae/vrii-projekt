using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Price
    {
        [Required]
        public int PriceId { get; set; }
        public int? ServiceId { get; set; }
        public virtual Service Service { get; set; }
        [Required]
        public double PriceValue { get; set; }
        [Required]
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
