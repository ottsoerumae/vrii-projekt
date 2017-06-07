using ClientApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Services
{
    public class PersonService : BaseService
    {
        public PersonService() : base(ServiceConstants.PersonServiceUrl)
        {

        }

        public async Task<List<Person>> GetAllPeople()
        {
            return await base.GetData<List<Person>>("");
        }

        public async Task<Person> GetPersonById(int id)
        {
            return await base.GetData<Person>("");
        }
    }
}
