using FoodTime.API.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.API.Data.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public BaseRepository(FoodTimeContext ctx)
        {
            Ctx = ctx;
            workingSet = Ctx.Set<T>();
        }
        private DbSet<T> workingSet;
        protected FoodTimeContext Ctx { get; }

        public IQueryable<T> Get()
        {
            return workingSet;
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return workingSet.Where(predicate);
        }

        public T Create(T entity)
        {
            return workingSet.Add(entity).Entity;
        }

        public T Update(T entity)
        {
            Ctx.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public void Delete(T entity)
        {
            workingSet.Remove(entity);
        }

        public void SaveChanges()
        {
            Ctx.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await Ctx.SaveChangesAsync();
        }

    }
}
