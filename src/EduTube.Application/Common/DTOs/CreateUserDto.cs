﻿using System.ComponentModel.DataAnnotations;

namespace EduTube.Application.Common.DTOs;

public class CreateUserDto
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
}