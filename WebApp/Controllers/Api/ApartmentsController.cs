using BL.Services.ApartmentService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApp.Controllers.Api
{
    public class ApartmentsController : ApiController
    {
        public readonly IApartmentService _apartmentService;
        public ApartmentsController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }
        [HttpGet]
        public IHttpActionResult GetApartmentsByHouseId(int id)
        {
            return Ok(_apartmentService.GetApartmentsWithOwnersByHouseId(id));
        }
    }
}
