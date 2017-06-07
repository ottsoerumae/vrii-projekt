using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs.ApartmentDTOs
{
    public class ApartmentWithOwnerDTO
    {
        public int ApartmentNo { get; set; }
        public double Area { get; set; }
        public string OwnersName { get; set; }
    }
}
