using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Models
{
    //Vaata see klass üle! Pea meeles, et klass peab vastama BL-i DTO omaga, mitte ilmtingimata domeenimudeliga.
    public class House
    {
        public int HouseId { get; set; }
        public string County { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNo { get; set; }
        public int ZipCode { get; set; }
    }
}
