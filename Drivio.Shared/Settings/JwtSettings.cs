namespace Drivio.Shared.Settings;

public record JwtSettings(
    string Secret,
    string Issuer,
    string Audience,
    int AccessTokenLifetime);