using BL.DTOs.NoticeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.NoticeService
{
    public interface INoticeService
    {
        List<NoticeDTO> GetAllNotices();
        List<NoticeDTO> GetNoticesByHouseId(int id);
        List<NoticeDTO> GetRelevantNoticesByHouseId(int id); //(notices that have not gone off :D)
        NoticeDTO AddNewNotice(NoticeDTO noticeDto);
    }
}
