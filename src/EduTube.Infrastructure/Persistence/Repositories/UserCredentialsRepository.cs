using EduTube.Application.Abstractions.Persistence;
using EduTube.Domain.Entities;
using EduTube.Infrastructure.Persistence.Contexts;

namespace EduTube.Infrastructure.Persistence.Repositories;

public class UserCredentialsRepository(AppDbContext context) : EntityRepositoryBase<UserCredentials, AppDbContext>(context), IUserCredentialsRepository
{
    public new Task<UserCredentials> AddAsync(UserCredentials credentials, CancellationToken cancellationToken = default) =>
        base.AddAsync(credentials, cancellationToken);

    public new Task<UserCredentials> UpdateAsync(UserCredentials credentials, CancellationToken cancellationToken = default) =>
        base.UpdateAsync(credentials, cancellationToken);

    public new Task<UserCredentials> RemoveAsync(UserCredentials credentials, CancellationToken cancellationToken = default) =>
        base.RemoveAsync(credentials, cancellationToken);

    public new Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        base.SaveChangesAsync(cancellationToken);
}