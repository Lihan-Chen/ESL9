using System;
using System.Collections.Generic;

namespace Core.Models.BusinessEntities;

public partial record EslMeter
{
    public int FacilNo { get; set; }

    public string MeterID { get; set; } = null!;

    public string? MeterType { get; set; }

    public int? SortNo { get; set; }

    public string? Notes { get; set; }

    public string? Disable { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }
}
