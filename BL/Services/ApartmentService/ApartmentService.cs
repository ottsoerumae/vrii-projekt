using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using BL.DTOs.ApartmentDTOs;
using Interfaces;
using BL.Factories;

namespace BL.Services.ApartmentService
{
    public class ApartmentService : IApartmentService
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly ApartmentFactory _apartmentFactory;

        public ApartmentService(IApartmentRepository apartmentRepository,
                                ApartmentFactory apartmentFactory)
        {
            _apartmentRepository = apartmentRepository;
            _apartmentFactory = apartmentFactory;
        }
        public List<ApartmentWithOwnerDTO> GetApartmentsWithOwnersByHouseId(int id)
        {
            return _apartmentRepository.GetApartmentsByHouseId(id)
                                       .Select(apartment => _apartmentFactory.CreateApartmentWithOwner(apartment))
                                       .OrderBy(apartmentDTO => apartmentDTO.ApartmentNo)
                                       .ToList();
        }
    }
}
