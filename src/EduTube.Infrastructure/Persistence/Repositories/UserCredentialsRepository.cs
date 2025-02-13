using EduTube.Application.Abstractions.Persistence;
using EduTube.Domain.Entities;
using EduTube.Infrastructure.Persistence.Contexts;

namespace EduTube.Infrastructure.Persistence.Repositories;

public class UserCredentialsRepository(AppDbContext context) : EntityRepositoryBase<UserCredentials, AppDbContext>(context), IUserCredentialsRepository
{
    public new Task AddAsync(UserCredentials credentials, CancellationToken cancellationToken = default) =>
        base.AddAsync(credentials, cancellationToken);

    public new Task UpdateAsync(UserCredentials credentials, CancellationToken cancellationToken = default) =>
        base.UpdateAsync(credentials, cancellationToken);

    public new Task RemoveAsync(UserCredentials credentials, CancellationToken cancellationToken = default) =>
        base.RemoveAsync(credentials, cancellationToken);
}