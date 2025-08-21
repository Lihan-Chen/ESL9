namespace Mvc.Models.Constants
{
    public enum LogType
    {
        // None = 0,

        Clearance = 1,

        // ClearanceTransfer = 2,

        SOC = 3,

        EOS = 4,

        FlowChange = 5,

        General = 6,
    }

    public abstract class LogTypeExtensions
    {
        public static string GetLogTypeName(LogType logType)
        {
            return logType switch
            {
                LogType.Clearance => "Clearance",
                LogType.SOC => "SOC",
                LogType.EOS => "EOS",
                LogType.FlowChange => "FlowChange",
                LogType.General => "General",

                _ => throw new ArgumentOutOfRangeException(nameof(logType), logType, null)
            };
        }
    }

    public static class LogTypeHelper
    {
        public static string GetLogTypeName(int logTypeNo)
        {
            return ((LogType)logTypeNo).ToString();
        }

        //public static string GetPlantName(string plant)
        //{
        //    return Enum.TryParse<Plant>(plant, out var plantEnum) ? plantEnum.ToString() : "Unknown";
        //}

        //public static int GetPlantNumber(string plant)
        //{
        //    return Enum.TryParse<Plant>(plant, out var plantEnum) ? (int)plantEnum : 0;
        //}

        public static int GetLogTypeNo(LogType logType)
        {
            return (int)logType;
        }
    }
}
