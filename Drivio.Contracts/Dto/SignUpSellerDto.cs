using Drivio.Domain.Enums;

namespace Drivio.Contracts.Dto;

public record SignUpSellerDto(
    string UserName,
    string? PhoneNumber,
    string? FirstName,
    string? LastName,
    SellerType SellerType,
    string CompanyName,
    string Email,
    string Password,
    string ConfirmPassword) : ISignUpRequest;