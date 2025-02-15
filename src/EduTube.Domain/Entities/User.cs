using EduTube.Domain.Common.Entities;
using EduTube.Domain.Enums;

namespace EduTube.Domain.Entities;

public class User : AuditableEntity
{
    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public string UserName { get; set; } = default!;

    public UserRole Role { get; set; }

    public UserCredentials? Credentials { get; set; }
}