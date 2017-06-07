using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Helpers
{
    public class RepositoryProvider : IRepositoryProvider
    {
        private readonly ICooperationContext _cooperationContext;
        private readonly IRepositoryFactories _repositoryFactories;
        public RepositoryProvider(ICooperationContext cooperationContext, IRepositoryFactories repositoryFactories)
        {
            _cooperationContext = cooperationContext; //Vaja veel teada, kas on varem olemas või mitte. 
            _repositoryFactories = repositoryFactories;
        }

        //Kontrollime, kas repo on olemas või mitte.
        protected Dictionary<Type, object> Repositories { get; } = new Dictionary<Type, object>();

        public IRepository<TEntity> GetStandardRepo<TEntity>() where TEntity : class
        {
            return GetRepository<IRepository<TEntity>>(
                _repositoryFactories.GetStandardRepositoryFactory<TEntity>());
        }

        public TRepoInterface GetCustomRepo<TRepoInterface>()
        {
            return GetRepository<TRepoInterface>(
                _repositoryFactories.GetCustomRepositoryFactory<TRepoInterface>());
        }

        private TRepository GetRepository<TRepository>(Func<ICooperationContext, object> factory)
        {
            object repositoryObject;
            Repositories.TryGetValue(typeof(TRepository), out repositoryObject);
            if (repositoryObject != null)
            {
                return (TRepository) repositoryObject;
            }
            return MakeRepository<TRepository>(factory, _cooperationContext);
        }
        private TRepository MakeRepository<TRepository>(Func<ICooperationContext, object> factory, ICooperationContext cooperationContext)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("What Terrible Failure!!! The Factory is missing!");
            }
            var repo = (TRepository)factory(cooperationContext);
            Repositories[typeof(TRepository)] = repo;
            return repo;
        }
    }
}
