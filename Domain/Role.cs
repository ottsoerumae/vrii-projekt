using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Role
    {
        [Required]
        public int RoleId { get; set; }
        [Required]
        [MaxLength(64)]
        public string RoleName { get; set; }
        public virtual List<Board> Boards { get; set; }
    }
}
