using Microsoft.EntityFrameworkCore;
using OnlineShopping.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShopping.Repositories.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public DbContext Context { get; private set; }

        public Repository(DbContext context)
        {
            Context = context;
        }

        public virtual bool? Add(TEntity entity)
        {
            if (entity != null)
            {
                Context.Set<TEntity>().Add(entity);
                return true;
            }

            return false;
        }
        
        public IEnumerable<TEntity> GetAll()
        {
            //return Context.Set<TEntity>();
            return Context.Set<TEntity>().AsEnumerable().ToList();
        }

        public TEntity GetByID(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public virtual bool? Remove(TEntity entity)
        {
            if (entity != null)
            {
                Context.Set<TEntity>().Remove(entity);
                return true;
            }

            return false;
        }

        //public virtual IEnumerable<TEntity> Search(BaseCriteria baseCriteria)
        //{ return null; }

    }
}
