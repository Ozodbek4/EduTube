using System.ComponentModel.DataAnnotations;

namespace EduTube.Application.Common.DTOs.Users;

public class CreateUserDto
{
    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public string UserName { get; set; } = default!;

    public string Password { get; set; } = default!;
}