namespace Application.Dtos
{
    /// <summary>
    /// This represents the user session information.
    /// </summary>
    public partial record UserDto
    {
        public UserDto() { }

        public UserDto(string userName, string userID, Dictionary<int, string>? userRoles, int? defaultFacilNo)
        {
            UserName = userName;
            UserID = userID;
            UserRoles = userRoles;
            DefaultFacilNo = defaultFacilNo;
        }

        // ClaimPrincipal User claimtype = "name" in {LastName,FirstName} format
        public string? UserName { get; set; }

        // Uxxxxx format where x is a number
        public string? UserID { get; set; }

        // Any authenticated user is considered a "read only" user unless they have roles assigned.
        // used to redirect to log in if not authenticated
        public bool IsUserAnOperator => UserRoles is null || UserRoles.Count == 0;

        // Disctionary of user roles per facility such as ESL_OPERATOR, ESL_ADMIN, etc.
        // Key is FacilNo, Value is RoleName
        // corresponds to the UserRoles table in the database
        public Dictionary<int, string>? UserRoles { get; set; }

        // Can default to previous session's FacilNo
        public int? DefaultFacilNo { get; set; }

    }

    
}
//public static class UserDtoExtensions
//{
//    public static bool IsUserAnOperator(this UserDto user) => user.UserRoles is null || user.UserRoles.Count == 0;
//}