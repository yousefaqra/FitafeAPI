using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FitafeAPI.Business.Persistence.Repositories
{
    public static class RepositoryExtensions
    {
        public static IQueryable<TEntity> ApplyFilters<TEntity>(
            this IQueryable<TEntity> entities,
            IEnumerable<Expression<Func<TEntity, bool>>> filters)
        {
            return filters == null
                ? entities
                : filters.Aggregate(entities, (current, filter) => current.Where(filter));
        }

        public static IQueryable<TEntity> ApplyFilter<TEntity>(
            this IQueryable<TEntity> entities,
            Expression<Func<TEntity, bool>> filter)
        {
            if (filter != null)
            {
                entities = entities.Where(filter);
            }
            return entities;
        }

        public static IQueryable<TEntity> ApplyIncludes<TEntity>(
            this IQueryable<TEntity> entities,
            IEnumerable<Expression<Func<TEntity, object>>> includes)
            where TEntity : class, new()
        {
            return includes == null
                ? entities
                : includes.Aggregate(entities, (current, include) => current.Include(include));
        }

        public static IQueryable<TEntity> ApplyIncludes<TEntity>(
            this IQueryable<TEntity> entities,
            Func<IQueryable<TEntity>, IQueryable<TEntity>> includes)
            where TEntity : class, new()
        {
            if (includes != null)
            {
                entities = includes.Invoke(entities);
            }
            return entities;
        }

        public static IQueryable<TEntity> ApplyPaging<TEntity>(
            this IQueryable<TEntity> entities
           )
        {
            return entities;
        }
    }
}
