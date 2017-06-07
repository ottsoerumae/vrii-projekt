using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IPersonRepository : IRepository<Person>
    {
        //Kogu custom funktsionaalsus läheb siia alla, nt meetod GetAllOrderedByAge vms, kuna kõigis repodes seda vaja pole, see sõltub präägasest olemist
        // Vt lisa echo360.e-ope.ee/ess/echo/presentation/6f06fae9-dd26-4a73-b537-3029421bbc0f?ec=true alates 46 minutist
        List<Person> GetOrderedRecords(int recordLimit, bool orderByFirstName = true);
    }
}
