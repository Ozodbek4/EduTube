using EduTube.Domain.Entities;

namespace EduTube.Application.Abstractions.Security;

public interface ITokenGeneratorService
{
    Task<string> GenerateTokenAsync(User user, CancellationToken cancellationToken = default);
}