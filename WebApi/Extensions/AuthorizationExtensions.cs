using Microsoft.AspNetCore.Authorization;

namespace WebApi.Extensions;

public static class AuthorizationExtensions
{
    public static IServiceCollection ConfigureAuthorization(this IServiceCollection services)
    {
        services.AddAuthorizationBuilder()
            .SetDefaultPolicy(new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build());
        
        return services;
    }
}