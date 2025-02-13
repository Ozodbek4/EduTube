using EduTube.Application.Abstractions.Messaging;
using EduTube.Application.Common.DTOs;

namespace EduTube.Application.Features.Users.Commands;

public record CreateUserCommand(CreateUserDto UserDto) : ICommand<long>;