using BL.DTOs.NoticeDTOs;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Factories
{
    public class NoticeFactory
    {
        public NoticeDTO CreateNotice(Notice notice)
        {
            return new NoticeDTO()
            {
                NoticeId = notice.NoticeId,
                HouseId = notice.HouseId,
                NoticeText = notice.NoticeText,
                FromDate = notice.FromDate,
                ToDate = notice.ToDate,
            };
        }

        public Notice CreateDomainNotice(NoticeDTO dto)
        {
            return new Notice()
            {
                NoticeId = dto.NoticeId,
                HouseId = dto.HouseId,
                NoticeText = dto.NoticeText,
                FromDate = dto.FromDate,
                ToDate = dto.ToDate
            };
        }
    }
}
