using MotoGPSchedulerApi.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace MotoGPSchedulerApi.Repository
{
    public interface IRepository<T> where T : BaseModel
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicado);
        IQueryable<T> GetAll();
        T Get(long id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
