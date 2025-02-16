using EduTube.Application.Abstractions.Persistence;
using EduTube.Domain.Entities;
using EduTube.Infrastructure.Persistence.Contexts;
using System.Linq.Expressions;

namespace EduTube.Infrastructure.Persistence.Repositories;

public sealed class UserRepository(AppDbContext context) : EntityRepositoryBase<User, AppDbContext>(context), IUserRepository
{
    public new Task<User?> GetAsync(
        Expression<Func<User, bool>> predicate,
        string[]? includes = default,
        bool asNoTracking = true,
        CancellationToken cancellationToken = default) =>
        base.GetAsync(predicate, includes, asNoTracking, cancellationToken);

    public new Task AddAsync(User user, CancellationToken cancellationToken = default) =>
        base.AddAsync(user, cancellationToken);

    public new Task UpdateAsync(User user, CancellationToken cancellationToken = default) =>
        base.UpdateAsync(user, cancellationToken);

    public new Task RemoveAsync(User user, CancellationToken cancellationToken = default) =>
        base.RemoveAsync(user, cancellationToken);
}