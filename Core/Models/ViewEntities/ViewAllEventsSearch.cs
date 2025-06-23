using System;
using System.Collections.Generic;

namespace Core.Models.BusinessEntities;

public partial record ViewAllEventsSearch
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

    public byte EventID_RevNo { get; set; }

    public string? OperatorType { get; set; }

    public string? ClearanceID { get; set; }
}
