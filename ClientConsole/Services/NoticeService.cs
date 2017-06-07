using ClientConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientConsole.Services
{
    public class NoticeService : BaseService
    {
        //private readonly HttpClient _client;

        public NoticeService():base(ServiceConstants.NoticeServiceUrl) //Paneme uri paika juba konstruktoris, et seda ei peaks igal pool eraldi täpselt samamoodi tegema.
        {
            
        }
        public async Task<List<Notice>> GetAllNotices()
        {
            //var result = await base.GetData<Notice>("");
            //var responseMessage = await _client.GetAsync("");//GetAsync meetodile annab juurde lisada osa uri'st
            //List<Notice> allNotices = await responseMessage.Content.ReadAsAsync<List<Notice>>();
            //return allNotices;
            return await base.GetData<List<Notice>>("");
        }

        public async Task<Notice> GetNoticeById(int id)
        {
            //var responseMessage = await _client.GetAsync(id.ToString());
            //var responseContent = await responseMessage.Content.ReadAsStringAsync();
            //Notice notice = await responseMessage.Content.ReadAsAsync<Notice>();
            //return notice;
            return await base.GetData<Notice>(id.ToString());
        }

        public async Task<Notice> AddNewNotice(Notice notice)
        {
            return await base.PostData<Notice>("", notice);
        }
    }
}
