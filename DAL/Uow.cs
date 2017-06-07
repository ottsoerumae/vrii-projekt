using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.Data.Entity;
using DAL.Repositories;

namespace DAL
{
    public class Uow : IUow
    {
        private readonly ICooperationContext _cooperationContext;
        private readonly IRepositoryProvider _repositoryProvider;
        public Uow(ICooperationContext cooperationContext, IRepositoryProvider repositoryProvider)
        {
            _cooperationContext = cooperationContext;
            _repositoryProvider = repositoryProvider;
        }
        //repo peaks enda andmeallika saama CooperationContextist
        //Kahte eri tyypi repod: standardsed ja custom
        public IRepository<Apartment> Apartments => GetStandardRepo<Apartment>(); //=> new Repository<Apartment>(_cooperationContext); //Experssion body teeb sama, mis get, aga on teistmoodi kirjutatud.
        public IRepository<House> Houses => GetStandardRepo<House>();
        public IOwnershipRepository Ownerships => GetCustomRepo<IOwnershipRepository>(); //Tegelikult me kunagi ei saa tagastada Interface'i
        public IPersonRepository People => GetCustomRepo<IPersonRepository>();

        //Järgnetate meetodite olemasolu on vajalik selleks, et teada, kas repo on olemas (kas kasutame teda essat korda) või mitte, et me ei avaks seda iga kord uuesti. Seda kontrollime RepositoryProvideri klassi meetodis.
        private IRepository<TEntity> GetStandardRepo<TEntity>() where TEntity : class
        {
            return _repositoryProvider.GetStandardRepo<TEntity>();
        }

        private TRepoInterface GetCustomRepo<TRepoInterface>()
        {
            return _repositoryProvider.GetCustomRepo<TRepoInterface>();
        }
        

        public int SaveChanges()
        {
            return ((DbContext) _cooperationContext).SaveChanges();
        }
    }
}
