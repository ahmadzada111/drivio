using Drivio.Domain.Entities;
using Drivio.Service.Abstractions.Abstractions;

namespace Drivio.Services.Patterns.Factories;

public class ClientFactory : IClientFactory
{
    public Client Create(
        Guid id, 
        string firstName, 
        string lastName, 
        ApplicationUser? applicationUser = null)
    {
        return applicationUser is null 
            ? new Client
            {
                Id = id, 
                FirstName = firstName, 
                LastName = lastName
            } 
            : new Client
            {
                Id = id, 
                FirstName = firstName, 
                LastName = lastName, 
                ApplicationUser = applicationUser
            };
    }
}