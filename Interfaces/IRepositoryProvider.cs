using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IRepositoryProvider
    {
        IRepository<TEntity> GetStandardRepo<TEntity>() where TEntity : class;
        TRepoInterface GetCustomRepo<TRepoInterface>();
    }
}
