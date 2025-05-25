namespace Drivio.Contracts.Dto;

public record SignUpClientDto(
    string Email, 
    string Password, 
    string ConfirmPassword,
    string FirstName,
    string LastName,
    string? PhoneNumber,
    string UserName) : ISignUpRequest;