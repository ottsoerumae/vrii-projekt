using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class InvoiceRow
    {
        [Required]
        public int InvoiceRowId { get; set; }
        public int? InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }
        public int? ServiceId { get; set; }
        public virtual Service Service { get; set; }
        [Required]
        public double ServiceAmount { get; set; }
        [Required]
        public double ServicePrice { get; set; }
        [Required]
        public double TotalCost { get; set; }
    }
}
