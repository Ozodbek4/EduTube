using EduTube.Domain.Entities;

namespace EduTube.Application.Abstractions.Persistence;

public interface IUserCredentialsRepository
{
    Task AddAsync(UserCredentials credentials, CancellationToken cancellationToken = default);

    Task UpdateAsync(UserCredentials credentials, CancellationToken cancellationToken = default);

    Task RemoveAsync(UserCredentials credentials, CancellationToken cancellationToken = default);
}