namespace Core.Models.Enums
{
    public enum Log
    {
        None = 0,

        Clearance = 1,

        // Clearance Transfer = 2,

        SOC = 3,

        EOS = 4,

        FlowChange = 5,

        General = 6,

        AllEvents = 7,
    }

    public enum LogType
    {
        None = 0,
        Clearance = 1,
        // ClearanceTransfer = 2,
        SOC = 3,
        EOS = 4,
        FlowChange = 5,
        General = 6,
    }

    //enum Operations:

    //var logValues = ((Log[])Enum.GetValues(typeof(Log))).ToList();

    //var logNamesAndValues = Enum.GetValues<Log>()
    //.Select(x => new { Name = x.ToString(), Value = (int)x })
    //.ToList();

    //var logNames = Enum.GetNames<Log>().ToList();
    // Returns: ["None", "Clearance", "SOC", "EOS", "FlowChange", "Ge

    //var logNamesWithoutNone = Enum.GetValues<Log>()
    //.Where(x => x != Log.None)
    //.Select(x => x.ToString())
    //.ToList();

    //Log logType = Log.FlowChange;
    //int numericValue = (int)logType; // Will return 5

    //int logValue = 3;
    //string logName = Enum.GetName<Log>(logValue); // Returns "SOC"

    // Or with validation
    //if (Enum.IsDefined<Log>(logValue))
    //{
    //    string logName = ((Log)logValue).ToString(); // Returns "SOC"
    //}

    //string enumText = "FlowChange";

    //if (Enum.TryParse<Log>(enumText, out Log logType))
    //{
    //    // Successfully parsed, logType contains Log.FlowChange
    //}
    //else
    //{
    //    // Handle invalid enum name
    //}

    //string enumText = "flowchange"; // Note: different case

    //if (Enum.TryParse<Log>(enumText, true, out Log logType))
    //{
    //    // Successfully parsed, ignoring case
    //}
}
