using Domain;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IApartmentRepository : IRepository<Apartment>
    {
        List<Apartment> GetApartmentsByHouseId(int houseId);
    }
}
