using EduTube.Application.Abstractions.Messaging;
using EduTube.Application.Common.DTOs;

namespace EduTube.Application.Features.Login.Commands;

public record LoginCommand(LoginRequestDto LoginRequestDto) : ICommand<LoginResponseDto>;