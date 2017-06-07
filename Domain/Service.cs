using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Service
    {
        [Required]
        public int ServiceId { get; set; }
        [Required]
        [MaxLength(64)]
        public string ServiceName { get; set; }
        [Required]
        [MaxLength(32)]
        public string ServiceUnit { get; set; }
        [Required]
        public bool HasMeasurement { get; set; }
        public virtual List<ApartmentsService> ApartmentsServices { get; set; }
        public virtual List<Measurement> Measurements { get; set; }
        public virtual List<Price> Prices { get; set; }
        public virtual List<InvoiceRow> InvoiceRows { get; set; }
    }
}
