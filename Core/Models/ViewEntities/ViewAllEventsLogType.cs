namespace Core.Models.BusinessEntities;

public partial record ViewAllEventsLogType
{
    public int LogTypeNo { get; set; }

    public string LogTypeName { get; set; } = null!;
}
