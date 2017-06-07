using BL.DTOs.ApartmentDTOs;
using Domain;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Factories
{
    public class ApartmentFactory
    {
        public ApartmentDTO CreateApartmentWithHouse(Apartment apartment)
        {
            return new ApartmentDTO()
            {
                Street = apartment.House.Street,
                HouseNo = apartment.House.HouseNo,
                ApartmentNo = apartment.ApartmentNo,
                Area = apartment.Area
            };
        }

        public ApartmentWithOwnerDTO CreateApartmentWithOwner(Apartment apartment)
        {
            return new ApartmentWithOwnerDTO()
            {
                ApartmentNo = apartment.ApartmentNo,
                Area = apartment.Area,
                OwnersName = apartment.Ownerships
                                      .Where(ownership => ownership.ToDate >= DateTime.Today)
                                      .Select(p => p.Person.FirstAndLastName)
                                      .FirstOrDefault()
            };
        }
    }
}
