using Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>

        //See ütleb, et TEntity on klass ehk Reference type
        //muidu hakkab DbSet<TEntity> vinguma
        where TEntity : class 
    {
        //AB ühendused ei tohiks olla mitmes eri repos laiali lahti, seega avame 
        //siinkohal andmebaasiühenduse.
        protected DbContext RepositoryDbContext;
        //ja andmebaasi tabelit, millega parasjagu tegeletakse
        protected DbSet<TEntity> RepositoryDbSet;
        public Repository(ICooperationContext dbContext)
        {
            RepositoryDbContext = dbContext as DbContext;
            if (RepositoryDbContext == null)
            {
                throw new ArgumentNullException(paramName: nameof(dbContext));
            }

            RepositoryDbSet = RepositoryDbContext.Set<TEntity>();
            if (RepositoryDbSet == null)
            {
                throw new NullReferenceException(message: nameof(RepositoryDbSet));
            }
        }
        public List<TEntity> All
        {
            get
            {
                //Siin võiks ka päringule vastavate vastuste arvu kontrollida, et
                //juhul, kui see on liiga pikk, ei kui kirjeid on ilgelt palju, ei jooksutataks ab-d kokku
                var resCount = RepositoryDbSet.Count();
                if (resCount < 15)
                {
                    return RepositoryDbSet.ToList();
                }
                throw new Exception(message: "You ask too much!");
            }
        }

        public TEntity Find(int id)
        {
            return RepositoryDbSet.Find(id);
        }

        public void Remove(int id)
        {
            //ID järgi kustutamist pole olemas, kirjutame ise :D
            Remove(Find(id));
        }

        public TEntity Add(TEntity entity)
        {
            DbEntityEntry dbEntityEntry = RepositoryDbContext.Entry(entity: entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
                return entity;
            }
            return RepositoryDbSet.Add(entity: entity);
        }

        public void Remove(TEntity entity)
        {
            DbEntityEntry dbEntityEntry = RepositoryDbContext.Entry(entity: entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                RepositoryDbSet.Attach(entity: entity);
                RepositoryDbSet.Remove(entity: entity);
            }

        }

        public void Update(TEntity entity)
        {
            DbEntityEntry dbEntityEntry = RepositoryDbContext.Entry(entity: entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                RepositoryDbSet.Attach(entity: entity);
            }
            dbEntityEntry.State = EntityState.Modified;
        }

        public int SaveChanges()
        {
            return RepositoryDbContext.SaveChanges(); //Tagastab mitu kirjet muudeti.
        }
    }
}
