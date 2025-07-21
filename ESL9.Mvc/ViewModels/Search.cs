using Core.Models.BusinessEntities;
using Infrastructure.DataAccess;
using Mvc.ViewModels;

// Ensure the method is part of a class to fix CS0106 and CS8802  
public class SearchViewModel
{
    private readonly EslDbContext _context;
    private readonly EslViewContext _vcontext;

    public SearchViewModel(EslDbContext context, EslViewContext vcontext)
    {
        _context = context;
        _vcontext = vcontext;
    }

    // Fix CS8321 by ensuring the method is part of a class and can be invoked  
    public List<ViewAllEventsCurrent> Search(LogFilterPartialViewModel filter)
    {
        var query = _vcontext.Current_AllEvents.AsQueryable();

        if (filter.SelectedFacilNo.HasValue)
            query = query.Where(x => x.FacilNo == filter.SelectedFacilNo.Value);

        if (filter.SelectedLogTypeNo.HasValue)
            query = query.Where(x => x.LogTypeNo == filter.SelectedLogTypeNo.Value);

        if (filter.StartDate.HasValue)
            query = query.Where(x => x.EventDate >= filter.StartDate.Value);

        if (filter.EndDate.HasValue)
            query = query.Where(x => x.EventDate <= filter.EndDate.Value);

        if (!string.IsNullOrWhiteSpace(filter.CurrentFilter))
            query = query.Where(x => !string.IsNullOrWhiteSpace(x.Subject) && x.Subject.Contains(filter.CurrentFilter) || !string.IsNullOrWhiteSpace(x.Subject) && x.Details.Contains(filter.CurrentFilter));

        return query.ToList();
    }
}