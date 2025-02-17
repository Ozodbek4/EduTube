using EduTube.Application.Common.Models;
using EduTube.Domain.Entities;
using System.Linq.Expressions;

namespace EduTube.Application.Abstractions.Persistence;

public interface IUserRepository
{
    IQueryable<User> GetQueryable(
        Expression<Func<User, bool>> predicate,
        string[]? includes = default,
        bool asNoTracking = true
        ); 

    Task<PaginationResult<User>> GetEnumerableAsync(
        Expression<Func<User, bool>>? predicate = default,
        PaginationParameters? pagination = default,
        SortingParameters? sorting = default,
        string? search = null,
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

    Task AddAsync(User user, CancellationToken cancellationToken = default);

    Task UpdateAsync(User user, CancellationToken cancellationToken = default);

    Task RemoveAsync(User user, CancellationToken cancellationToken = default);
}