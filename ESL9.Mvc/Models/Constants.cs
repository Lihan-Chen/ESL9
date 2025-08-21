namespace Mvc.Models
{
    public class AppConstants 
    {
        #region Custom Claim Types used in the application
        public const string NameClaimType = "name";
        public const string UserIDClaimType = "userid";
        public const string DefaultFacilNoClaimType = "defaultfacilno";
        public const string RoleClaimType = "role";
        public const string ShiftNoClaimType = "shiftno";
        public const string IsPrimaryOperatorClaimType = "IsPrimaryOperator";
        #endregion

        #region Custom Session Keys used in the application
        public const string SelectedFacilNoSessionKey = "SelectedFacilNo";

        public const String DayShiftStartText = "06:00:00";  // for Day shift
        public const String DayShiftEndText = "17:59:59";
        #endregion


        // Other constants can be added here as needed
    }
}
