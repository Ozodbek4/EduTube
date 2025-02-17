using EduTube.Domain.Common.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EduTube.Infrastructure.Persistence.Repositories;

public abstract class EntityRepositoryBase<TEntity, TContext>
    where TEntity : AuditableEntity
    where TContext : DbContext
{
    protected readonly DbContext DbContext;

    public EntityRepositoryBase(DbContext dbContext) =>
        DbContext = dbContext;

    protected IQueryable<TEntity> GetQueryable(
        Expression<Func<TEntity, bool>>? predicate = default,
        string[]? includes = default,
        bool asNoTracking = true
        )
    {
        var query = predicate is null
            ? DbContext.Set<TEntity>()
            : DbContext.Set<TEntity>().Where(predicate);

        if (includes is not null)
            foreach (var include in includes)
                query = query.Include(include);

        if (asNoTracking)
            query = query.AsNoTracking();

        return query;
    }

    protected async Task<IEnumerable<TEntity>> GetEnumerableAsync(
        Expression<Func<TEntity, bool>>? predicate = default,
        string[]? includes = default,
        bool asNoTracking = true,
        CancellationToken cancellationToken = default
        )
    {
        var query = predicate is null
            ? DbContext.Set<TEntity>()
            : DbContext.Set<TEntity>().Where(predicate);

        if (includes is not null)
            foreach (var include in includes)
                query = query.Include(include);

        if (asNoTracking)
            query = query.AsNoTracking();

        return await query.ToListAsync(cancellationToken);
    }

    protected async Task<TEntity?> GetAsync(
        Expression<Func<TEntity, bool>> predicate,
        string[]? includes = default,
        bool asNoTracking = true,
        CancellationToken cancellationToken = default)
    {
        var query = DbContext.Set<TEntity>().AsQueryable();

        if (includes is not null)
            foreach (var include in includes)
                query = query.Include(include);

        if (asNoTracking)
            query = query.AsNoTracking();

        return await query.FirstOrDefaultAsync(predicate, cancellationToken);
    }

    protected async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        var query = DbContext.Set<TEntity>();

        return (await query.AddAsync(entity, cancellationToken)).Entity;
    }

    protected Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        var query = DbContext.Set<TEntity>();

        return Task.FromResult(query.Update(entity).Entity);
    }

    protected Task<TEntity> RemoveAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        var query = DbContext.Set<TEntity>();

        return Task.FromResult(query.Remove(entity).Entity);
    }

    protected Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        DbContext.SaveChangesAsync(cancellationToken);
}