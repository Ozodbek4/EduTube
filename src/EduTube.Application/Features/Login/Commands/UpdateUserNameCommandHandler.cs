using EduTube.Application.Abstractions.Messaging;
using EduTube.Application.Abstractions.Persistence;
using EduTube.Application.Abstractions.Security;
using EduTube.Application.Common.Exceptions;
using EduTube.Application.Common.Extensions;
using EduTube.Domain.Entities;
using FluentValidation;

namespace EduTube.Application.Features.Login.Commands;

public class UpdateUserNameCommandHandler(
    IUnitOfWork unitOfWork,
    IPasswordHasher passwordHasher,
    IValidator<UpdateUserNameCommand> validator) : ICommandHandler<UpdateUserNameCommand, bool>
{
    public async Task<bool> Handle(UpdateUserNameCommand request, CancellationToken cancellationToken)
    {
        await validator.EnsureValidationAsync(request, cancellationToken);

        var exists = await unitOfWork.Users.GetAsync(entity => entity.UserName == request.CurrentUserName && !entity.IsDeleted,
            includes: ["Credentials"],
            asNoTracking: false,
            cancellationToken: cancellationToken)
            ?? throw new NotFoundException(nameof(User), request.CurrentUserName);

        bool isMatch = await passwordHasher.VerifyPassword(exists.Credentials!.PasswordHash, request.Password);
        if (!isMatch)
            throw new CustomException("User name or password is wrong.");

        exists.UserName = request.UpdateUserName;
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}