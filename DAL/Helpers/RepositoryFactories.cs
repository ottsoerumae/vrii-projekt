using DAL.Repositories;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Helpers
{
    public class RepositoryFactories : IRepositoryFactories
    {
        // list all your custom repos here - match interfaces with real classes
        // dictionary of func, key is the type
        private static readonly Dictionary<Type, Func<ICooperationContext, object>> CustomRepositoryFactories
            = new Dictionary<Type, Func<ICooperationContext, object>>()
            {
                { typeof(IPersonRepository), dataContext => new PersonRepository(dataContext)},
                { typeof(IOwnershipRepository), dataContext => new OwnershipRepository(dataContext)}
            };

        public Func<ICooperationContext, object> GetStandardRepositoryFactory<TEntity>() where TEntity : class
        {
            return dataContext => new Repository<TEntity>(dataContext);
        }
        public Func<ICooperationContext, object> GetCustomRepositoryFactory<TRepoInterface>()
        {
            Func<ICooperationContext, object> customRepositoryFactory;
            CustomRepositoryFactories.TryGetValue(typeof(TRepoInterface), out customRepositoryFactory);
            return customRepositoryFactory;
        }

    }
}
