using Drivio.Domain.Entities;

namespace Drivio.Domain.RepositoryContracts;

public interface IClientRepository
{
    Task AddAsync(Client client);
}