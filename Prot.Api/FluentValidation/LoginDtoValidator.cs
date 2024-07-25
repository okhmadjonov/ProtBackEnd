using FluentValidation;
using Prot.Domain.Dto.Users;

namespace Prot.Api.FluentValidation;


public class LoginDtoValidator : AbstractValidator<LoginDto>
{
    public LoginDtoValidator()
    {
        RuleFor(x => x.Phonenumber)
            .NotEmpty()
            .WithMessage("Phone number is required")
           .Matches(@"^\+?[1-9]\d{12}$")
            .WithMessage("Invalid phone number");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required")
            .Must(BeValidPassword)
            .WithMessage(
                "Invalid password format, Password must contain one Uppercase, one lowercase , number and symbol !"
            );
    }

    private bool BeValidPassword(string password)
    {
        return !string.IsNullOrWhiteSpace(password)
             && password.Any(char.IsUpper)
            && password.Any(char.IsLower)
            && password.Any(char.IsDigit)
            && password.Any(char.IsLetter);
    }
}
