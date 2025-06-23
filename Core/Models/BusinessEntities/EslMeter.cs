using System;
using System.Collections.Generic;

namespace Core.Models.BusinessEntities;

public partial class EslMeter
{
    public byte Facilno { get; set; }

    public string Meterid { get; set; } = null!;

    public string? Metertype { get; set; }

    public byte? Sortno { get; set; }

    public string? Notes { get; set; }

    public string? Disable { get; set; }

    public string? Updatedby { get; set; }

    public DateTime? Updatedate { get; set; }
}
