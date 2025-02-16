using EduTube.Domain.Common.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EduTube.Infrastructure.Persistence.Repositories;

public abstract class EntityRepositoryBase<TEntity, TContext>(DbContext dbContext)
    where TEntity : AuditableEntity
    where TContext : DbContext
{
    protected DbContext DbContext => dbContext;

    public async Task<TEntity?> GetAsync(
        Expression<Func<TEntity, bool>> predicate,
        string[]? includes = default,
        bool asNoTracking = true,
        CancellationToken cancellationToken = default)
    {
        var initialQuery = DbContext.Set<TEntity>().AsQueryable();

        if (includes is not null)
            foreach (var include in includes)
                initialQuery = initialQuery.Include(include);

        if (asNoTracking)
            initialQuery = initialQuery.AsNoTracking();

        return await initialQuery.FirstOrDefaultAsync(predicate);
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        var initialQuery = DbContext.Set<TEntity>();

        await initialQuery.AddAsync(entity, cancellationToken);
    }

    public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        var initialQuery = DbContext.Set<TEntity>();

        initialQuery.Update(entity);

        return Task.CompletedTask;
    }

    public Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        var initialQuery = DbContext.Set<TEntity>();

        initialQuery.Remove(entity);

        return Task.CompletedTask;
    }
}