using EduTube.Domain.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EduTube.Infrastructure.Persistence.Interceptors;

public class AuditableInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        var auditableEntry = eventData.Context!.ChangeTracker.Entries<AuditableEntity>().ToList();

        auditableEntry.ForEach(entry =>
        {
            if (entry.State == EntityState.Added)
                entry.Property(nameof(AuditableEntity.CreatedAt)).CurrentValue = DateTime.UtcNow;

            if (entry.State == EntityState.Modified)
                entry.Property(nameof(AuditableEntity.UpdatedAt)).CurrentValue = DateTime.UtcNow;

            if (entry.State != EntityState.Deleted)
                return;

            entry.Property(nameof(AuditableEntity.DeletedAt)).CurrentValue = DateTime.UtcNow;
            entry.Property(nameof(AuditableEntity.IsDeleted)).CurrentValue = true;
            entry.State = EntityState.Modified;
        });

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}