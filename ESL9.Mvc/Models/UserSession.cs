namespace Mvc.Models
{
    public record UserSession
    {
        public string userID;
        
        public string userName;

        public int shiftNo;

        public string shiftName;

        public string operatorType;

        public bool isAdmin;

        public bool isSuperAdmin;

        public int facilNo;

        public string facilName;

        public bool userLoggedIn;

    }
}
