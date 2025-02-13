﻿using EduTube.Application.Common.DTOs;
using FluentValidation;

namespace EduTube.Application.Common.Validators;

public class CreateUserValidator : AbstractValidator<CreateUserDto>
{
    public CreateUserValidator()
    {
        RuleFor(user => user.FirstName)
            .NotNull().NotEmpty().WithMessage("First name is required")
            .MaximumLength(100).WithMessage("First name cannot exceed 100 characters");
        
        RuleFor(user => user.LastName)
            .NotNull().NotEmpty().WithMessage("Last name is required")
            .MaximumLength(100).WithMessage("Last name cannot exceed 100 characters");

        RuleFor(user => user.UserName)
            .NotNull().NotEmpty().WithMessage("User name is required")
            .MinimumLength(6).WithMessage("User name must be at least 6 characters long")
            .MaximumLength(100).WithMessage("User name cannot exceed 100 characters");

        RuleFor(user => user.Password)
            .NotNull().NotEmpty().WithMessage("Password is required")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long")
            .MaximumLength(100).WithMessage("Password cannot exceed 100 characters");
    }
}