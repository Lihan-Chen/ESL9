using Core.Models.BusinessEntities;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    /// <summary>
    /// This corresponds to ViewAllEventsLogType (VIEW_ALLEVENTS_LOGTYPES) view in the database.
    /// </summary>
    public partial record LogTypeDto : ViewAllEventsLogType
    {

    }
}
