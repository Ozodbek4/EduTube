namespace EduTube.Application.Abstractions.Security;

public interface IPasswordHasher
{
    Task<string> HashPassword(string password, CancellationToken cancellationToken = default);

    Task<bool> VerifyPassword(string hashedPassword, string providedPassword, CancellationToken cancellationToken = default);
}