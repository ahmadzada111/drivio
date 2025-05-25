using Drivio.Contracts.Dto;
using FluentValidation;

namespace Drivio.Services.Validators;

public class SignUpClientDtoValidator : AbstractValidator<SignUpClientDto>
{
    public SignUpClientDtoValidator()
    {
        RuleFor(client => client.Email)
            .NotEmpty()
            .WithMessage("Email is required")
            .EmailAddress()
            .WithMessage("Email must be in valid format");
        
        RuleFor(client => client.Password)
            .NotEmpty()
            .WithMessage("Password is required")
            .MinimumLength(8)
            .WithMessage("Password must have 8 characters");
        
        RuleFor(client => client.ConfirmPassword)
            .NotEmpty()
            .Equal(client => client.Password)
            .WithMessage("Passwords do not match");
        
        RuleFor(client => client.FirstName)
            .NotEmpty()
            .WithMessage("First name is required")
            .Length(3, 15)
            .WithMessage("First name must be between 3 and 15 characters");
        
        RuleFor(client => client.LastName)
            .NotEmpty()
            .WithMessage("Last name is required")
            .Length(3, 15)
            .WithMessage("Last name must be between 3 and 15 characters");
        
        RuleFor(x => x.PhoneNumber)
            .Matches(@"^\+?[1-9]\d{1,14}$")
            .WithMessage("Phone number must be in valid international format")
            .Unless(x => string.IsNullOrEmpty(x.PhoneNumber));
    }
}