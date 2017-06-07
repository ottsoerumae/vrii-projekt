using BL.Services.PersonService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.Controllers.Api
{
    public class PeopleController : ApiController
    {
        private readonly IPersonService _personService;

        public PeopleController(IPersonService personService)
        {
            _personService = personService;
        }
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(_personService.GetAllPeople());
        }

        [HttpGet]
        public IHttpActionResult GetPersonById( int id)
        {
            return Ok(_personService.GetPersonById(id));
        }
    }
}
