using EduTube.Application.Abstractions.Messaging;
using EduTube.Application.Abstractions.Persistence;
using EduTube.Application.Common.Exceptions;
using EduTube.Domain.Entities;

namespace EduTube.Application.Features.Users.Commands;

public class DeleteUserCommandHandler(IUnitOfWork unitOfWork) : ICommandHandler<DeleteUserCommand, bool>
{
    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var exists = await unitOfWork.Users.GetAsync(entity => entity.Id == request.Id && !entity.IsDeleted, cancellationToken: cancellationToken)
            ?? throw new NotFoundException(nameof(User), request.Id);

        await unitOfWork.Users.RemoveAsync(exists, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}