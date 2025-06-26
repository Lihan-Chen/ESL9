namespace Core.Models.BusinessEntities;

/// <summary>
/// This represents a view of distinct LogType from the AllEvents table.
/// Used to retrieve a List<LogTypeNo, LogTypeName>.
/// </summary>
public partial record ViewAllEventsLogType
{
    public int LogTypeNo { get; set; }

    public string LogTypeName { get; set; } = null!;
}
