using BL.DTOs.NoticeDTOs;
using BL.Services.NoticeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApp.Controllers.Api
{
    public class NoticesController : ApiController
    {
        private readonly INoticeService _noticeService;

        public NoticesController(INoticeService noticeService)
        {
            _noticeService = noticeService;
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(_noticeService.GetAllNotices());
        }

        [HttpGet]
        public IHttpActionResult GetRelevantNotices(int id)
        {
            return Ok(_noticeService.GetRelevantNoticesByHouseId(id));
        }

        [HttpPost]
        public IHttpActionResult AddNewNotice([FromBody] NoticeDTO notice)
        {
            var ret = _noticeService.AddNewNotice(notice);
            return CreatedAtRoute("DefaultApi", new { id = ret.NoticeId }, ret);//Ei tea kas toimib, pole proovinud
        }
        //[HttpPost]
        //public IHttpActionResult Post([FromBody] PersonDTO person)
        //{
        //    var ret = _personService.AddNewPerson(person);
        //    return CreatedAtRoute("DefaultApi", new { id = ret.Id }, ret);
        //}
    }
}
