using EduTube.Application.Abstractions.Messaging;
using EduTube.Application.Common.DTOs.Login;

namespace EduTube.Application.Features.Login.Commands;

public record LoginCommand(LoginRequestDto LoginRequestDto) : ICommand<LoginResponseDto>;