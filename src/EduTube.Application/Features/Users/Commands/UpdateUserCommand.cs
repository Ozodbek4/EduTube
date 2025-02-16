using EduTube.Application.Abstractions.Messaging;
using EduTube.Application.Common.DTOs;

namespace EduTube.Application.Features.Users.Commands;

public class UpdateUserCommand : ICommand<UserDto>
{
    public long Id { get; set; }

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;
}