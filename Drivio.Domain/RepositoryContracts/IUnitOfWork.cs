using Microsoft.EntityFrameworkCore.Storage;

namespace Drivio.Domain.RepositoryContracts;

public interface IUnitOfWork : IDisposable, IAsyncDisposable
{
    IClientRepository ClientRepository { get; }
    ISellerRepository SellerRepository { get; }
    Task<IDbContextTransaction> BeginTransactionAsync();
    Task CommitAsync();
    Task RollbackAsync();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}