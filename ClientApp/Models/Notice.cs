using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Models
{
    public class Notice
    {
        public int NoticeId { get; set; }
        public int? HouseId { get; set; }//Äkki vaja muuta nullableks
        public string NoticeText { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
