using System.Security.Claims;

namespace Drivio.Service.Abstractions.ServiceContracts;

public interface IJwtService
{
    string GenerateAccessToken(IEnumerable<Claim> claims);

    string GenerateRefreshToken();

    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
}