using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApp.Controllers.Api
{
    public class HousesController : ApiController
    {
        private static readonly List<string> Data = InitList();
        private static List<string> InitList()
        {
            return new List<string>()
            {
                "value1", "value2"
            };
        }

        [HttpGet]
        public IHttpActionResult GetData()
        {
            return Ok(Data);
        }
    }
}
