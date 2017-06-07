using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientConsole.Services
{
    public class BaseService
    {
        protected HttpClient client;

        public BaseService(string uri)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(uri);
        }

        protected async Task<T> GetData<T>(string urlPath)//generic tüüpi meetod
        {
            var responseMessage = await client.GetAsync(urlPath);//GetAsync meetodile annab juurde lisada osa uri'st
            T ret = await responseMessage.Content.ReadAsAsync<T>();
            return ret;
        }

        protected async Task<T> PostData<T>(string urlPath, T obj)
        {
            var response = await client.PostAsJsonAsync<T>(urlPath, obj);
            return await response.Content.ReadAsAsync<T>();
        }
    }
}
