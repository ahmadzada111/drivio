using Drivio.Domain.RepositoryContracts;
using Drivio.Persistence.DbContext;
using Microsoft.EntityFrameworkCore.Storage;

namespace Drivio.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private bool _disposed;
    private readonly Lazy<IClientRepository> _clientRepository;
    private readonly Lazy<ISellerRepository> _sellerRepository;
    
    private readonly ApplicationDbContext _dbContext;
    private IDbContextTransaction? _currentTransaction;
    
    public UnitOfWork(
        Lazy<IClientRepository> clientRepository, 
        Lazy<ISellerRepository> sellerRepository,
        ApplicationDbContext dbContext)
    {
        _clientRepository = clientRepository;
        _sellerRepository = sellerRepository;
        _dbContext = dbContext;
    }
    
    public IClientRepository ClientRepository => _clientRepository.Value;
    public ISellerRepository SellerRepository => _sellerRepository.Value;
    
    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        if (_currentTransaction != null)
        {
            throw new InvalidOperationException("Transaction already started");
        }
        
        _currentTransaction = await _dbContext.Database.BeginTransactionAsync();
        return _currentTransaction;
    }

    public async Task CommitAsync()
    {
        if (_currentTransaction == null)
            throw new InvalidOperationException("No transaction in progress.");
        
        await _currentTransaction.CommitAsync();
        await _currentTransaction.DisposeAsync();
        _currentTransaction = null;
    }

    public async Task RollbackAsync()
    {
        if (_currentTransaction == null)
            throw new InvalidOperationException("No transaction in progress.");
        
        await _currentTransaction.RollbackAsync();
        await _currentTransaction.DisposeAsync();
        _currentTransaction = null;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
                _dbContext.Dispose();
            }
            _disposed = true;
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (!_disposed)
        {
            if (_currentTransaction != null)
            {
                await _currentTransaction.DisposeAsync();
                _currentTransaction = null;
            }
            
            await DisposeAsyncCore();
            _disposed = true;
            GC.SuppressFinalize(this);
        }
    }

    private async ValueTask DisposeAsyncCore()
    { 
        await _dbContext.DisposeAsync();
    }

    ~UnitOfWork()
    {
        Dispose(false);
    }
}