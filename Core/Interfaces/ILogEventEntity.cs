namespace Core.Interfaces
{
    public interface ILogEventEntity : IEventEntity
    {
        #region Internal Variables

        #endregion

        #region Public Properties

        ///// <summary>
        ///// Gets or sets the FacilName of the event.
        ///// </summary>
        //public int FacilNo { get; set; }

        /// <summary>
        /// Gets or sets the FacilName of the event.
        /// </summary>
        /// 
        public string FacilName { get; set; }

        ///// <summary>
        ///// Gets or sets the LogTypeNo of the FlowChange.
        ///// </summary>
        //public int LogTypeNo { get; set; }

        /// <summary>
        /// Gets or sets the LogTypeName of the FlowChange.
        /// </summary>
        public string LogTypeName { get; set; }

        ///// <summary>
        ///// Gets or sets the EventID of the FlowChange.
        ///// </summary>
        //public string EventID { get; set; }

        ///// <summary>
        ///// Gets or sets the EventID_RevNo of the FlowChange.
        ///// </summary>
        //public int EventID_RevNo { get; set; }

        /// <summary>
        /// Gets or sets the OperatorID of the FlowChange.
        /// </summary>
        public int OperatorID { get; set; }

        /// <summary>
        /// Gets or sets the CreatedBy of the FlowChange.
        /// </summary>
        public int? CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the CreatedDate of the FlowChange.
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the ModifyFlag of the FlowChange.
        /// </summary>
        public string? ModifyFlag { get; set; }

        /// <summary>
        /// Gets or sets the ModifiedBy of the FlowChange.
        /// </summary>
        public int? ModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the modifyDate of the FlowChange.
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets the notes of the FlowChange.
        /// </summary>
        public string? Notes { get; set; }

        /// <summary>
        /// Gets or sets the NotifiedFacil of the FlowChange.
        /// </summary>
        public string? NotifiedFacil { get; set; }

        /// <summary>
        /// Gets or sets the NotifiedPerson of the FlowChange.
        /// </summary>
        public int? NotifiedPerson { get; set; }

        /// <summary>
        /// Gets or sets the NotifiedPerson of the FlowChange.
        /// </summary>
        public string? NotifiedPerson_Name { get; }

        /// <summary>
        /// Gets or sets the ShiftNo of the FlowChange.
        /// </summary>
        public int? ShiftNo { get; set; }
        /// <summary>
        /// Gets or sets the yr of the FlowChange.
        /// </summary>
        public string Yr { get; set; }

        /// <summary>
        /// Gets or sets the SeqNo of the FlowChange.
        /// </summary>
        public int SeqNo { get; set; }

        ///// <summary>
        ///// Gets or sets the UpdatedBy of the FlowChange.
        ///// </summary>
        //public string UpdatedBy { get; set; }

        ///// <summary>
        ///// Gets or sets the UpdateDate of the FlowChange.
        ///// </summary>
        //public DateTime UpdateDate { get; set; }

        /// <summary>
        /// Gets or sets the WorkOrders of the FlowChange.
        /// </summary>
        public string? WorkOrders { get; set; }

        /// <summary>
        /// Gets or sets the RelatedTo of the FlowChange.
        /// </summary>
        public string? RelatedTo { get; set; }

        /// <summary>
        /// Gets or sets the OperatorType of the FlowChange.
        /// </summary>
        public string? OperatorType { get; set; }


        /// <summary>
        /// Gets or sets the ScanDocsNo of the AllEvents.
        /// </summary>
        public int ScanDocsNo { get; set; }

        #endregion
    }
}

