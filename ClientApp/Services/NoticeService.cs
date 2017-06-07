using ClientApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Services
{
    public class NoticeService : BaseService
    {
        public NoticeService() : base(ServiceConstants.NoticeServiceUrl) //Paneme uri paika juba konstruktoris, et seda ei peaks igal pool eraldi täpselt samamoodi tegema.
        {

        }
        //Method, that returns a list of notices by HouseId
        public async Task<List<Notice>> GetRelevantNoticesByHouseId( int houseId)
        {
            return await base.GetData<List<Notice>>(houseId.ToString());
        }

        public async Task<Notice> GetNoticeById(int id)
        {
            return await base.GetData<Notice>(id.ToString());
        }
        public async Task<Notice> AddNewNotice(Notice notice)
        {
            return await base.PostData<Notice>("", notice);
        }
    }
}
