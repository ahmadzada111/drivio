using Drivio.Domain.Entities;
using Drivio.Service.Abstractions.Abstractions;

namespace Drivio.Services.Patterns.Factories;

public class ApplicationUserFactory : IApplicationUserFactory
{
    public ApplicationUser Create(
        Guid id, 
        BaseUser baseUser, 
        string email, 
        string userName, 
        string? phoneNumber = null)
    {
        return phoneNumber == null
            ? new ApplicationUser
            {
                Id = id,
                BaseUser = baseUser,
                Email = email,
                UserName = userName,
            }
            : new ApplicationUser
            {
                Id = id,
                BaseUser = baseUser,
                Email = email,
                UserName = userName,
                PhoneNumber = phoneNumber
            };
    }
}