using EduTube.Application.Common.DTOs.Users;

namespace EduTube.Application.Common.DTOs.Login;

public class LoginResponseDto
{
    public UserDto User { get; set; } = default!;

    public string Token { get; set; } = default!;
}