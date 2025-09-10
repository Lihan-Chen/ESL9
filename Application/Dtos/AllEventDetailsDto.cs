using Core.Models.BusinessEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public record AllEventDetailsDto : AllEvent
    {
        [Display(Name = "Event ID / Revision")]
        public string EventIDentifier => $"{EventID}/{EventID_RevNo}";

        public string EventHighlight => (String.IsNullOrEmpty(Subject) ? string.Empty : (Subject + _CrLf)) + 
                                        (String.IsNullOrEmpty(Details)? String.Empty : (Details + _CrLf)) + 
                                        "Updated By: " + UpdatedBy + " on " + UpdateDate;

        [Display(Name = "Event Hightlight")]
        public string EventHeader { get; set; } = null!;
        //{
        //    get
        //    {
        //        string _EventHeader = "Details for ";
        //        if (Accepted == "Y")
        //        {
        //            _EventHeader += "Real Time ";
        //        }
        //        else
        //        {
        //            _EventHeader += "Pre-Scheduled ";
        //        }
        //        _EventHeader += "Flow Change on MeterID " + MeterID + " on " + EventDate.ToString("MM/dd/yyyy") + " at " + EventTime;

        //        return _EventHeader;
        //    }
        //}

        [Display(Name = "Action History")]
        public string EventTrail { get; set; }  = null!;
        //{
        //    get
        //    {
        //        string _EventTrail = String.Empty;

        //        if (RequestedBy != 0 && RequestedBy.HasValue)
        //        {
        //            _EventTrail = "Requested By: " + Helpers.GetEmpFullName("RequestedBy", RequestedBy, FacilNo) + _CrLf;
        //        }
        //        else
        //        {
        //            _EventTrail = "Requested By: " + "n/a" + _CrLf;
        //        }

        //        if (RequestedTo != 0)
        //        {
        //            _EventTrail += "Requested To: " + Helpers.GetEmpFullName("RequestedTo", RequestedTo, FacilNo) + _CrLf;
        //        }
        //        else
        //        {
        //            _EventTrail += "Requested To: " + "n/a" + _CrLf;
        //        }

        //        if (RequestedDate != null)
        //        {
        //            _EventTrail += "Requested Dt/Tm: " + RequestedDate.ToString("MM/dd/yyyy") + " " + RequestedTime + _CrLf;
        //        }
        //        else
        //        {
        //            _EventTrail += "Requested Dt/Tm: " + "n/a" + _CrLf;
        //        }

        //        if (OperatorID != 0)
        //        {
        //            _EventTrail += "Logged By: " + Helpers.GetEmpFullName("OperatorID", OperatorID, FacilNo) + _CrLf;
        //            _EventTrail += "Logged Dt/Tm: " + UpdateDate.ToString("MM/dd/yyyy hh:mm") + _CrLf;
        //        }
        //        else
        //        {
        //            _EventTrail += "Logged By: " + "n/a" + _CrLf;
        //            _EventTrail += "Logged Dt/Tm: " + "n/a" + _CrLf;
        //        }

        //        if (NotifiedPerson.HasValue)
        //        {
        //            _EventTrail += "Notified Person: " + Helpers.GetEmpFullName("NotifiedPerson", NotifiedPerson.Value, FacilNo) + _CrLf;
        //        }
        //        else
        //        {
        //            _EventTrail += "Notified Person: " + "n/a";
        //        }

        //        return _EventTrail;
        //    }
        public string _CrLf = Environment.NewLine;

        public virtual AllEvent AllEvent { get; set; } = null!;
    }
    
}
