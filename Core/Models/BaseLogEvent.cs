namespace Core.Models
{
    /// <summary>
    /// The BaseEvent class represents an event for a type of log that belongs to a <see cref="FlowChange"> AllEvent</see>.
    /// </summary>
    //[DebuggerDisplay("Event: {FacilName, nq} {LogTypeName, nq} {EventID, nq} - {EventID_RevNo, nq})")] // ({Type, nq})
    ////[PrimaryKey(nameof(FacilNo), "LogTypeNo", nameof(EventID), nameof(EventID_RevNo))]
    //[NotMapped]
    public abstract record BaseLogEvent : BaseEventID

    {
        #region Internal Variables

        internal string _CrLf = "<br />"; // Environment.NewLine ; // "\\r?\\n"; "<br />"; "\r\n";

        #endregion

        #region Public Properties

        //public EventIDentity EventIDentity { get; set; } = new EventIDentity();

        ///// <summary>
        ///// Gets or sets the FacilNo of the Facility.
        ///// </summary>
        //[DataObjectField(true, true, false, 2)]
        //[DisplayName("Facil. No.")]
        //[ForeignKey(nameof(Facility))]
        //public int FacilNo { get; set; }
        ///// <summary>
        ///// Gets or sets the LogTypeNo of the Log Type.
        ///// </summary>
        //[DataObjectField(true, true, false, 2)]
        //[DisplayName("Log Type No.")]
        //[ForeignKey("LogTypeNo")]
        //public int LogTypeNo { get; set; }

        ///// <summary>
        ///// Gets or sets the EventID of the Event.
        ///// </summary>
        //[DataObjectField(true, true, false, 20)]
        //[DisplayName("Event ID")]
        //public string EventID { get; set; } = null!;
        ///// <summary>
        ///// Gets or sets the EventID_RevNo of the Event.
        ///// </summary>
        //[DataObjectField(true, true, false, 2)]
        //[DisplayName("Revision No.")]
        //public int EventID_RevNo { get; set; }

        /// <summary>
        /// Gets or sets the FacilName of the event.
        /// </summary> 
        //[DataObjectField(false, false, false)]
        //[DisplayName("Facility")]
        //[NotMapped]
        public string FacilName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the LogTypeName of the FlowChange.
        /// </summary>
        /// 
        //[DataObjectField(false, false, false)]
        //[DisplayName("Log Type")]
        //[NotMapped]
        public string LogTypeName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the OperatorID of the FlowChange.
        /// </summary>
        //[DataObjectField(false, false, false, 7)]
        //[DisplayName("Operator")]
        //[Required(ErrorMessage = "Need to select a name from pull-down list.  Please try again.")]
        //[ForeignKey(nameof(Operator))]
        //[Column(nameof(OperatorID))]
        public int OperatorID { get; set; }

        /// <summary>
        /// Gets or sets the CreatedBy of the FlowChange.
        /// </summary>
        //[DataObjectField(false, false, true, 7)]
        //[DisplayName("Created By")]
        //[Required(ErrorMessage = "Need to select a name from pull-down list.  Please try again.")]
        //[ForeignKey(nameof(CreatedBy_Employee))]
        //[Column(nameof(CreatedBy))]
        public int? CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the CreatedDate of the FlowChange.
        /// </summary>
        //[DataObjectField(false, false, false)]
        //[DisplayName("Created Date")]
        //[Column(nameof(CreatedDate))]
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the ModifyFlag of the FlowChange.
        /// </summary>
        //[DataObjectField(false, false, true, 100)]
        //[DisplayName("Modify Flag")]
        //[Column(nameof(ModifyFlag))]
        public string? ModifyFlag { get; set; }

        /// <summary>
        /// Gets or sets the ModifiedBy of the FlowChange.
        /// </summary>
        //[DataObjectField(false, false, true, 7)]
        //[DisplayName("Modified By")]
        //[ForeignKey(nameof(ModifiedBy_Employee))]
        //[Column(nameof(ModifiedBy))]
        public int? ModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the modifyDate of the FlowChange.
        /// </summary>
        //[DataObjectField(false, false, true)]
        //[DisplayName("Date Modified")]
        //[Column(nameof(ModifiedDate))]
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets the notes of the FlowChange.
        /// </summary>
        //[DataObjectField(false, false, true, 400)]
        //[DisplayName("Notes")]
        //[Column("NOTES", TypeName = "VARCHAR2")]
        public string? Notes { get; set; }

        /// <summary>
        /// Gets or sets the NotifiedFacil of the FlowChange.
        /// </summary>
        //[DataObjectField(false, false, true, 200)]
        //[DisplayName("Notified Facility")]
        //[Column(nameof(NotifiedFacil))]
        public string? NotifiedFacil { get; set; }

        /// <summary>
        /// Gets or sets the NotifiedPerson of the FlowChange.
        /// </summary>
        //[DataObjectField(false, false, true, 7)]
        // [DisplayName("Notified Person (optional)")]
        //[ForeignKey(nameof(NotifiedPerson_Employee))]
        //[Column(nameof(NotifiedPerson))]
        public int? NotifiedPerson { get; set; }

        /// <summary>
        /// Gets or sets the NotifiedPerson of the FlowChange.
        /// </summary>
        //[DataObjectField(false, false, true, 80)]
        //[DisplayName("Notified Person (optional)")]
        //[NotMapped]
        //public string? NotifiedPerson_Name => NotifiedPerson_Employee.FirstName + " " + NotifiedPerson_Employee.FirstName;

        /// <summary>
        /// Gets or sets the ShiftNo of the FlowChange.
        /// </summary>
        //[DataObjectField(false, false, true, 2)]
        //[DisplayName("Shift No")]
        //[Column(nameof(ShiftNo))]
        public int? ShiftNo { get; set; }
        /// <summary>
        /// Gets or sets the yr of the FlowChange.
        /// </summary>
        //[DataObjectField(false, false, false, 2)]
        //[NotNullOrEmpty(Key = "DetailsNotEmpty")]
        //[RegularExpression("^d{2}$", ErrorMessage = "Please enter YY format.")]
        //[DisplayName("Year")]
        //[Column(nameof(Yr))]
        public string Yr { get; set; } = DateTime.Now.Year.ToString();

        /// <summary>
        /// Gets or sets the SeqNo of the FlowChange.
        /// </summary>
        //[DataObjectField(false, false, false, 6)]
        //[DisplayName("Sequence No.")]
        //[Column(nameof(SeqNo))]
        public int SeqNo { get; set; }

        ///// <summary>
        ///// Gets or sets the UpdatedBy of the FlowChange.
        ///// </summary>
        //[DataObjectField(false, false, false, 60)]
        //[DisplayName("Updated By")]
        //[Column(nameof(UpdatedBy))]
        //public string UpdatedBy { get; set; } = null!;

        ///// <summary>
        ///// Gets or sets the UpdateDate of the FlowChange.
        ///// </summary>
        //[DataObjectField(false, false, false)]
        //[Column(nameof(UpdateDate))]
        //public DateTime UpdateDate { get; set; }

        /// <summary>
        /// Gets or sets the WorkOrders of the FlowChange.
        /// </summary>
        //[DataObjectField(false, false, true, 100)]
        //[DisplayName("Work Orders")]
        //[Column(nameof(WorkOrders))]
        public string? WorkOrders { get; set; }

        /// <summary>
        /// Gets or sets the RelatedTo of the FlowChange.
        /// </summary>
        //[DataObjectField(false, false, true, 200)]
        //[DisplayName("Rnelated To")]
        //[Column(nameof(RelatedTo))]
        public string? RelatedTo { get; set; }

        /// <summary>
        /// Gets or sets the OperatorType of the FlowChange.
        /// </summary>
        //[DataObjectField(false, false, true, 15)]
        //[DisplayName("Operator Type (Optional)")]
        //[Column(nameof(OperatorType))]
        public string? OperatorType { get; set; }

        /// <summary>
        /// Gets or sets the ScanDocsNo of the AllEvents.
        /// </summary>
        //[DataObjectField(false, false, true, 2)]
        //[NotMapped]
        public int ScanDocsNo { get; set; }

        //public Facility Facility { get; init; } = new Facility(); 

        //public LogType LogType { get; init; } = new LogType();

        //[NotMapped] public Employee Operator { get; init; } = new Employee();

        //[NotMapped] public Employee CreatedBy_Employee { get; init; } = new Employee();

        //[NotMapped] public Employee ModifiedBy_Employee { get; init; } = new Employee();

        //[NotMapped] public Employee NotifiedPerson_Employee { get; init; } = new Employee();

        //[NotMapped] public Employee UpdatedBy_Employee { get; init; } = new Employee();

        //[NotMapped] public Facility NotifiedFacility { get; init; } = new Facility();



        ///// <summary>
        ///// Gets or sets the eventSubject of the FlowChange.
        ///// </summary>
        //[DataObjectField(false, false, false)]
        //[DisplayName("Subject")]
        //[NotMapped]
        //public string EventSubject { get; set; }

        ///// <summary>
        ///// Gets or sets the eventDetails of the FlowChange.
        ///// </summary>
        //[DataObjectField(false, false, false)]
        //[NotNullOrEmpty(Key = "DetailsNotEmpty")]
        //[DisplayName("Details")]
        //[NotMapped]
        //public string? EventDetails { get; set; }



        #endregion
    }
}
