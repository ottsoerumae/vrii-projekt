using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Apartment
    {
        [Required]
        public int ApartmentId { get; set; }
        public int? HouseId { get; set; } //Question mark means it's nullable
        public virtual House House { get; set; }
        [Required]
        public int ApartmentNo { get; set; }
        public int FloorNo { get; set; }
        public double Area { get; set; }
        public virtual List<Ownership> Ownerships { get; set; }
    }
}
