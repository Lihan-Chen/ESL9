using Core.Models.BusinessEntities;
using System.ComponentModel;

namespace Application.Dtos
{
    /// <summary>
    /// The Search class represents an Search that belongs to a <see cref="SearchDto"> Search</see>.
    /// </summary>
    public partial record SearchDto : ViewSearchAllEvent
    {

        #region Private Variables

        private string _CrLf = "<br />"; // System.Environment.NewLine;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the FacilName of the Search.
        /// </summary>
        //[DataObjectField(true, true, false)]
        //public int FacilNo { get; set; }

        /// <summary>
        /// Gets or sets the FacilName of the AllEvents.
        /// </summary>
        /// 
        [DataObjectField(false, false, false)]
        public string FacilName { get; set; } = null!;

        ///// <summary>
        ///// Gets or sets the LogTypeName of the Search.
        ///// </summary>
        //[DataObjectField(true, true, false)]
        //public int LogTypeNo { get; set; }

        ///// <summary>
        ///// Gets or sets the LogTypeName of the AllEvents.
        ///// </summary>
        ///// 
        //[DataObjectField(false, false, false)]
        //public string LogTypeName { get; set; } = null!;

        ///// <summary>
        ///// Gets or sets the EventID of the Search.
        ///// </summary>
        //[DataObjectField(true, true, false)]
        //public string EventID { get; set; } = null!;

        ///// <summary>
        ///// Gets or sets the EventID_RevNo of the Search.
        ///// </summary>
        //[DataObjectField(true, true, false)]
        //public int EventID_RevNo { get; set; }

        ///// <summary>
        ///// Gets or sets the EventDate of the Search.
        ///// </summary>
        //[DataObjectField(false, false, false)]
        //public DateTime EventDate { get; set; }

        ///// <summary>
        ///// Gets or sets the EventTime of the Search.
        ///// </summary>
        //[DataObjectField(false, false, false)]
        //public string EventTime { get; set; } = null!;

        ///// <summary>
        ///// Gets or sets the subject of the Search.
        ///// </summary>
        //[DataObjectField(false, false, false)]
        //public string Subject { get; set; } = null!;

        ///// <summary>
        ///// Gets or sets the details of the Search.
        ///// </summary>
        //[DataObjectField(false, false, false)]
        ////[NotNullOrEmpty(Key = "DetailsNotEmpty")]
        //public string Details { get; set; } = null!;

        ///// <summary>
        ///// Gets or sets the OperatorType of the Search.
        ///// </summary>
        //[DataObjectField(false, false, false)]
        ////[NotNullOrEmpty(Key = "DetailsNotEmpty")]
        //public string OperatorType { get; set; } = null!;

        ///// <summary>
        ///// Gets or sets the UpdatedBy of the Search.
        ///// </summary>
        //[DataObjectField(false, false, false)]
        //public string UpdatedBy { get; set; } = null!;

        ///// <summary>
        ///// Gets or sets the UpdateDate of the Search.
        ///// </summary>
        //[DataObjectField(false, false, false)]
        //public string UpdateDate { get; set; } = null!;

        ///// <summary>
        ///// Gets or sets the ClearanceID of the Search.
        ///// </summary>
        //[DataObjectField(false, false, false)]
        ////[NotNullOrEmpty(Key = "DetailsNotEmpty")]
        //public string ClearanceID { get; set; } = null!;

        /// <summary>
        /// Gets or sets the EventIDentifier of the Search.
        /// </summary>
        [DataObjectField(false, false, false)]
        //[NotNullOrEmpty(Key = "DetailsNotEmpty")]
        public string EventIDentifier => $"{EventID} / {Convert.ToString(EventID_RevNo)}";

        /// <summary>
        /// Gets or sets the eventHighlight of the Search.
        /// </summary>
        [DataObjectField(false, false, false)]
        //[NotNullOrEmpty(Key = "DetailsNotEmpty")]
        public string EventHighlight => $"{Subject}{_CrLf}{Details}{_CrLf}Updated By: {UpdatedBy} on {UpdateDate}";

        #endregion
    }
}
