using EduTube.Application.Abstractions.Messaging;
using EduTube.Application.Abstractions.Persistence;
using EduTube.Application.Abstractions.Security;
using EduTube.Application.Common.Exceptions;
using EduTube.Application.Common.Extensions;
using EduTube.Domain.Entities;
using FluentValidation;

namespace EduTube.Application.Features.Login.Commands;

public class UpdatePasswordByAdminCommandHandler(
    IUnitOfWork unitOfWork,
    IPasswordHasher passwordHasher,
    IValidator<UpdatePasswordByAdminCommand> validator) : ICommandHandler<UpdatePasswordByAdminCommand, bool>
{
    public async Task<bool> Handle(UpdatePasswordByAdminCommand request, CancellationToken cancellationToken)
    {
        await validator.EnsureValidationAsync(request, cancellationToken);

        var result = await unitOfWork.Users.GetAsync(entity => entity.UserName == request.UserName && !entity.IsDeleted,
            includes: ["Credentials"],
            asNoTracking: false,
            cancellationToken: cancellationToken)
            ?? throw new NotFoundException(nameof(User), request.UserName);

        result.Credentials!.PasswordHash = await passwordHasher.HashPassword(request.UpdatePassword);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}