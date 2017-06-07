using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IRepositoryFactories
    {
        Func<ICooperationContext, object> GetStandardRepositoryFactory<TEntity>() where TEntity : class;
        Func<ICooperationContext, object> GetCustomRepositoryFactory<TRepoInterface>();
    }
}
