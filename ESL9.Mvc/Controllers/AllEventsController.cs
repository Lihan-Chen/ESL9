using Application.Dtos;
using Application.Interfaces.IServices;
using Core.Models.BusinessEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Mvc.Models;
using Mvc.ViewModels;
using Newtonsoft.Json;
using X.PagedList;
using X.PagedList.Extensions;
using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;

namespace Mvc.Controllers
{
    [Authorize]
    public class AllEventsController(IAllEventService allEventService, ICoreService coreService, ILogger<AllEventsController> logger) : BaseController<AllEventsController>(coreService, logger)
    {
        private readonly IAllEventService _allEventService = allEventService ?? throw new ArgumentNullException(nameof(allEventService));
        private readonly ICoreService _coreService = coreService ?? throw new ArgumentNullException(nameof(coreService));

        private readonly ILogger<AllEventsController> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
       
        int _facilNo;
        int _logTypeNo;
        string _eventID = string.Empty;
        int _eventID_RevNo;

        string _facilName = string.Empty;
        string _logTypeName = string.Empty;

        string? _startDate;
        string? _endDate;

        DateOnly? initialStartDate;

        string _operatorType = String.Empty;
        bool _opType = true;

        // GET: /AllEvents/
        [HttpGet("AllEvents")]
        public async Task<IActionResult> Index(/*[FromBody]*/ _LogFilterPartialViewModel? logFilterPartial, int? page = null)
        {
            string? returnUrl = HttpContext.Request.Query.TryGetValue("ReturnUrl", out var returnUrlValues) ? returnUrlValues.ToString() : null;

            ISession session = HttpContext!.Session;

            //if (!IsUserCheckedIn)
            //{
            //    return RedirectToAction("CheckIn", "Home");
            //}

            if (logFilterPartial?.SelectedFacilNo is null) // First time visit => Check TempData
            {
                //int.TryParse(GetClaimValue(User, AppConstants.DefaultFacilNoClaimType), out int _defaultFacilNo);

                if (TempData.ContainsKey("LogFilter"))
                {
                    var logFilterJson = TempData["LogFilter"] as string;
                    if (!string.IsNullOrEmpty(logFilterJson))
                    {
                        logFilterPartial = JsonConvert.DeserializeObject<_LogFilterPartialViewModel>(logFilterJson);
                    }
                }
                else
                {
                    logFilterPartial = new _LogFilterPartialViewModel
                    {
                        SelectedFacilNo = UserAssignedFacilNo, // DefaultFacilNo, // ViewData["SelectedFacilNo"], //GetSessionValue<int?>(AppConstants.SelectedFacilNoSessionKey), // DefaultFacilNo,
                        // SelectedLogTypeNo = GetSessionValue<int?>(AppConstants.SelectedLogTypeNoSessionKey), // DefaultLogTypeNo,
                        StartDate = DefaultStartDate,
                        EndDate = DefaultEndDate,
                        CurrentFilter = string.Empty,
                        OperatorType = true // DefaultOperatorType
                    }; 
                }

            }

            _facilNo = logFilterPartial?.SelectedFacilNo ?? (int)DefaultFacilNo!; // _facilNoNullable.Value;

            var facility = _coreService.GetFacility(_facilNo).Result;
           
            _facilName = facility?.FacilName ?? string.Empty;

            // Set up default values
            DateOnly _enDt = logFilterPartial?.EndDate ?? Tomorrow; // now.Date; 
            DateOnly _stDt = logFilterPartial?.StartDate ?? _enDt.AddDays(DaysOffSet); //initialStartDate; 

            // force start date to be two days before end date
            if (_stDt > _enDt)
            {
                _stDt = _enDt.AddDays(DaysOffSet);
            }

            session.SetString("startDate", _stDt.ToString() ?? string.Empty);

            session.SetString("endDate", _enDt.ToString());

            string searchString = logFilterPartial?.CurrentFilter ?? string.Empty;

            _opType = logFilterPartial?.OperatorType ?? true;

            var facilAbbrList = await _coreService.GetFacilList(); //GetFacilAbbrList();
            var logTypeNames = await _coreService.GetLogTypeList(); // GetLogTypeNames();

            _LogFilterPartialViewModel _logFilterPartial = new _LogFilterPartialViewModel
            {
                SelectedFacilNo = _facilNo, //DefaultFacilNo,
                SelectedLogTypeNo = _logTypeNo, // _httpContext.Session.GetInt32("SelectedLogTypeNo");
                StartDate = _stDt, // DateOnly.FromDateTime(DateTime.Now.AddDays(-1)),
                EndDate = _enDt, //DateOnly.FromDateTime(DateTime.Now.AddDays(1))
                OperatorType = _opType,
                CurrentFilter = searchString,
                facilNos = GetSelectList<FacilDto>(facilAbbrList, "FacilNo", "FacilAbbr", _facilNo), //new SelectList(facilAbbrList, "FacilNo", "FacilAbbr", _facilNo),
                logTypeNos = GetSelectList<string>(logTypeNames, "LogTypeNo", "LogTypeName", _logTypeNo) //new SelectList(logTypeNames, "LogTypeNo", "LogTypeName", _logTypeNo)
            };  

            var viewModel = new AllEventsOutstanding()
            {
                logFilterPartial = _logFilterPartial
            };

            var selectedFacility = await _coreService.GetFacility(_facilNo);
            ViewBag.FacilSelected = selectedFacility?.FacilName ?? string.Empty;
            ViewBag.Title = "All Events for " + _facilName;
            ViewBag.ShowSearchList = true;
            //string _startDate = _stDt.HasValue ? _stDt.Value.ToString("MM/dd/yyyy") : String.Empty;
            //string _endDate = _enDt.ToString("MM/dd/yyyy");
            bool _operatorType = _opType;

            var allEvents = await _allEventService.GetAllEventsAsync(_facilNo, _stDt, _enDt, searchString, _opType);

            if (allEvents != null)
            {
                int _Count = allEvents.Count();

                int pageSize = _pageSize;
                int pageIndex = (page ?? 1);
                IPagedList<ViewAllEventsCurrent> allEventAsIPagedList = allEvents.ToPagedList(pageIndex, pageSize, _Count);

                viewModel.count = _Count;
                viewModel.AllEventsPagedList = allEventAsIPagedList;
            }
            else
            {
                ViewBag.Message = "There are no records found.";
                
                ViewBag.ShowSearchList = false;

                return View("Index", viewModel);
            }

            //ViewBag.Shift = GetSessionValue<string>(AppConstants.AssignedShiftNoSessionKey)?.ToString();

            return View("Index", viewModel);
        }

        //[HttpGet]
        //[Route("LogFilter")]
        //public IActionResult LogFilter(_LogFilterPartialViewModel? logFilterPartial)
        //{
        //    if (logFilterPartial is null)
        //    {
        //        logFilterPartial = new _LogFilterPartialViewModel
        //        {
        //            SelectedFacilNo = HttpContext.Session.GetInt32("SelectedFacilNo"),
        //            StartDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-1)),
        //            EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1))
        //        };
        //        //logFilterPartial.CurrentFilter = string.Empty,
        //        //        OperatorType operatorType ?? false,

        //    }

        //    ViewData["Title"] = "All Events";
        //    return View("LogFilter", logFilterPartial);
        //}  
        
        //[HttpPost]
        //public IActionResult LogFilterSubmitted(_LogFilterPartialViewModel? logFilterPartial)
        //{
        //    if (logFilterPartial is null)
        //    {
        //        logFilterPartial = new _LogFilterPartialViewModel
        //        {
        //            SelectedFacilNo = HttpContext.Session.GetInt32("SelectedFacilNo"),
        //            StartDate = DefaultStartDate,
        //            EndDate = DefaultEndDate
        //        };
        //        //logFilterPartial.CurrentFilter = string.Empty,
        //        //        OperatorType operatorType ?? false,

        //    }

        //    DateOnly? startDate = logFilterPartial.StartDate;

        //    ViewData["Title"] = "All Events";
        //    return View("LogFilter", logFilterPartial);
        //}

        //[GET("Details")]
        //private static AllEventDetails GetLogDetails(int _facilNo, int logTypeNo, string eventID, int eventID_RevNo)
        //{
        //    int facilNo = _facilNo;
        //    string eventHighlight = string.Empty;
        //    string eventTrail = string.Empty;

        //    switch (logTypeNo)
        //    {
        //        case 1: //Clearance
        //            eventHighlight = ClearanceIssuesManager.GetItem(facilNo, logTypeNo, eventID, eventID_RevNo).EventHighlight;
        //            eventTrail = ClearanceIssuesManager.GetItem(facilNo, logTypeNo, eventID, eventID_RevNo).EventTrail;
        //            break;
        //        case 2: //ClearanceTransfer
        //            //eventHighlight = ClearanceTransferManager.GetItem(facilNo, logTypeNo, eventID, eventID_RevNo).EventHighlight;
        //            //eventTrail = ClearanceTransferManager.GetItem(facilNo, logTypeNo, eventID, eventID_RevNo).EventTrail;
        //            break;
        //        case 3: //SOC
        //            eventHighlight = SOCManager.GetItem(facilNo, logTypeNo, eventID, eventID_RevNo).EventHighlight;
        //            eventTrail = SOCManager.GetItem(facilNo, logTypeNo, eventID, eventID_RevNo).EventTrail;
        //            break;
        //        case 4: //EOS
        //            eventHighlight = EOSManager.GetItem(facilNo, logTypeNo, eventID, eventID_RevNo).EventHighlight;
        //            eventTrail = EOSManager.GetItem(facilNo, logTypeNo, eventID, eventID_RevNo).EventTrail;
        //            break;
        //        case 5: //FlowChange
        //            eventHighlight = FlowChangeManager.GetItem(facilNo, logTypeNo, eventID, eventID_RevNo).EventHighlight;
        //            eventTrail = FlowChangeManager.GetItem(facilNo, logTypeNo, eventID, eventID_RevNo).EventTrail;
        //            break;
        //        case 6: //General
        //            eventHighlight = GeneralManager.GetItem(facilNo, logTypeNo, eventID, eventID_RevNo).EventHighlight;
        //            eventTrail = GeneralManager.GetItem(facilNo, logTypeNo, eventID, eventID_RevNo).EventTrail;
        //            break;
        //        default:
        //            break;
        //    }

        //    AllEventDetails myAllEventDetails = new AllEventDetails
        //    {
        //        FacilNo = facilNo,
        //        LogTypeNo = logTypeNo,
        //        EventID = eventID,
        //        EventID_RevNo = eventID_RevNo,
        //        EventHighlight = eventHighlight,
        //        EventTrail = eventTrail
        //    };

        //    return myAllEventDetails;
        //}

        public async Task<IActionResult> LogSearchAsync(int facilNo, DateOnly startDate, DateOnly endDate, bool operatorType)
        {
            _facilNo = facilNo;
            startDate = startDate > endDate ? endDate.AddDays(DaysOffSet) : startDate;

            _endDate = endDate.ToString("MM/dd/yyyy");
            _startDate = startDate.ToString("MM/dd/yyyy");

            string _operatorType = operatorType == true ? "Primary" : "Secondary";

            ViewBag.StartDate = _startDate;
            ViewBag.EndDate = _endDate;

            // Use await for asynchronous calls
            var allEvents = await _allEventService.GetList(_facilNo, _logTypeNo, _startDate, _endDate, null, _operatorType);

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")  // IsAjaxRequest()
            {
                if (allEvents != null)
                {
                    int _Count = allEvents.Count();
                    ViewBag.FacilNoSelected = facilNo;
                    ViewBag.FacilSelected = (await _coreService.GetFacility(_facilNo))?.FacilName;
                    var logTypeNames = (await _coreService.GetLogType(_logTypeNo))?.LogTypeName;

                    AllEventsViewModel allEventsViewModel = new AllEventsViewModel
                    {
                        FacilNo = _facilNo,
                        StartDate = startDate.ToDateTime(TimeOnly.MinValue),
                        EndDate = endDate.ToDateTime(TimeOnly.MaxValue),
                        OperatorType = operatorType,
                        Count = _Count,
                        logTypeNos = new SelectList(logTypeNames, "Value", "Text"),
                        AllEventList = [.. allEvents]
                    };

                    return PartialView("_LogSearch", allEventsViewModel);
                }
                else
                {
                    ViewBag.Message = "There are no records found.";
                    return PartialView();
                }
            }

            return RedirectToAction("LogSearch", "AllEvents", new { facilNo = _facilNo, StartDate = _startDate, EndDate = _endDate, operatorType = _operatorType });
        }

        //public ActionResult Rev(int facilNo, int logTypeNo, string eventID, int eventID_RevNo, string act)
        //{
        //    _facilNo = facilNo;
        //    string targetController = GetLogTypeName(logTypeNo);
        //    string targetAction = string.Empty;
        //    string _act = act;
        //    AllEvent _allEvent = AllEventManager.GetItem(facilNo, logTypeNo, eventID, eventID_RevNo);
        //    switch (targetController)
        //    {
        //        case "Clearance":
        //            //check if the selected Clearance is the most current log
        //            int _maxRevNo = ClearanceIssuesManager.GetMaxRevNo(facilNo, eventID);
        //            if (eventID_RevNo < _maxRevNo)
        //            {
        //                ViewBag.eventID = eventID;
        //                ViewBag.eventID_RevNo = eventID_RevNo;
        //                string _alert = "There is a newer log than the one selected.  You can revise: " + eventID + "-" + _maxRevNo.ToString();
        //                // string _alert = "There is a newer log than the one selected.  You can revise the latest from <a href='AllEvents/Rev?facilNo=" + facilNo.ToString() + "&logTypeNo=" + logTypeNo.ToString() + "&eventID=" + eventID + "&eventID_RevNo="
        //                //                    + _maxRevNo.ToString() + "'>HERE</a>";
        //                return RedirectToAction("Index", "Clearance", new { alert = _alert });
        //            }
        //            else
        //            {
        //                if (_allEvent.Subject.Contains("Issue"))
        //                {
        //                    targetAction = targetController + "Issue";
        //                }
        //                else if (_allEvent.Subject.Contains("Release"))
        //                {
        //                    targetAction = targetController + "Release";
        //                }
        //                else if (_allEvent.Subject.Contains("Transfer"))
        //                {
        //                    targetAction = targetController + "Transfer";
        //                }
        //            }
        //            break;

        //        case "SOC":
        //            if (_allEvent.Subject.Contains("Issue"))
        //            {
        //                targetAction = "LogIssue";
        //            }
        //            else if (_allEvent.Subject.Contains("Release"))
        //            {
        //                targetAction = "LogRelease";
        //            }
        //            break;

        //        case "EOS":
        //            if (_allEvent.Subject.Contains("Issue"))
        //            {
        //                targetAction = "LogIssue";
        //            }
        //            else if (_allEvent.Subject.Contains("Release"))
        //            {
        //                targetAction = "LogRelease";
        //            }
        //            break;

        //        case "FlowChange":
        //            targetAction = "Revise";
        //            break;

        //        case "General":
        //            targetAction = targetController + "Issue";
        //            break;
        //    }

        //    return RedirectToAction(targetAction, targetController, new { facilNo = _facilNo, eventID = eventID, eventID_RevNo = eventID_RevNo, act = _act });
        //}

        //public ActionResult Del(int facilNo, int logTypeNo, string eventID, int eventID_RevNo)
        //{
        //    string _act = "Deleted";
        //    return RedirectToAction("Rev", "AllEvents", new { facilNo = facilNo, logTypeNo = logTypeNo, eventID = eventID, eventID_RevNo = eventID_RevNo, act = _act });
        //}

        //public ActionResult Report(int facilNo, DateTime? startDate, DateTime? endDate, string rptOption, string searchString)
        //{
        //    DateTime StDt = startDate.HasValue ? startDate.Value.Date : now.Date;
        //    DateTime EnDt = endDate.HasValue ? endDate.Value.Date : StDt.AddDays(1);

        //    string _startDate = StDt.ToString("yyyyMMdd");
        //    string _endDate = EnDt.ToString("yyyyMMdd");
        //    string _shiftStartTime;
        //    string _shiftEndTime;

        //    if (rptOption == "Day")
        //    {
        //        _shiftStartTime = shiftStartText;
        //        _shiftEndTime = shiftEndText;
        //        EnDt = StDt;
        //        _endDate = _startDate;
        //    }
        //    else if (rptOption == "Night")
        //    {
        //        _shiftStartTime = "18:00:00";
        //        _shiftEndTime = "05:59:00";
        //        EnDt = StDt.AddDays(1);
        //        _endDate = EnDt.ToString("yyyyMMdd");
        //    }
        //    else
        //    {
        //        rptOption = String.Empty;
        //        _shiftStartTime = "00:00";
        //        _shiftEndTime = "23:59";
        //    }

        //    // get the Date value from DatetTime? and add time
        //    DateTime _StDTime = StDt.Add(TimeSpan.Parse(_shiftStartTime));
        //    DateTime _EnDTime = EnDt.Add(TimeSpan.Parse(_shiftEndTime));

        //    // DateTime _EnDTime = endDate.Value.Date.AddDays(1).Add(TimeSpan.Parse(_shiftEndTime));

        //    Report _Report = new Report();

        //    var _report = AllEventManager.GetReport(facilNo, _startDate, _endDate).AsEnumerable();

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        _report = _report.Where(r => r.EventID.ToUpper().Contains(searchString.ToUpper())
        //                       || r.Subject.ToUpper().Contains(searchString.ToUpper())
        //                       || r.Details.ToUpper().Contains(searchString.ToUpper()));
        //    }

        //    if (_report != null)
        //    {
        //        _report = _report.Where(r => r.EventDate.Add(TimeSpan.Parse(r.EventTime)) >= _StDTime && r.EventDate.Add(TimeSpan.Parse(r.EventTime)) <= _EnDTime);

        //        // manually cast var to Report
        //        foreach (var _r in _report)
        //        {
        //            Rpt _R = new Rpt()
        //            {
        //                FacilNo = _r.FacilNo,
        //                FacilName = _r.FacilName,
        //                LogTypeNo = _r.LogTypeNo,
        //                LogTypeName = _r.LogTypeName,
        //                EventID = _r.EventID,
        //                EventID_RevNo = _r.EventID_RevNo,
        //                Subject = _r.Subject,
        //                Details = _r.Details,
        //                EventDate = _r.EventDate,
        //                EventTime = _r.EventTime,
        //                UpdatedByName = _r.UpdatedByName,
        //                UpdateDate = _r.UpdateDate
        //            };

        //            _Report.Add(_R);
        //            // _Report.Insert(
        //        }
        //    }

        //    RptViewModel _rptViewModel = new RptViewModel()
        //    {
        //        report = _Report // (Report)AllEventManager.GetReport(facilNo, _startDate, _endDate) // .Where(r => r.EventDate.Add(TimeSpan.Parse(r.EventTime)) >= _StDTime && r.EventDate.Add(TimeSpan.Parse(r.EventTime)) <= _EnDTime)

        //    };

        //    rptOption = rptOption == "Day" ? rptOption + " Shift" : rptOption == "Night" ? rptOption + " Shift" : "Daily";

        //    ViewBag.Title = FacilName + " " + rptOption + " Report for " + StDt.ToString("MM/dd/yyyy") + " " + _shiftStartTime + " to " + EnDt.ToString("MM/dd/yyyy") + " " + _shiftEndTime;

        //    if (_rptViewModel.report.Count() > 0)
        //    {
        //        ViewBag.ShowSearchList = true;
        //    }
        //    else
        //    {
        //        ViewBag.Message = "There are no logs to report.";
        //    }

        //    return View("Report", _rptViewModel);
        //}

        //#region Helpers


        //Example: passing Json to view to generate selectList
        [HttpGet("SelectList")]
        [OutputCache(PolicyName = "Cache12Hours")]
        public async Task<IActionResult> ESLUserAutoCompleteListAsync(string term)
        {
            int _facilNo = FacilNo ?? (int)(GetSessionValue<object>(AppConstants.SelectedFacilNoSessionKey) ?? 0);

            var eList = _coreService.GetActiveEmployeeListByFacilNo(_facilNo).Result;
            var empList = eList.AsQueryable().OrderBy(e => e.EmployeeID).Select(e => new { label = $"{e.FirstName} {e.LastName}", EmpID = e.EmployeeID });

            if (!String.IsNullOrEmpty(term))
            {
                empList = empList.Where(e => e.label.ToLower().Contains(term.ToLower())).OrderBy(x => x.label);
            }

            return Ok(empList);
        }
    }
}

