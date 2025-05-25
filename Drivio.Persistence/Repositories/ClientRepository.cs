using Drivio.Domain.Entities;
using Drivio.Domain.RepositoryContracts;
using Drivio.Persistence.DbContext;

namespace Drivio.Persistence.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly ApplicationDbContext _context;

    public ClientRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task AddAsync(Client client)
    {
        await _context.AddAsync(client);
    }
}