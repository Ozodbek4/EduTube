using EduTube.Application.Abstractions.Messaging;
using EduTube.Application.Common.DTOs;

namespace EduTube.Application.Features.Users.Commands;

public record UpdateUserCommand(long Id, string FirstName, string LastName) : ICommand<UserDto>;