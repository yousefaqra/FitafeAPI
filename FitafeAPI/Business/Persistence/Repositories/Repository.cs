using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FitafeAPI.Business.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        public Repository(DbContext context)
        {
            Context = context;
        }

        public DbContext Context { get; private set; }

        public void BeginTransaction()
        {
            Context.Database.BeginTransaction();
        }

        public virtual void CommitTransaction()
        {
            Context.Database.CommitTransaction();
        }

        public virtual void RollBackTransaction()
        {
            Context.Database.RollbackTransaction();
        }

        public async Task BeginTransactionAsync()
        {
            await Context.Database.BeginTransactionAsync();
        }

        public virtual IQueryable<T> GetQueryable()
        {
            IQueryable<T> query = Context.Set<T>();
            return query;
        }

        public virtual void Add(
            T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public virtual void Delete(
            T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public virtual void Update(
            T entity)
        {
            Context.Set<T>().Update(entity);
        }

        public virtual void Save()
        {
            Context.SaveChanges();
        }

        public virtual async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }

        public async Task<T> FirstOrDefaultAsync(
            Expression<Func<T, bool>> exp)
        {
            return await GetQueryable().FirstOrDefaultAsync(exp);
        }

        public virtual T FirstOrDefault(
            Expression<Func<T, bool>> filter,
            Func<IQueryable<T>, IQueryable<T>> includes)
        {
            return GetQueryable()
                .ApplyFilter(filter)
                .ApplyIncludes(includes)
                .FirstOrDefault();
        }

        public virtual async Task<T[]> GetItemsAsync(IEnumerable<Expression<Func<T, bool>>> filters = null, IEnumerable<Expression<Func<T, object>>> includes = null)
        {
            var query = GetQueryable();

            return await query
                .ApplyFilters(filters)
                .ApplyIncludes(includes)
                .ToArrayAsync();
        }

        public async Task<T> FirstOrDefaultAsync(
            Expression<Func<T, bool>> exp,
            Func<IQueryable<T>, IQueryable<T>> includes)
        {
            return await GetQueryable()
                .ApplyIncludes(includes)
                .FirstOrDefaultAsync(exp);
        }
    }
}
