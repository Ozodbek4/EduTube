using EduTube.Domain.Common.Entities;

namespace EduTube.Domain.Entities;

public class User : AuditableEntity
{
    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public string UserName { get; set; } = default!;

    public UserCredentials? Credentials { get; set; }
}