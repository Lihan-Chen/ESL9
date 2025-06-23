using System;
using System.Collections.Generic;

namespace Core.Models.BusinessEntities;

public partial record EslDetail
{
    public int FacilNo { get; set; }

    public int DetailsNo { get; set; }

    public string DetailsName { get; set; } = null!;

    public string FacilType { get; set; } = null!;

    public int? SortNo { get; set; }

    public string? Notes { get; set; }

    public string? Disable { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? SubjNo { get; set; }
}
