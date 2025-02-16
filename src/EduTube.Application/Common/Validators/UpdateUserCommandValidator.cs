using EduTube.Application.Features.Users.Commands;
using FluentValidation;

namespace EduTube.Application.Common.Validators;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(entity => entity.FirstName)
            .NotNull().NotEmpty().WithMessage("First name is required.")
            .MaximumLength(100).WithMessage("First name cannot exceed 100 characters.");

        RuleFor(entity => entity.LastName)
            .NotNull().NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(100).WithMessage("Last name cannot exceed 100 characters.");
    }
}