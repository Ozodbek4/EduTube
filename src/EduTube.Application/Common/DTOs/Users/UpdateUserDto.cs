namespace EduTube.Application.Common.DTOs.Users;

public class UpdateUserDto
{
    public long Id { get; set; }

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;
}