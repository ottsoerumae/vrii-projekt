using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Models
{
    //Vaata see klass üle! Pea meeles, et klass peab vastama BL-i DTO omaga, mitte ilmtingimata domeenimudeliga.
    public class Apartment
    {
        public int ApartmentId { get; set; }
        public int? HouseId { get; set; }
        public int ApartmentNo { get; set; }
        public int FloorNo { get; set; }
        public double Area { get; set; }
    }
}
