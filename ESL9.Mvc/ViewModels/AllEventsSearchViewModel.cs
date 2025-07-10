using Core.Models.BusinessEntities;
using ESL9.Mvc.Domain.BusinessEntities;
    // ViewModels/AllEventsSearchViewModel.cs
using Mvc.ViewModels;
using System.Collections.Generic;

public class AllEventsSearchViewModel
{
    public LogFilterPartialViewModel Filter { get; set; } = new();
    public List<ViewAllEventsCurrent> Results { get; set; } = new();

}
