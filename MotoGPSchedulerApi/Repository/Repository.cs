using Microsoft.EntityFrameworkCore;
using MotoGPSchedulerApi.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace MotoGPSchedulerApi.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly ApplicationContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public Repository(ApplicationContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicado)
        {
            return entities.Where(predicado);
        }

        public IQueryable<T> GetAll()
        {
            return entities;
        }

        public T Get(Int64 id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Insert entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Update entity");
            }
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Delete entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}
