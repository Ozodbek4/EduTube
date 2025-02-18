using EduTube.Application.Abstractions.Messaging;

namespace EduTube.Application.Features.Login.Commands;

public record UpdatePasswordByAdminCommand(string UserName, string UpdatePassword) : ICommand<bool>;