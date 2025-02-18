using EduTube.Application.Features.Login.Commands;
using FluentValidation;

namespace EduTube.Application.Common.Validators;

public class UpdatePasswordByAdminCommandValidator : AbstractValidator<UpdatePasswordByAdminCommand>
{
    public UpdatePasswordByAdminCommandValidator()
    {
        RuleFor(entity => entity.UserName)
            .NotNull().NotEmpty().WithMessage("User name is required.")
            .MinimumLength(6).WithMessage("User name must be at least 6 characters long.")
            .MaximumLength(100).WithMessage("User name cannot exceed 100 characters.");

        RuleFor(entity => entity.UpdatePassword)
            .NotNull().NotEmpty().WithMessage("Password is required.")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long.")
            .MaximumLength(100).WithMessage("Password cannot exceed 100 characters.");
    }
}