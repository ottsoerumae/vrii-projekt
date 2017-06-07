using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Models
{
    //Vaata see klass üle! Pea meeles, et klass peab vastama BL-i DTO omaga, mitte ilmtingimata domeenimudeliga.
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdentificationNumber { get; set; }
        public string EMail { get; set; }
    }
}
