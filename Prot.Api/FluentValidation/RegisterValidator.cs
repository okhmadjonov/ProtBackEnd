using FluentValidation;
using Prot.Domain.Dto.Users;

namespace Prot.Api.FluentValidation;

public class RegisterValidator : AbstractValidator<UserForCreationDto>
{
    public RegisterValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .Matches(@"^[a-zA-Z\s]+$")
            .WithMessage("Name can only contain letters and spaces.");

        RuleFor(x => x.Phonenumber)
            .NotEmpty()
            .WithMessage("Phone number is required")
            .Matches(@"^\+?[1-9]\d{12}$") 
            .WithMessage("Invalid phone number. It must be exactly 12 digits with an optional leading + sign.");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required")
            .MinimumLength(6)
            .WithMessage("Password must be at least 6 characters long")
            .Must(BeValidPassword)
            .WithMessage("Invalid password format, Password must contain one uppercase, one lowercase, one number, and one symbol.");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .Must(BeValidName)
            .WithMessage("Name can only contain letters and spaces.");
    }

    private bool BeValidName(string name)
    {
        return !string.IsNullOrWhiteSpace(name) && name.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
    }

    private bool BeValidPassword(string password)
    {
        return !string.IsNullOrWhiteSpace(password)
            && password.Any(char.IsUpper)
            && password.Any(char.IsLower)
            && password.Any(char.IsDigit)
            && password.Any(ch => !char.IsLetterOrDigit(ch));
    }
}
