using EduTube.Application.Abstractions.Messaging;

namespace EduTube.Application.Features.Login.Commands;

public record UpdatePasswordCommand(string UserName, string CurrentPassword, string UpdatePassword) : ICommand<bool>;