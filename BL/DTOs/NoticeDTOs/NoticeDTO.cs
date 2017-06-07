using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs.NoticeDTOs
{
    public class NoticeDTO
    {
        public int NoticeId { get; set; }
        public int? HouseId { get; set; }
        public string NoticeText { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
