using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Invoice
    {
        [Required]
        public int InvoiceId { get; set; }
        public int? PersonId { get; set; }
        public virtual Person Person { get; set; }
        [Required]
        public int InvoiceNo { get; set; }
        [Required]
        public DateTime IssueDate { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }
        [Required]
        public double InvoiceTotal { get; set; }
        public double ValueAddedTax { get; set; }
        public virtual List<InvoiceRow> InvoiceRows { get; set; }
       
        #region NotMapped
        public double InvoiceTotalPlusVAT {
            get { return InvoiceTotal + ValueAddedTax; }
        }
        #endregion
    }
}
