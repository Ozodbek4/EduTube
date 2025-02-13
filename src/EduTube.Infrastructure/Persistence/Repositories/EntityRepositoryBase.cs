using EduTube.Domain.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduTube.Infrastructure.Persistence.Repositories;

public abstract class EntityRepositoryBase<TEntity, TContext>(DbContext dbContext)
    where TEntity : AuditableEntity
    where TContext : DbContext
{
    protected DbContext DbContext => dbContext;

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