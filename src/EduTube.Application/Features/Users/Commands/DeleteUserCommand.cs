using EduTube.Application.Abstractions.Messaging;

namespace EduTube.Application.Features.Users.Commands;

public class DeleteUserCommand : ICommand<bool>
{
    public long Id { get; set; }

    public DeleteUserCommand(long id) =>
        Id = id;
}