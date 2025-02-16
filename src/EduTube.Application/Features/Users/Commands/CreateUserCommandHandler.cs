using AutoMapper;
using EduTube.Application.Abstractions.Messaging;
using EduTube.Application.Abstractions.Persistence;
using EduTube.Application.Abstractions.Security;
using EduTube.Application.Common.DTOs;
using EduTube.Application.Common.Extensions;
using EduTube.Domain.Entities;
using FluentValidation;

namespace EduTube.Application.Features.Users.Commands;

public class CreateUserCommandHandler(IUnitOfWork unitOfWork,
    IMapper mapper,
    IPasswordHasher passwordHasher,
    IValidator<CreateUserCommand> validator) : ICommandHandler<CreateUserCommand, UserDto>
{
    public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        await validator.EnsureValidationAsync(request, cancellationToken);

        var user = mapper.Map<User>(request);
        var hashedPassword = await passwordHasher.HashPassword(request.Password);
        user.Credentials = new UserCredentials { PasswordHash = hashedPassword };

        await unitOfWork.BeginTransactionAsync(cancellationToken);

        await unitOfWork.Users.AddAsync(user);

        await unitOfWork.CommitTransactionAsync(cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return mapper.Map<UserDto>(user);
    }
}