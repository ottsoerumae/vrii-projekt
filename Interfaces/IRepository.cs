using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IRepository<TEntity>
    {
        //Siin sees publicut ei kirjuta, kõik niigi public

        //Kõik kirjed
        List<TEntity> All { get; }
        //Kirje ID järgi
        TEntity Find(int id);
        void Remove(int id);
        void Remove(TEntity entity);
        TEntity Add(TEntity entity);
        void Update(TEntity entity);
        int SaveChanges();
    }
}
