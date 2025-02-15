using AutoMapper;
using EduTube.Application.Abstractions.Messaging;
using EduTube.Application.Abstractions.Persistence;
using EduTube.Application.Abstractions.Security;
using EduTube.Application.Common.DTOs;
using EduTube.Application.Common.Extensions;
using EduTube.Domain.Entities;
using FluentValidation;

namespace EduTube.Application.Features.Users.Commands;

public record CreateUserCommandHandler(IUnitOfWork unitOfWork,
    IMapper mapper,
    IPasswordHasher passwordHasher,
    IValidator<CreateUserDto> validator) : ICommandHandler<CreateUserCommand, long>
{
    public async Task<long> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        await validator.EnsureValidationAsync(request.UserDto, cancellationToken);

        var user = mapper.Map<User>(request.UserDto);
        var hashedPassword = await passwordHasher.HashPassword(request.UserDto.Password);
        user.Credentials = new UserCredentials { PasswordHash = hashedPassword };

        await unitOfWork.BeginTransactionAsync(cancellationToken);

        await unitOfWork.Users.AddAsync(user);

        await unitOfWork.CommitTransactionAsync(cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}