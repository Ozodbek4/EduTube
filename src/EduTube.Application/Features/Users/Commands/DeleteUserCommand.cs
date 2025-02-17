using EduTube.Application.Abstractions.Messaging;

namespace EduTube.Application.Features.Users.Commands;

public record DeleteUserCommand(long Id) : ICommand<bool>;