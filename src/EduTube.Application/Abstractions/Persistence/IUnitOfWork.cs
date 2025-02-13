namespace EduTube.Application.Abstractions.Persistence;

public interface IUnitOfWork : IDisposable
{
    // repositories
    IUserRepository Users  { get; }
    
    IUserCredentialsRepository UserCredentials { get; }

    // methods
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    Task BeginTransactionAsync(CancellationToken cancellationToken = default);
    
    Task CommitTransactionAsync(CancellationToken cancellationToken = default);
    
    Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
}