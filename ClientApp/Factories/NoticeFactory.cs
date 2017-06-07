using ClientApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Factories
{
    public class NoticeFactory
    {
        public Notice CreateNotice(int houseId, string noticeText, DateTime? fromDate, DateTime? toDate)
        {
            return new Notice()
            {
                HouseId = houseId,
                NoticeText = noticeText,
                FromDate = fromDate,
                ToDate = toDate
            };
        }
    }
}
