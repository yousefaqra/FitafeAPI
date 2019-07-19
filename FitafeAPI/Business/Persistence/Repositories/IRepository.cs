using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FitafeAPI.Business.Persistence.Repositories
{
    public interface IRepository<T> where T : class, new()
    {
        void BeginTransaction();

        void CommitTransaction();

        void RollBackTransaction();

        Task BeginTransactionAsync();

        IQueryable<T> GetQueryable();

        void Add(
            T entity);

        void Delete(
            T entity);

        void Update(
            T entity);

        void Save();

        Task SaveAsync();

        Task<T> FirstOrDefaultAsync(
            Expression<Func<T, bool>> exp);

        Task<T> FirstOrDefaultAsync(
            Expression<Func<T, bool>> exp,
            Func<IQueryable<T>, IQueryable<T>> includes);

        T FirstOrDefault(
            Expression<Func<T, bool>> filter,
            Func<IQueryable<T>, IQueryable<T>> includes);

        Task<T[]> GetItemsAsync(
            IEnumerable<Expression<Func<T, bool>>> filters = null,
            IEnumerable<Expression<Func<T, object>>> includes = null);
    }
}
