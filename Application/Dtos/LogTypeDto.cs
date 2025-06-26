using Core.Models.BusinessEntities;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    /// <summary>
    /// This corresponds to ViewAllEventsLogType (VIEW_ALLEVENTS_LOGTYPES) view in the database.
    /// </summary>
    public partial record LogTypeDto : ViewAllEventsLogType
    {
        ////[Precision(2)]
        //public int LogTypeNo { get; set; }

        //[StringLength(100)]
        ////[Unicode(false)]
        //public string LogTypeName { get; set; } = null!;
    }
}
