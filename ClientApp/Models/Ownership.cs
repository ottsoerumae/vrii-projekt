using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Models
{
    //Vaata see klass üle! Pea meeles, et klass peab vastama BL-i DTO omaga, mitte ilmtingimata domeenimudeliga.
    public class Ownership
    {
        public int OwnershipId { get; set; }
        public int? ApartmentId { get; set; }
        public int? PersonId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
