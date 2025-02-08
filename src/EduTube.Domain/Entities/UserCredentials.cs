using EduTube.Domain.Common.Entities;

namespace EduTube.Domain.Entities;

public class UserCredentials : AuditableEntity
{
    public long UserId { get; set; }
    public User User { get; set; } = default!;

    public string PasswordHash { get; set; } = default!;
}