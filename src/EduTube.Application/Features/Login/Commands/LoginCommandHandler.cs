using AutoMapper;
using EduTube.Application.Abstractions.Messaging;
using EduTube.Application.Abstractions.Persistence;
using EduTube.Application.Abstractions.Security;
using EduTube.Application.Common.DTOs.Login;
using EduTube.Application.Common.DTOs.Users;
using EduTube.Application.Common.Exceptions;
using EduTube.Application.Common.Extensions;
using FluentValidation;

namespace EduTube.Application.Features.Login.Commands;

public class LoginCommandHandler(
    IValidator<LoginRequestDto> validator,
    IUserRepository userRepository,
    IPasswordHasher passwordHasher,
    ITokenGeneratorService tokenGeneratorService,
    IMapper mapper) : ICommandHandler<LoginCommand, LoginResponseDto>
{
    public async Task<LoginResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        await validator.EnsureValidationAsync(request.LoginRequestDto, cancellationToken);

        var existsUser = await userRepository.GetAsync(entity => entity.UserName == request.LoginRequestDto.UserName && !entity.IsDeleted,
            includes: ["Credentials"])
            ?? throw new NotFoundException(nameof(UserDto), request.LoginRequestDto.UserName);

        var isMatch = await passwordHasher.VerifyPassword(existsUser.Credentials!.PasswordHash, request.LoginRequestDto.Password);
        if (!isMatch)
            throw new UnauthorizedAccessException($"Invalid password.");

        var token = await tokenGeneratorService.GenerateTokenAsync(existsUser, cancellationToken);

        return new LoginResponseDto { Token = token, User = mapper.Map<UserDto>(existsUser) };
    }
}