using EduTube.Domain.Entities;

namespace EduTube.Application.Abstractions.Persistence;

public interface IUserCredentialsRepository
{
    Task<UserCredentials> AddAsync(UserCredentials userCredentials, CancellationToken cancellationToken = default);

    Task<UserCredentials> UpdateAsync(UserCredentials userCredentials, CancellationToken cancellationToken = default);

    Task<UserCredentials> RemoveAsync(UserCredentials userCredentials, CancellationToken cancellationToken = default);

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}