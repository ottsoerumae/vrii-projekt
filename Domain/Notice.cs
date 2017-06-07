using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Notice
    {
        [Required]
        public int NoticeId { get; set; }
        public int? HouseId { get; set; }
        public virtual House House { get; set; }
        [Required]
        [MaxLength(1024)]
        public string NoticeText { get; set; }
        [Required]
        public DateTime FromDate { get; set; }
        [Required]
        public DateTime ToDate { get; set; }
    }
}
