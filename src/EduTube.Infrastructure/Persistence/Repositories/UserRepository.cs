using EduTube.Application.Abstractions.Persistence;
using EduTube.Domain.Entities;
using EduTube.Infrastructure.Persistence.Contexts;
using System.Linq.Expressions;

namespace EduTube.Infrastructure.Persistence.Repositories;

public sealed class UserRepository(AppDbContext context) : EntityRepositoryBase<User, AppDbContext>(context), IUserRepository
{
    public new IQueryable<User> GetQueryable(Expression<Func<User, bool>>? predicate, string[]? includes, bool asNoTracking) =>
        base.GetQueryable(predicate, includes, asNoTracking);

    public new Task<IEnumerable<User>> GetEnumerableAsync(
        Expression<Func<User, bool>>? predicate,
        string[]? includes, bool asNoTracking,
        CancellationToken cancellationToken
        ) =>
        base.GetEnumerableAsync(predicate, includes, asNoTracking, cancellationToken);

    public new Task<User?> GetAsync(
        Expression<Func<User, bool>> predicate,
        string[]? includes,
        bool asNoTracking,
        CancellationToken cancellationToken
        ) =>
        base.GetAsync(predicate, includes, asNoTracking, cancellationToken);

    public new Task<User> AddAsync(User user, CancellationToken cancellationToken) =>
        base.AddAsync(user, cancellationToken);

    public new Task<User> UpdateAsync(User user, CancellationToken cancellationToken) =>
        base.UpdateAsync(user, cancellationToken);

    public new Task<User> RemoveAsync(User user, CancellationToken cancellationToken) =>
        base.RemoveAsync(user, cancellationToken);

    public new async Task<int> SaveChangesAsync(CancellationToken cancellationToken) =>
        await base.SaveChangesAsync(cancellationToken);
}