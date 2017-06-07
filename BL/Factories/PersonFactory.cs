using BL.DTOs.PersonDTOs;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Factories
{
    public class PersonFactory
    {
        public PersonDTO CreatePerson(Person person)
        {
            return new PersonDTO()
            {
                PersonId = person.PersonId,
                FirstName = person.FirstName,
                LastName = person.LastName,
                DateOfBirth = person.DateOfBirth
            };
        }
    }
}
