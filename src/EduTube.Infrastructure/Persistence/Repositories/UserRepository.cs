using EduTube.Application.Abstractions.Persistence;
using EduTube.Domain.Entities;
using EduTube.Infrastructure.Persistence.Contexts;

namespace EduTube.Infrastructure.Persistence.Repositories;

public sealed class UserRepository(AppDbContext context) : EntityRepositoryBase<User, AppDbContext>(context), IUserRepository
{
    public new Task AddAsync(User user, CancellationToken cancellationToken = default) =>
        base.AddAsync(user, cancellationToken);

    public new Task UpdateAsync(User user, CancellationToken cancellationToken = default) =>
        base.UpdateAsync(user, cancellationToken);

    public new Task RemoveAsync(User user, CancellationToken cancellationToken = default) =>
        base.RemoveAsync(user, cancellationToken);
}