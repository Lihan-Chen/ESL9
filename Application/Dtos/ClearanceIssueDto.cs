using Application.Interfaces.IServices;
using Core.Models.BusinessEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public record ClearanceIssueDto(ICoreService coreService) : EslClearanceIssue
    {
        private readonly ICoreService _coreService = coreService ?? throw new ArgumentNullException(nameof(coreService));

        string _CrLf = System.Environment.NewLine; // "<br />";

        public string EventIdentifier => $"{ClearanceID} / {EventID_RevNo}";
        
        /// <summary>
        /// Gets or sets the eventHighlight of the FlowChange.
        /// </summary>
        public string EventHighlight
        {
            get
            {
                string _EventHighlight = String.Empty;
                if (!String.IsNullOrEmpty(Location))
                {
                    _EventHighlight = $"Location: { Location}{_CrLf}";
                }

                if (!String.IsNullOrEmpty(ClearanceZone))
                {
                    _EventHighlight += $"Clearance Area: {ClearanceZone}{_CrLf}";
                }

                if (!String.IsNullOrEmpty(WorkToBePerformed))
                {
                    _EventHighlight += $"Work to be performed: { WorkToBePerformed}{ _CrLf}";
                }

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

                //_EventHighlight += $"Scanned docs stored: {ScanDocsNo}";

                return _EventHighlight;
            }
        }

        // need to add "Scanned Docs Stored: " (scandocs.count) when scanned docs directory are established on servers, or just ignore for now.

        /// <summary>
        /// Gets or sets the eventTrail of the FlowChange.
        /// </summary>
        //public string EventTrail
        //{
        public async Task<string> GetEventTrailAsync()
        {
            string _EventTrail = String.Empty;
            string _ReleasedBy = String.Empty;
            string _ReleasedTo = String.Empty;

            _EventTrail = "Issued to: " + await _coreService.GetFullNameByEmployeeNo(IssuedTo) + _CrLf;
            _EventTrail += "Issued by: " + await _coreService.GetFullNameByEmployeeNo(IssuedBy) + _CrLf;

            if (IssuedDate != DateTime.MinValue)
            {
                _EventTrail += $"Requested Dt/Tm: {IssuedDate.ToString("MM/dd/yyyy")} {IssuedTime}{_CrLf}";
            }

            _ReleasedBy = ReleasedBy != null ? await _coreService.GetFullNameByEmployeeNo((int)ReleasedBy) : "n/a";
            _ReleasedTo = ReleasedTo != null ? await _coreService.GetFullNameByEmployeeNo((int)ReleasedTo) : "n/a";

            switch (ReleaseType)
            {
                case "Full Release":
                    _EventTrail += $"Full Released by: {_ReleasedBy}{_CrLf}Full Released to: {_ReleasedTo}{_CrLf}";
                    _EventTrail += $"Full Released Dt/Tm: " + (ReleasedDate.HasValue ? ReleasedDate.Value.ToString("MM/dd/yyyy") : "n/a") + $" {ReleasedTime}{_CrLf}";
                    break;
                case "Test Release":
                    _EventTrail += $"Test Released by: " + _ReleasedBy + _CrLf + "Test Released to: " + _ReleasedTo + _CrLf;
                    _EventTrail += $"Test Released Dt/Tm: " + (ReleasedDate.HasValue ? ReleasedDate.Value.ToString("MM/dd/yyyy") : "n/a") + $" {ReleasedTime}{_CrLf}";
                    break;
                case "Transfer":
                    _EventTrail += $"Released by: {_ReleasedBy}{_CrLf}Full Released to: {_ReleasedTo}{_CrLf}";
                    _EventTrail += $"Released Dt/Tm: " + (ReleasedDate.HasValue ? ReleasedDate.Value.ToString("MM/dd/yyyy") : "n/a") + $" {ReleasedTime}{_CrLf}";
                    break;
            }

            _EventTrail += $"Logged By: {await _coreService.GetFullNameByEmployeeNo((int)OperatorID)}{_CrLf}";
            _EventTrail += $"Logged Dt/Tm: {UpdateDate.ToString("MM/dd/yyyy hh:mm")}{_CrLf}";

            if (NotifiedPerson is not null)
            {
                _EventTrail += $"Notified Person: {await _coreService.GetFullNameByEmployeeNo((int)NotifiedPerson)}{_CrLf}";
            }

            return _EventTrail;
        }       
    }
}
