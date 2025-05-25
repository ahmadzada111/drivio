using Drivio.Domain.Entities;

namespace Drivio.Service.Abstractions.Abstractions;

public interface IClientFactory
{
    Client Create(Guid id, string firstName, string lastName, ApplicationUser? applicationUser = null);
}