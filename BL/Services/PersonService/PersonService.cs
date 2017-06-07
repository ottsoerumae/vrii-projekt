using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Interfaces;
using BL.Factories;
using BL.DTOs.PersonDTOs;

namespace BL.Services.PersonService
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly PersonFactory _personFactory;
        public PersonService(IPersonRepository personRepository, PersonFactory personFactory)
        {
            _personRepository = personRepository;
            _personFactory = personFactory;
        }
        public List<PersonDTO> GetAllPeople()
        {
            var people = _personRepository.All;
            return people.Select(person => _personFactory.CreatePerson(person)).ToList();
        }

        public PersonDTO GetPersonById(int id)
        {
            var person = _personRepository.Find(id);
            return _personFactory.CreatePerson(person);
        }

        public void RemovePersonById(int id)
        {
            _personRepository.Remove(id);            
        }

        //public PersonDTO AddPerson()
        //{
        //    return null;
        //}

    }
}
