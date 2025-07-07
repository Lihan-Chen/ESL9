using ESL9.Infrastructure.DataAccess;
using ESL9.Mvc.Domain.BusinessEntities;
using Microsoft.EntityFrameworkCore;
using Mvc.ViewModels;

// Ensure the method is part of a class to fix CS0106 and CS8802  
public class SearchViewModel
{
    private readonly EslDbContext _context;

    public SearchViewModel(EslDbContext context)
    {
        _context = context;
    }

    // Fix CS8321 by ensuring the method is part of a class and can be invoked  
    public List<VIEW_ALLEVENTS_CURRENT> Search(LogFilterPartialViewModel filter)
    {
        var query = _context.Current_AllEvents.AsQueryable();

        if (filter.SelectedFacilNo.HasValue)
            query = query.Where(x => x.FACILNO == filter.SelectedFacilNo.Value);

        if (filter.SelectedLogTypeNo.HasValue)
            query = query.Where(x => x.LOGTYPENO == filter.SelectedLogTypeNo.Value);

        if (filter.StartDate.HasValue)
            query = query.Where(x => x.EVENTDATE >= filter.StartDate.Value);

        if (filter.EndDate.HasValue)
            query = query.Where(x => x.EVENTDATE <= filter.EndDate.Value);

        if (!string.IsNullOrWhiteSpace(filter.CurrentFilter))
            query = query.Where(x => x.SUBJECT.Contains(filter.CurrentFilter) || x.DETAILS.Contains(filter.CurrentFilter));

        return query.ToList();
    }
}