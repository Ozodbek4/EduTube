﻿namespace EduTube.Application.Common.DTOs;

public class LoginResponseDto
{
    public UserDto User { get; set; } = default!;

    public string Token { get; set; } = default!;
}