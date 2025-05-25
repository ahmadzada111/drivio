using Drivio.Domain.Entities;

namespace Drivio.Service.Abstractions.Abstractions;

public interface IApplicationUserFactory
{
    public ApplicationUser Create(
        Guid id,
        BaseUser baseUser,
        string email,
        string userName,
        string? phoneNumber = null);
}