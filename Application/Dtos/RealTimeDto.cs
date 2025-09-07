using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    #region Public Properties
    
    public record RealTimeDto
    {
        public int FacilNo { get; set; }

        /// <summary>
        /// Gets or sets the logTypeNo of the AllEvents.
        /// </summary>

        public int LogTypeNo { get; set; }

        /// <summary>
        /// Gets or sets the eventID of the AllEvents.
        /// </summary>
 
        public string EventID { get; set; } = null!;

        /// <summary>
        /// Gets or sets the eventID_RevNo of the AllEvents.
        /// </summary>
        public int EventID_RevNo { get; set; }

        /// <summary>
        /// Gets or sets the eventDate of the AllEvents.
        /// </summary>
        public DateTime EventDateTime { get; set; }

        /// <summary>
        /// Gets or sets the subject of the AllEvents.
        /// </summary>
        public string Subject { get; set; } = null!;

    #endregion

    }
}
