using Core.Models.BusinessEntities;

namespace Core.Models.ValueObjects
{
    public partial record BaseOperator: Employee
    {
        ///// <summary>
        ///// Gets or sets the OperatorID of the FlowChange.
        ///// </summary>
        //[DataObjectField(false, false, false, 7)]
        //[DisplayName("Operator")]
        //[Required(ErrorMessage = "Need to select a name from pull-down list.  Please try again.")]
        //public int OperatorID { get; set; }

        /// <summary>
        /// Gets or sets the OperatorType of the FlowChange.
        /// </summary>
        public string OperatorType { get; set; } = null!;

        /// <summary>
        /// Gets or sets the ShiftNo of the FlowChange.
        /// </summary>
        public int? ShiftNo { get; set; }

        public virtual Employee Operator { get; set; } = new Employee();

    }
}
