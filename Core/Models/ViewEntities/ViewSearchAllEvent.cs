﻿namespace Core.Models.BusinessEntities;

/// <summary>
/// This view object represents all events whose ModifyFlag are null or not in ['Deleted','Revised','Rejected']  or LIKE 'Replaced%'
/// This is the same as ViewAllEventsSearch, consider consolidating them to use only one.
/// </summary>
public partial record ViewSearchAllEvent
{
    public int FacilNo { get; set; }

    public int LogTypeNo { get; set; }

    public string EventID { get; set; } = null!;

    public DateTime? EventDate { get; set; }

    public string? EventTime { get; set; }

    public string? Subject { get; set; }

    public string? Details { get; set; }

    public string LogTypeName { get; set; } = null!;

    public string UpdatedBy { get; set; } = null!;

    public DateTime UpdateDate { get; set; }

    public int EventID_RevNo { get; set; }

    public string? OperatorType { get; set; }

    public string? ClearanceID { get; set; }
}
