using EduTube.Application.Common.Models;
using EduTube.Domain.Entities;
using System.Linq.Expressions;

namespace EduTube.Application.Abstractions.Persistence;

public interface IUserRepository
{
    IQueryable<User> GetQueryable(
        Expression<Func<User, bool>>? predicate = default,
        string[]? includes = default,
        bool asNoTracking = true
        );

    Task<IEnumerable<User>> GetEnumerableAsync(
        Expression<Func<User, bool>>? predicate = default,
        string[]? includes = default,
        bool asNoTracking = true,
        CancellationToken cancellationToken = default
        );

    Task<User?> GetAsync(
        Expression<Func<User, bool>> predicate,
        string[]? includes = default,
        bool asNoTracking = true,
        CancellationToken cancellationToken = default
        );

    Task<User> AddAsync(User user, CancellationToken cancellationToken = default);

    Task<User> UpdateAsync(User user, CancellationToken cancellationToken = default);

    Task<User> RemoveAsync(User user, CancellationToken cancellationToken = default);

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}