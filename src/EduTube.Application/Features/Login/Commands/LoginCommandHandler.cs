using AutoMapper;
using EduTube.Application.Abstractions.Messaging;
using EduTube.Application.Abstractions.Persistence;
using EduTube.Application.Abstractions.Security;
using EduTube.Application.Common.DTOs;
using EduTube.Application.Common.Exceptions;
using EduTube.Application.Common.Extensions;
using EduTube.Domain.Entities;
using FluentValidation;

namespace EduTube.Application.Features.Login.Commands;

public class LoginCommandHandler(
    IValidator<LoginCommand> validator,
    IUserRepository userRepository,
    IPasswordHasher passwordHasher,
    ITokenGeneratorService tokenGeneratorService,
    IMapper mapper) : ICommandHandler<LoginCommand, LoginResponseDto>
{
    public async Task<LoginResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        await validator.EnsureValidationAsync(request, cancellationToken);

        var existsUser = await userRepository.GetAsync(entity => entity.UserName == request.UserName && !entity.IsDeleted,
            includes: ["Credentials"])
            ?? throw new NotFoundException(nameof(User), request.UserName);

        var isMatch = await passwordHasher.VerifyPassword(existsUser.Credentials!.PasswordHash, request.Password);
        if (!isMatch)
            throw new UnauthorizedAccessException($"Invalid password.");

        var token = await tokenGeneratorService.GenerateTokenAsync(existsUser, cancellationToken);

        return new LoginResponseDto { Token = token, User = mapper.Map<UserDto>(existsUser) };
    }
}