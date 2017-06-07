using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace DAL.Repositories
{
    public class ApartmentRepository : Repository<Apartment>, IApartmentRepository
    {
        public ApartmentRepository(ICooperationContext dbContext) : base(dbContext)
        {
        }

        public List<Apartment> GetApartmentsByHouseId(int houseId)
        {
            return RepositoryDbSet.Where(a => a.HouseId == houseId).ToList();
        }
    }
}
