using EduTube.Application.Abstractions.Messaging;

namespace EduTube.Application.Features.Login.Commands;

public record UpdateUserNameCommand(string CurrentUserName, string UpdateUserName, string Password) : ICommand<bool>;