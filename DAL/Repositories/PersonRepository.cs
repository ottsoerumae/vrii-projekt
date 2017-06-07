using Domain;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    //           Mis nimi           Pärineb kust        Täidab mis interface'i
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        //Puudu oli ainult konstruktor
        public PersonRepository(ICooperationContext dbContext) : base(dbContext)
        {
                
        }
        public List<Person> GetOrderedRecords(int recordLimit, bool orderByFirstName = true)
        {
            var query = RepositoryDbSet.AsQueryable();

            query = orderByFirstName ? query
                .OrderBy(keySelector: a => a.FirstName) : query.OrderBy(keySelector: a => a.LastName);

            switch (recordLimit)
            {
                case 0:
                    break;
                default:
                    query = query.Take(count: recordLimit);
                    break;
            }

            return query.ToList();
        }
    }
}
