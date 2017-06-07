using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface INoticeRepository : IRepository<Notice>
    {
        List<Notice> GetNoticesByHouseId(int houseId);
        List<Notice> GetRelevantNoticesByHouseId(int houseId);

    }
}
