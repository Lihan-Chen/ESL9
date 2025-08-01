﻿namespace Core.Models.BusinessEntities;

/// <summary>
/// This view represents all EOS events from AllEvents table joined by logtypename, employeename, and scandocno.
/// </summary>
public partial record ViewEOSAll
{
    public int FacilNo { get; set; }

    public int LogTypeNo { get; set; }

    public string EventID { get; set; } = null!;

    public int EventID_RevNo { get; set; }

    public DateTime? EventDate { get; set; }

    public string? EventTime { get; set; }

    public string? Subject { get; set; }

    public string? Details { get; set; }

    public string LogTypeName { get; set; } = null!;

    public string FacilName { get; set; } = null!;

    public string? UpdatedBy { get; set; }

    public DateTime UpdateDate { get; set; }

    public string? OperatorType { get; set; }

    public int? ScanDocsNo { get; set; }
}
