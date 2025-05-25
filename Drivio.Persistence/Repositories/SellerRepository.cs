using Drivio.Domain.Entities;
using Drivio.Domain.RepositoryContracts;
using Drivio.Persistence.DbContext;

namespace Drivio.Persistence.Repositories;

public class SellerRepository : ISellerRepository
{
    private readonly ApplicationDbContext _dbContext;

    public SellerRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Seller seller)
    {
        await _dbContext.Sellers.AddAsync(seller);
    }
}