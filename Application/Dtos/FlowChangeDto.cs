using Core.Models.BusinessEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public partial record FlowChangeDto : EslFlowchange
    {
        [Display(Name = "Event ID / Revision")]
        public string EventIdentifier => EventID + " / " + Convert.ToString(EventID_RevNo);

        [Display(Name = "Event Hightlight")]
        public string EventHighlight
        {
            get
            {
                string _EventHighlight = String.Empty;
                _EventHighlight = "Meter ID: " + MeterID + _CrLf;
                if (Convert.ToDecimal(ChangeBy) < 0)
                {
                    _EventHighlight += "Decrease:  ";
                }
                else if (Convert.ToDecimal(ChangeBy) > 0)
                {
                    _EventHighlight += "Increase:  ";
                }

                _EventHighlight += ChangeBy + " " + ChangeByUnit + _CrLf;

                if (!String.IsNullOrEmpty(Convert.ToString(NewValue)))
                {
                    _EventHighlight += "New Value: " + Convert.ToString(NewValue) + " " + Unit + _CrLf;
                }

                _EventHighlight += "Effective Dt/Tm: " + EventDate.ToString("MM/dd/yyyy") + " " + EventTime + _CrLf;

                if (!String.IsNullOrEmpty(OffTime))
                {
                    _EventHighlight += "Time Off: " + OffTime + _CrLf;
                }

                if (!String.IsNullOrEmpty(RelatedTo))
                {
                    _EventHighlight += "Related to Event Nos.: " + RelatedTo + _CrLf;
                }

                if (!String.IsNullOrEmpty(WorkOrders))
                {
                    _EventHighlight += "Work Order Nos.: " + WorkOrders + _CrLf;
                }

                if (!String.IsNullOrEmpty(Notes))
                {
                    _EventHighlight += "Additional Notes: " + Notes + _CrLf;
                }

                // ToDo: Add ScanDocsNo when available, maybe from a ScanDocService
                //_EventHighlight += "Scanned docs stored: " + ScanDocsNo;

                return _EventHighlight;
            }


        }

        public string EventHeader
        {
            get
            {
                string _EventHeader = "Details for ";
                if (Accepted == "Y")
                {
                    _EventHeader += "Real Time ";
                }
                else
                {
                    _EventHeader += "Pre-Scheduled ";
                }
                _EventHeader += "Flow Change on MeterID " + MeterID + " on " + EventDate.ToString("MM/dd/yyyy") + " at " + EventTime;

                return _EventHeader;
            }
        }

        [Display(Name = "Action History")]
        public string EventTrail { get; set; } = null!;
        //{
        //    get
        //    {
        //        string _EventTrail = String.Empty;

        //        if (RequestedBy != 0)
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
        //}

        public string _CrLf = Environment.NewLine;
    }
}
