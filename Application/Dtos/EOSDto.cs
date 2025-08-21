using Application.Interfaces.IServices;
using Core.Models.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public record EOSDto(ICoreService coreService) : EslEOS
    {
        private readonly ICoreService _coreService = coreService ?? throw new ArgumentNullException(nameof(coreService));

        string _CrLf = System.Environment.NewLine; // "<br />";

        public string EventIdentifier => $"{EventID} / {EventID_RevNo}";

        public string EventHighlight
        {
            get
            {
                string _EventHighlight = String.Empty;

                _EventHighlight = $"Location: {Location}{_CrLf}";

                if (!String.IsNullOrEmpty(EquipmentInvolved))
                {
                    _EventHighlight += $"Equipment involved: {EquipmentInvolved}{_CrLf}";
                }

                if (!String.IsNullOrEmpty(RelatedTo))
                {
                    _EventHighlight += $"Related to Event Nos.: {RelatedTo}{_CrLf}";
                }

                if (!String.IsNullOrEmpty(WorkOrders))
                {
                    _EventHighlight += $"Work Order Nos.: {WorkOrders}{_CrLf}";
                }

                if (!String.IsNullOrEmpty(Notes))
                {
                    _EventHighlight += $"Additional Notes: {Notes}{_CrLf}";
                }

                if (!String.IsNullOrEmpty(ReleaseType))
                {
                    _EventHighlight += $"Tags removed: {TagsRemoved}";
                }

                //_EventHighlight += "Scanned docs stored: " + ScanDocsNo;

                return _EventHighlight;
            }
        }

        public async Task<string> GetEventTrailAsync()
        {
            string _EventTrail = String.Empty;
            string _ReportedBy = String.Empty;
            string _ReportedTo = String.Empty;
            string _ReleasedBy = String.Empty;

            _ReportedBy = ReportedBy != null ? await _coreService.GetFullNameByEmployeeNo((int)ReportedBy) : "n/a";
            _ReportedTo = ReportedTo != null ? await _coreService.GetFullNameByEmployeeNo((int)ReportedTo) : "n/a";

            _EventTrail = $"Reported By: {_ReportedBy}{_CrLf}";

            if (ReportedTo != null)
            {
                _EventTrail += $"Reported To: {_ReportedTo}{_CrLf}";
            }

            if (ReportedDate != null)
            {
                _EventTrail += $"Reported Dt/Tm: {ReportedDate.Value.ToString("MM/dd/yyyy")} {ReportedTime}{_CrLf}";
            }

            _ReleasedBy = ReleasedBy != null ? await _coreService.GetFullNameByEmployeeNo((int)ReleasedBy) : "n/a";

            if (!String.IsNullOrEmpty(ReleaseType))
            {
                switch (ReleaseType)
                {
                    case "Full Release":
                        _EventTrail += $"Full Released by: {_ReleasedBy}{_CrLf}";
                        _EventTrail += $"Full Released Dt/Tm: " + (ReleasedDate.HasValue ? ReleasedDate.Value.ToString("MM/dd/yyyy") : "n/a") + $" {ReleasedTime}{_CrLf}";
                        break;
                    case "Test Release":
                        _EventTrail += $"Test Released by: {_ReleasedBy}{_CrLf}";
                        _EventTrail += $"Test Released Dt/Tm: " + (ReleasedDate.HasValue ? ReleasedDate.Value.ToString("MM/dd/yyyy") : "n/a") + $" {ReleasedTime}{_CrLf}";
                        break;
                    case "Transfer":
                        _EventTrail += $"Transferred by:  {_ReleasedBy}{_CrLf}";
                        _EventTrail += $"Transfer Dt/Tm: {ReleasedDate.Value.ToString("MM/dd/yyyy")} {ReleasedTime}{_CrLf}";
                        //_EventTrail += "Released Dt/Tm: " + ReleasedDate.ToString("MM/dd/yyyy") + " " + ReleasedTime + _CrLf;

                        //ToDo: Verify IssuedTo, IssuedDate, IssuedTime  (There are no such fields in EOS table)
                        //_EventTrail += "Transferred to: " + Issuedto != null ? Helpers.GetEmpFullName("ReleasedBy", ReleasedBy.Value, FacilNo) : "n/a" + _CrLf;;
                        //_EventTrail += "Transferred Dt/Tm: " + IssuedDate.ToString("MM/dd/yyyy") + " " + IssuedTime + _CrLf;
                        break;
                }
            }


            _EventTrail += $"Logged By: {await _coreService.GetFullNameByEmployeeNo((int)OperatorID)}{_CrLf}";
            _EventTrail += $"Logged Dt/Tm: " + UpdateDate.ToString("MM/dd/yyyy hh:mm") + _CrLf;

            if (NotifiedPerson != null)
            {
                _EventTrail += $"Notified Person: {await _coreService.GetFullNameByEmployeeNo((int)NotifiedPerson)}{_CrLf}";
            }

            return _EventTrail;
        }
    }
}
