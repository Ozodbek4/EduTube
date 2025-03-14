﻿using EduTube.Application.Abstractions.Messaging;
using EduTube.Application.Common.DTOs;

namespace EduTube.Application.Features.Login.Commands;

public class LoginCommand : ICommand<LoginResponseDto>
{
    public string UserName { get; set; } = default!;

    public string Password { get; set; } = default!;
};