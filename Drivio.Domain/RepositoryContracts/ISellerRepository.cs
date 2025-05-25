using Drivio.Domain.Entities;

namespace Drivio.Domain.RepositoryContracts;

public interface ISellerRepository
{
    Task AddAsync(Seller seller);
}