using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Person
    {
        [Required]
        public int PersonId { get; set; }
        [Required]
        [MaxLength(64)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(64)]
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string IdentificationNumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string EMailAddress { get; set; }
        public string FirstAndLastName => FirstName + " " + LastName;
        public virtual List<Ownership> Ownerships { get; set; }
        public virtual List<Invoice> Invoices { get; set; }
        public virtual List<Board> Boards { get; set; }
    }
}
