using BL.DTOs.PersonDTOs;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.PersonService
{
    public interface IPersonService
    {
        List<PersonDTO> GetAllPeople();
        PersonDTO GetPersonById(int id);
    }
}
