using ESL9.Mvc.Domain.BusinessEntities;
using Microsoft.EntityFrameworkCore;

namespace Mvc.DbContext.DataAccess
{
    public interface IEslViewContext
    {
        DbSet<VIEW_ALLEVENTS_CURRENT> CurrentEvents { get; }
        DbSet<VIEW_CLEARANCE_OUTSTANDING> OutstandingClearances { get; }
        // ... other view DbSets
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
