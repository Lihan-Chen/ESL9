using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics;

namespace Core.Models.BusinessEntities
{
    /// <summary>
    /// The BaseEvent class represents an event for a generic type of log.</see>.
    /// </summary>
    [DebuggerDisplay("Event: {FacilName, nq} {LogTypeName, nq} {EventID, nq} - {EventID_RevNo, nq})")] // ({Type, nq})
    public partial record BaseEvent
    {
        #region Internal Variables

        // constants have all being moved into the constants namespace and decorated as public static readonly 
        internal string _CrLf = System.Environment.NewLine; // "<br />";

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the facilName of the FlowChange.
        /// </summary>
        [DataObjectField(true, true, false, 2)]
        [Display(Name = "Facil. No.")]
        [Column("FACILNO", TypeName = "NUMBER")]
        public int FacilNo { get; set; }

        // ToDO: Add this to the Infrastructure project's DTO Models if necessary
        ///// <summary>
        ///// Gets or sets the facilName of the FlowChange.
        ///// </summary>
        ///// 
        //[DataObjectField(false, false, false)]
        //[Display(Name = "Facility")]
        //[Column("FACILNAME", TypeName = "VARCHAR2")]
        //public string FacilName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the logTypeNo of the FlowChange.
        /// </summary>
        [DataObjectField(true, true, false, 2)]
        [Display(Name = "Log Type No.")]
        [Column("LOGTYPENO", TypeName = "NUMBER")]
        public int LogTypeNo { get; set; }

        ///// <summary>
        ///// Gets or sets the logTypeName of the FlowChange.
        ///// </summary>
        ///// 
        //[DataObjectFieldAttribute(false, false, false)]
        //[Display(Name = "Log Type")]
        //[Column("LOGTYPENAME", TypeName = "VARCHAR2")]
        //public string LogTypeName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the eventID of the FlowChange.
        /// </summary>
        [DataObjectField(true, true, false, 20)]
        [Display(Name = "Event ID")]
        [Column("EVENTID", TypeName = "VARCHAR2")]
        public string EventID { get; set; } = null!;

        /// <summary>
        /// Gets or sets the eventID_RevNo of the FlowChange.
        /// </summary>
        [DataObjectField(true, true, false, 2)]
        [Display(Name = "Revision No.")]
        [Column("EVENTID_REVNO", TypeName = "NUMBER")]
        public int EventID_RevNo { get; set; }

        /// <summary>
        /// Gets or sets the operatorID of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false, 7)]
        [Display(Name = "Operator")]
        [Required(ErrorMessage = "Need to select a name from pull-down list.  Please try again.")]
        [Column("OPERATORID", TypeName = "NUMBER")]
        public int OperatorID { get; set; }

        /// <summary>
        /// Gets or sets the createdBy of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 7)]
        [Column("CREATEDBY", TypeName = "NUMBER")]
        //[Display(Name = "Created By")]
        //[Required(ErrorMessage = "Need to select a name from pull-down list.  Please try again.")]
        public int? CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the createdDate of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, false)]
        [Display(Name = "Created Date")]
        [Column("CREATEDDATE", TypeName = "DATE")]
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the modifyFlag of the FlowChange.
        /// </summary>
        [DataObjectField(false, false, true, 100)]
        [Display(Name = "Modify Flag")]
        [Column("MODIFYFLAG", TypeName = "VARCHAR2")]
        public string ModifyFlag { get; set; } = null!;

        /// <summary>
        /// Gets or sets the modifiedBy of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, true, 7)]
        [Display(Name = "Modified By")]
        [Column("MODIFIEDBY", TypeName = "NUMBER")]
        public int? ModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the modifyDate of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, true)]
        [Display(Name = "Date Modified")]
        [Column("MODIFYDATE", TypeName = "DATE")]
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets the notes of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, true, 400)]
        [Display(Name = "Notes")]
        [Column("NOTES", TypeName = "VARCHAR2")]
        public string Notes { get; set; } = null!;

        /// <summary>
        /// Gets or sets the notifiedFacil of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, true, 200)]
        [Display(Name = "Notified Facility")]
        [Column("NOTIFIEDFACIL", TypeName = "VARCHAR2")]
        public string? NotifiedFacil { get; set; } = null!;

        /// <summary>
        /// Gets or sets the notifiedPerson of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, true, 7)]
        [Column("NOTIFIEDPERSON", TypeName = "NUMBER")]
        //[Display(Name = "Notified Person")]
        // [Display(Name = "Notified Person (optional)")]
        public int? NotifiedPerson { get; set; }

        // ToDO: Add this to the Infrastructure project's DTO Models if necessary
        ///// <summary>
        ///// Gets or sets the notifiedPerson of the FlowChange.
        ///// </summary>
        //[DataObjectFieldAttribute(false, false, true, 80)]
        //[Display(Name = "Notified Person (optional)")]
        //public string NotifiedPerson_Name
        //{
        //    get
        //    {
        //        return Helpers.GetEmpFullName("NotifiedPerson", NotifiedPerson, FacilNo); ;
        //    }
        //}

        /// <summary>
        /// Gets or sets the shiftNo of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, true, 2)]
        [Display(Name = "Shift No")]
        [Column("SHIFTNO", TypeName = "NUMBER")]
        public int? ShiftNo { get; set; }

        /// <summary>
        /// Gets or sets the yr of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, false, 2)]
        [Column("YR", TypeName = "NUMBER")]
        //[NotNullOrEmpty(Key = "DetailsNotEmpty")]
        //[RegularExpression("^d{2}$", ErrorMessage = "Please enter YY format.")]
        [Display(Name = "Year")]
        public string Yr { get; set; } = null!;

        /// <summary>
        /// Gets or sets the seqNo of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, false, 6)]
        [Display(Name = "Sequence No.")]
        [Column("SEQNO", TypeName = "NUMBER")]
        public int SeqNo { get; set; }

        /// <summary>
        /// Gets or sets the updatedBy of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, false, 60)]
        [Display(Name = "Updated By")]
        [Column("UPDATEDBY", TypeName = "VARCHAR2")]
        public string UpdatedBy { get; set; } = null!;

        /// <summary>
        /// Gets or sets the updateDate of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, false)]
        [Display(Name = "Updated On")]
        [Column("UPDATEDATE", TypeName = "DATE")]
        public DateTime UpdateDate { get; set; }

        /// <summary>
        /// Gets or sets the workOrders of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, true, 100)]
        [Display(Name = "Work Orders")]
        [Column("WORKORDERS", TypeName = "VARCHAR2")]
        public string WorkOrders { get; set; } = null!;

        /// <summary>
        /// Gets or sets the relatedTo of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, true, 200)]
        [Display(Name = "Related To")]
        [Column("RELATEDTO", TypeName = "VARCHAR2")]
        public string RelatedTo { get; set; } = null!;

        /// <summary>
        /// Gets or sets the operatorType of the FlowChange.
        /// </summary>
        [DataObjectFieldAttribute(false, false, true, 15)]
        [Display(Name = "Operator Type (Optional)")]
        [Column("OPERATORTYPE", TypeName = "VARCHAR2")]
        public string OperatorType { get; set; } = null!;

        ///// <summary>
        ///// Gets or sets the eventSubject of the FlowChange.
        ///// </summary>
        //[DataObjectFieldAttribute(false, false, false)]
        //[Display(Name = "Subject")]
        //public string EventSubject { get; set; }

        ///// <summary>
        ///// Gets or sets the eventDetails of the FlowChange.
        ///// </summary>
        //[DataObjectFieldAttribute(false, false, false)]
        //[NotNullOrEmpty(Key = "DetailsNotEmpty")]
        //[Display(Name = "Details")]
        //public string EventDetails { get; set; }

        // ToDO: Add this to the Infrastructure project's DTO Models if necessary
        ///// <summary>
        ///// Gets or sets the ScanDocsNo of the AllEvents.
        ///// </summary>
        //[DataObjectFieldAttribute(false, false, true, 2)]
        //public int ScanDocsNo { get; set; }

        #endregion
    }
}
