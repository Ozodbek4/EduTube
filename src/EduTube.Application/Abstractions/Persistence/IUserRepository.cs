using EduTube.Domain.Entities;

namespace EduTube.Application.Abstractions.Persistence;

public interface IUserRepository
{
    Task AddAsync(User user, CancellationToken cancellationToken = default);

    Task UpdateAsync(User user, CancellationToken cancellationToken = default);

    Task RemoveAsync(User user, CancellationToken cancellationToken = default);
}