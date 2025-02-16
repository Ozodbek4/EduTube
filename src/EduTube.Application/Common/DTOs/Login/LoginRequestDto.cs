using System.ComponentModel.DataAnnotations;

namespace EduTube.Application.Common.DTOs.Login;

public class LoginRequestDto
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
}