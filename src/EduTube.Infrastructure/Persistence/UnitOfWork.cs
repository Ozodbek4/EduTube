using EduTube.Application.Abstractions.Persistence;
using EduTube.Infrastructure.Persistence.Contexts;

namespace EduTube.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext appDbContext, IUserRepository users, IUserCredentialsRepository userCredentials)
    {
        _context = appDbContext;
        Users = users;
        UserCredentials = userCredentials;
    }

    // repositories
    public IUserRepository Users { get; }

    public IUserCredentialsRepository UserCredentials { get; }

    // methods
    public void Dispose() =>
        GC.SuppressFinalize(this);
    
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        _context.SaveChangesAsync(cancellationToken);

    public Task BeginTransactionAsync(CancellationToken cancellationToken = default) =>
        _context.Database.BeginTransactionAsync(cancellationToken);

    public Task CommitTransactionAsync(CancellationToken cancellationToken = default) =>
        _context.Database.CommitTransactionAsync(cancellationToken);

    public Task RollbackTransactionAsync(CancellationToken cancellationToken = default) =>
        _context.Database.RollbackTransactionAsync(cancellationToken);
}