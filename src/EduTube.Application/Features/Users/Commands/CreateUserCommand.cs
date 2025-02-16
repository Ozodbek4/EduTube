using EduTube.Application.Abstractions.Messaging;
using EduTube.Application.Common.DTOs;

namespace EduTube.Application.Features.Users.Commands;

public class CreateUserCommand : ICommand<UserDto>
{
    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public string UserName { get; set; } = default!;

    public string Password { get; set; } = default!;
}