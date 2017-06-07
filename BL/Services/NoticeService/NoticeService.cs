using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using BL.DTOs.NoticeDTOs;
using Interfaces;
using BL.Factories;

namespace BL.Services.NoticeService
{
    public class NoticeService : INoticeService
    {
        private readonly INoticeRepository _noticeRepository;
        private readonly NoticeFactory _noticeFactory;

        public NoticeService(INoticeRepository noticeRepository, NoticeFactory noticeFactory)
        {
            _noticeRepository = noticeRepository;
            _noticeFactory = noticeFactory;
        }
        public List<NoticeDTO> GetAllNotices()
        {
            var notices = _noticeRepository.All;
            return notices.Select(notice => _noticeFactory.CreateNotice(notice)).ToList();
        }

        //avoid using ...Repository.All everywhere!!!
        public List<NoticeDTO> GetNoticesByHouseId(int id)
        {
            var notices = _noticeRepository.GetNoticesByHouseId(id);
            return notices.Select(notice => _noticeFactory.CreateNotice(notice)).ToList();
        }

        //avoid using ...Repository.All everywhere!!!
        public List<NoticeDTO> GetRelevantNoticesByHouseId(int id)
        {
            var notices = _noticeRepository.GetRelevantNoticesByHouseId(id);
            return notices.Select(notice => _noticeFactory.CreateNotice(notice)).ToList();
        }

        public NoticeDTO AddNewNotice(NoticeDTO noticeDto)
        {
            var domaninNotice = _noticeFactory.CreateDomainNotice(noticeDto);
            var ret = _noticeRepository.Add(domaninNotice);
            _noticeRepository.SaveChanges();
            return _noticeFactory.CreateNotice(ret);//Saame viite domeeniobjektile, siis ei ole lihtsalt valmis vaid ka ab-sse lisatud.
        }
    }
}
