namespace Mvc.Models
{
    public class AppConstants 
    {
        #region Custom Claim Types used in the application
        public const string NameClaimType = "name";
        public const string UserIDClaimType = "userid";
        //public const string UserModeClaimType = "usermode";
        public const string DefaultFacilNoClaimType = "defaultfacilno";
        public const string DefaultRoleClaimType = "defaultrole";
        //public const string ShiftNoClaimType = "shiftno";
        //public const string IsPrimaryOperatorClaimType = "IsPrimaryOperator";
        #endregion

        #region Custom Session Keys used in the application
        public const string SelectedFacilNoSessionKey = "SelectedFacilNo";
        public const string AssignedFacilNoSessionKey = "AssignedFacilNo";
        public const string AssignedRoleSessionKey = "AssignedRole";
        public const string UserModeSessionKey = "UserMode"; // "Internal" or "Public"
        public const string AssignedShiftNoSessionKey = "AssignedShiftNo"; // 1, 2, or 3
        public const string AssingedOperatorTypeSessionKey = "IsPrimaryOperator"; // "true" or "false"


        public const String DayShiftStartText = "06:00:00";  // for Day shift
        public const String DayShiftEndText = "17:59:59";
        #endregion


        // Other constants can be added here as needed
    }
}
