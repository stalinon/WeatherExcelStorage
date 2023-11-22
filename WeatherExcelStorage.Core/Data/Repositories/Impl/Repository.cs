using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Scraper.Common.Enums;

namespace Scraper.Common.Database.Impl
{
    /// <inheritdoc />
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        /// <summary>
        /// Контекст БД
        /// </summary>
        protected virtual BaseDbContext DbContext { get; }

        protected DbSet<T> _dbSet;

        /// <summary>
        /// Название таблицы
        /// </summary>
        protected static readonly string? TableName = typeof(T).GetCustomAttributes(true)
            .OfType<TableAttribute>()
            .FirstOrDefault()?.Name;

        /// <inheritdoc cref="Repository{T}"/>
        protected Repository(BaseDbContext dbContext)
        {
            DbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        /// <inheritdoc />
        public virtual IQueryable<T> CreateQuery(Expression<Func<T, bool>>? filter = null) => filter == null
            ? _dbSet.AsQueryable()
            : _dbSet.AsQueryable().Where(filter);

        /// <inheritdoc />
        public virtual async Task<T[]> GetAllAsync(
            Expression<Func<T, bool>>? filter = null,
            Expression<Func<T, object>>? sort = null,
            ColumnSortType sortDirection = ColumnSortType.Ascending,
            CancellationToken cancellationToken = default)
        {
            var query = CreateQuery(filter);
            if (sort != null)
            {
                query = sortDirection switch
                {
                    ColumnSortType.Ascending => query.OrderBy(sort),
                    ColumnSortType.Descending => query.OrderByDescending(sort),
                    _ => throw new ArgumentOutOfRangeException()
                };
            }

            return await query.ToArrayAsync(cancellationToken);
        }

        /// <inheritdoc />
        public virtual async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>>? filter = null, CancellationToken cancellationToken = default) =>
            await CreateQuery(filter).FirstOrDefaultAsync(cancellationToken);

        /// <inheritdoc />
        public virtual void Add(T entity) => _dbSet.Add(entity);

        /// <inheritdoc />
        public virtual async Task AddAsync(T entity, CancellationToken cancellationToken = default) =>
            await _dbSet.AddAsync(entity, cancellationToken);

        /// <inheritdoc />
        public virtual async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default) =>
            await _dbSet.AddRangeAsync(entities, cancellationToken);

        /// <inheritdoc />
        public virtual void Remove(T entity) => _dbSet.Remove(entity);

        /// <inheritdoc />
        public virtual void RemoveRange(T[] entities) => _dbSet.RemoveRange(entities);

        /// <inheritdoc />
        public virtual IQueryable<T> NoTracking() =>
            _dbSet.AsNoTracking();

        /// <inheritdoc />
        public virtual async Task SaveChangesAsync(CancellationToken cancellationToken = default) =>
            await DbContext.SaveChangesAsync(cancellationToken);
    }
}
