using EduTube.Domain.Entities;
using System.Linq.Expressions;

namespace EduTube.Application.Abstractions.Persistence;

public interface IUserRepository
{
    Task<User?> GetAsync(
        Expression<Func<User, bool>> predicate,
        string[]? includes = default,
        bool asNoTracking = true,
        CancellationToken cancellationToken = default
        );

    Task AddAsync(User user, CancellationToken cancellationToken = default);

    Task UpdateAsync(User user, CancellationToken cancellationToken = default);

    Task RemoveAsync(User user, CancellationToken cancellationToken = default);
}