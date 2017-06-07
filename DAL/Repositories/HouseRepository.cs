using DAL.Repositories;
using Domain;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class HouseRepository : Repository<House>, IHouseRepository
    {
        public HouseRepository(ICooperationContext dbContext) : base(dbContext)
        {
        }
    }
}
