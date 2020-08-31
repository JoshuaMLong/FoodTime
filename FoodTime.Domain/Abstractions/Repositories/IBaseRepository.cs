using FoodTime.Infrastructure.Abstractions;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FoodTime.Infrastructure.Interfaces
{
    public interface IBaseRepository<T> where T : IAggregateRoot
    {
        T Create(T entity);
        void Delete(T entity);
        IQueryable<T> Get();
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        void SaveChanges();
        Task SaveChangesAsync();
        T Update(T entity);
    }
}