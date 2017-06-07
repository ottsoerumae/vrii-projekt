using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum Gender
    {
        //The following is written according to standard ISO/IEC 5218:
        NotKnown = 0,
        Male = 1,
        Female = 2,
        NotApplicable = 9
    }
}
