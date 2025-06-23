namespace Core.Models.Enums
{
    // <summary>
    /// Determines the state of Session.
    /// </summary>
    public enum SessionState
    {
        /// <summary>
        /// Indicates session new.  Set the value to 1 instead of default 0
        /// </summary>
        New = 1,

        /// <summary>
        /// Indicates Session in progress.
        /// </summary>
        InProgress = 2,

        /// <summary>
        /// Indicates Session is complete and valid after Model validation.
        /// </summary>
        Valid = 3,

        /// <summary>
        /// Indicates Session has expired.
        /// </summary>
        Expired = 4,

        /// <summary>
        /// Indicates session has been locked.
        /// </summary>
        Locked = 5,
    }
}


