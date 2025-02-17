using EduTube.Application.Abstractions.Persistence;
using EduTube.Application.Common.Extensions;
using EduTube.Application.Common.Models;
using EduTube.Domain.Entities;
using EduTube.Infrastructure.Common.Extensions;
using EduTube.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
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

    public Task<PaginationResult<User>> GetEnumerableAsync(
        Expression<Func<User, bool>>? predicate = null,
        PaginationParameters? pagination = null,
        SortingParameters? sorting = null,
        string? search = null,
        string[]? includes = null,
        bool asNoTracking = true,
        CancellationToken cancellationToken = default)
    {
        var initialQuery = predicate is null
            ? DbContext.Set<User>() : DbContext.Set<User>().Where(predicate);

        if (search is not null)
            initialQuery = initialQuery.Where(entity => entity.FirstName.ToLower().Contains(search.ToLower())
                || entity.LastName.ToLower().Contains(search.ToLower())
                || entity.UserName.ToLower().Contains(search.ToLower()));

        initialQuery = initialQuery
            .SortBy(sorting)
            .IncludeIf(includes);

        if (asNoTracking)
            initialQuery = initialQuery.AsNoTracking();

        return Task.FromResult(initialQuery.ToPaginate(pagination));
    }
}