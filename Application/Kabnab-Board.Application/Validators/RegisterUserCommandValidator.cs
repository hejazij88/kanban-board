using FluentValidation;
using Kabnab_Board.Application.Commands;

namespace Kabnab_Board.Application.Validators;

public class RegisterUserCommandValidator :AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(r => r.fullName).NotEmpty().MinimumLength(4);
        RuleFor(r => r.email).NotEmpty().EmailAddress();
        RuleFor(r=>r.password).NotEmpty().MinimumLength(6).Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$").WithMessage("Password must contain upper, lower case and number.");
    }
}