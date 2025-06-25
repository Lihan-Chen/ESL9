using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;

namespace Infrastructure.DataAccess
{
    /// <summary>
    /// Ref: https://www.milanjovanovic.tech/blog/how-to-use-ef-core-interceptors
    /// Ref: https://www.youtube.com/watch?v=mAlO3OuoQvo
    /// </summary>
    internal sealed class UpdateAuditableInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = default)
        {
            if (eventData.Context is not null)
            {
                UpdateAuditableEntities(eventData.Context);
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private static void UpdateAuditableEntities(DbContext context)
        {
            DateTime utcNow = DateTime.UtcNow;
            String user = "Intercepter";
            var entities = context.ChangeTracker.Entries<IAuditable>().ToList();

            foreach (EntityEntry<IAuditable> entry in entities)
            {
                if (entry.State == EntityState.Added)
                {
                    // should also include CreatedBy and CreateDate
                    
                    SetCurrentPropertyDateTime(
                        entry, nameof(IAuditable.UpdateDate), utcNow); // CreatedOnUtc
                    SetCurrentPropertyUser(
                        entry, nameof(IAuditable.UpdateDate), user); // CreatedOnUtc

                    
                    entry.Property(a => a.UpdateDate).CurrentValue = utcNow;

                }

                if (entry.State == EntityState.Modified)
                {
                    // should also include ModifiedBy and ModifiedDate
                    
                    SetCurrentPropertyDateTime(
                        entry, nameof(IAuditable.UpdateDate), utcNow); // ModifiedOnUtc
                    SetCurrentPropertyUser(
                        entry, nameof(IAuditable.UpdateDate), user); // CreatedOnUtc
                }
            }

            static void SetCurrentPropertyDateTime(
                EntityEntry entry,
                string propertyName,
                DateTime utcNow) =>
                entry.Property(propertyName).CurrentValue = utcNow;

            static void SetCurrentPropertyUser(
                EntityEntry entry,
                string propertyName,
                string user) =>
                entry.Property(propertyName).CurrentValue = user;

            //static void SetCurrentPropertyValue(
            //    EntityEntry entry,
            //    string propertyName,
            //    DateTime utcNow) =>
            //    entry.Property(propertyName).CurrentValue = utcNow;
        }
    }
}
