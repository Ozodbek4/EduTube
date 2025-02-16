namespace EduTube.Application.Common.DTOs;

public class UserDto
{
    public long Id { get; set; }

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public string UserName { get; set; } = default!;
}