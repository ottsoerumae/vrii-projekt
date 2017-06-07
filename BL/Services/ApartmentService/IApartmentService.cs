using BL.DTOs.ApartmentDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.ApartmentService
{
    public interface IApartmentService
    {
        List<ApartmentWithOwnerDTO> GetApartmentsWithOwnersByHouseId(int id);
    }
}
