using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity: class
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetByID(int id);

        bool Add(TEntity entity);

        bool Remove(TEntity entity);
    }
}
