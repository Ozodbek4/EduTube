using EduTube.Application.Abstractions.Messaging;
using EduTube.Application.Abstractions.Persistence;
using EduTube.Application.Abstractions.Security;
using EduTube.Application.Common.Exceptions;
using EduTube.Application.Common.Extensions;
using EduTube.Domain.Entities;
using FluentValidation;

namespace EduTube.Application.Features.Login.Commands;

public class UpdatePasswordCommandHandler(
    IUnitOfWork unitOfWork,
    IPasswordHasher passwordHasher,
    IValidator<UpdatePasswordCommand> validator) : ICommandHandler<UpdatePasswordCommand, bool>
{
    public async Task<bool> Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
    {
        await validator.EnsureValidationAsync(request, cancellationToken);

        var exists = await unitOfWork.Users.GetAsync(entity => entity.UserName == request.UserName && !entity.IsDeleted,
            includes: ["Credentials"],
            asNoTracking: false,
            cancellationToken: cancellationToken)
            ?? throw new NotFoundException(nameof(User), request.CurrentPassword);

        var isMatch = await passwordHasher.VerifyPassword(exists.Credentials!.PasswordHash, request.CurrentPassword);
        if (!isMatch)
            throw new CustomException("User name or password is wrong.");

        exists.Credentials.PasswordHash = await passwordHasher.HashPassword(request.UpdatePassword);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}