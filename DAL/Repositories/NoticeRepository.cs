using DAL.Repositories;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace DAL.Repositories
{
    public class NoticeRepository : Repository<Notice>, INoticeRepository
    {
        public NoticeRepository(ICooperationContext dbContext) : base(dbContext)
        {
        }

        public List<Notice> GetNoticesByHouseId(int houseId)
        {
            return RepositoryDbSet.Where(n => n.HouseId == houseId).ToList();
        }

        public List<Notice> GetRelevantNoticesByHouseId(int houseId)
        {
            return RepositoryDbSet.Where(n => n.HouseId == houseId
                                        && n.FromDate <= DateTime.Now
                                        && n.ToDate >= DateTime.Now)
                                        .ToList();
        }
    }
}
