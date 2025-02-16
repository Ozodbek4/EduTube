using EduTube.Application.Common.DTOs.Login;
using FluentValidation;

namespace EduTube.Application.Common.Validators.Login;

public class LoginRequestDtoValidator : AbstractValidator<LoginRequestDto>
{
    public LoginRequestDtoValidator()
    {
        RuleFor(entity => entity.UserName)
            .NotNull().NotEmpty().WithMessage("User name is required.")
            .MinimumLength(6).WithMessage("User name must be at least 6 characters long.")
            .MaximumLength(100).WithMessage("User name cannot exceed 100 characters.");

        RuleFor(entity => entity.Password)
            .NotNull().NotEmpty().WithMessage("Password is required.")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long.")
            .MaximumLength(100).WithMessage("Password cannot exceed 100 characters.");
    }
}