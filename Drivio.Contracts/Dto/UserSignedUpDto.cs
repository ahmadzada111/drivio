namespace Drivio.Contracts.Dto;

public record UserSignedUpDto(
    Guid Id,
    string Email,
    string Username);