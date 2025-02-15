using EduTube.Application.Abstractions.Security;
using BC = BCrypt.Net.BCrypt;

namespace EduTube.Infrastructure.Identity.Security;

public class PasswordHasher : IPasswordHasher
{
    public Task<string> HashPassword(string password, CancellationToken cancellationToken = default) =>
        Task.FromResult(BC.HashPassword(password));

    public Task<bool> VerifyPassword(string hashedPassword, string providedPassword, CancellationToken cancellationToken = default) =>
        Task.FromResult(BC.Verify(providedPassword, hashedPassword));
}