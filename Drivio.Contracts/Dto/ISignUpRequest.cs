namespace Drivio.Contracts.Dto;

public interface ISignUpRequest
{
    string UserName { get; init; }
    
    string Email { get; init; }
    
    string? PhoneNumber { get; init; }
    
    string Password { get; init; }
    
    string ConfirmPassword { get; init; }
}