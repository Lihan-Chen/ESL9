using Application.Interfaces.IServices;
using Core.Models.BusinessEntities;
using Core.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mvc.Models;
using Mvc.ViewModels;
using System.Composition;
using X.PagedList;
using X.PagedList.Extensions;

namespace Mvc.Controllers
{
    [Authorize]
    public class AllEventsController(IAllEventService allEventService, ICoreService coreService, ILogger<AllEventsController> logger) : BaseController<AllEventsController>(coreService, logger)
    {
        private readonly IAllEventService _allEventService = allEventService ?? throw new ArgumentNullException(nameof(allEventService));
        private readonly ICoreService _coreService = coreService ?? throw new ArgumentNullException(nameof(coreService));

        private readonly ILogger<AllEventsController> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        // GET: /AllEvents/
        int _facilNo;
        int _logTypeNo;
        string _eventID = string.Empty; // = string.Empty;
        int _eventID_RevNo;

        string _facilName = string.Empty;
        string _logTypeName;

        string? _startDate;
        string? _endDate;

        DateOnly? initialStartDate;

        string _operatorType = String.Empty;
        bool _opType = true;

        DateOnly tomorrow = DateOnly.FromDateTime(DateTime.Now.AddDays(1));

        int _daysOffSet = -2;

        [HttpGet("AllEvents")]
        public IActionResult Index([FromBody] _LogFilterPartialViewModel? logFilterPartial, int? facilNo, DateOnly? startDate, DateOnly? endDate, string? searchString, int? page, bool? operatorType)
        {
            //HttpContext? httpContext = _httpContextAccessor.HttpContext;

            //if (httpContext != null && httpContext.User != null && httpContext.User.Identity.IsAuthenticated)

            ISession session = HttpContext!.Session;

            int? _facilNoNullable = logFilterPartial?.SelectedFacilNo ?? facilNo ?? FacilNo;

            if (_facilNoNullable == null)
            {
                _logger.LogError("Facility not found for facilNo: {FacilNo}", _facilNoNullable);
                return NotFound("Facility not found.");
            }

            _facilNo = _facilNoNullable.Value;

            var facility = _coreService.GetFacility(_facilNo).Result;

            
            _facilName = facility?.FacilName ?? string.Empty;

            string? _shiftNoNullable = GetSessionValue<string>(AppConstants.AssignedShiftNoSessionKey);
            string _shiftNo = _shiftNoNullable ?? string.Empty;

            //  == "Day" ? 1 : 2;

            // Set up default values
            DateOnly _enDt = logFilterPartial?.EndDate ?? endDate ?? tomorrow; // now.Date; 
            DateOnly _stDt = logFilterPartial?.StartDate ?? startDate ?? _enDt.AddDays(_daysOffSet); //initialStartDate; 

            if (_stDt > _enDt)
            {
                _stDt = _enDt.AddDays(_daysOffSet);
            }

            session.SetString("startDate", _stDt.ToString() ?? string.Empty);

            session.SetString("endDate", _enDt.ToString());

            searchString = !String.IsNullOrEmpty(logFilterPartial?.CurrentFilter) ? logFilterPartial.CurrentFilter : searchString;

            _opType = operatorType ?? logFilterPartial?.OperatorType ?? true;

            // _shiftNo = System.Web.HttpContext.Current.Session["ShiftNo"].ToString() == "Day" ? 1 : 2;

            var facilAbbrList = _coreService.GetFacilTypeList().Result; //GetFacilAbbrList();
            var logTypeNames = _coreService.GetLogTypeList().Result; // GetLogTypeNames();

            _LogFilterPartialViewModel _logFilterPartial = new _LogFilterPartialViewModel
            {
                SelectedFacilNo = _facilNo, //DefaultFacilNo,
                SelectedLogTypeNo = _logTypeNo, // _httpContext.Session.GetInt32("SelectedLogTypeNo");
                StartDate = _stDt, // DateOnly.FromDateTime(DateTime.Now.AddDays(-1)),
                EndDate = _enDt, //DateOnly.FromDateTime(DateTime.Now.AddDays(1))
                OperatorType = _opType,
                CurrentFilter = searchString,
                facilNos = new SelectList(facilAbbrList, "FacilNo", "FacilAbbr", _facilNo),
                logTypeNos = new SelectList(logTypeNames, "LogTypeNo", "LogTypeName", _logTypeNo)
            };

            var viewmodel = new AllEventsOutstanding()
            {
                logFilterPartial = _logFilterPartial
            };

            var selectedFacility = _coreService.GetFacility(_facilNo).Result;
            ViewBag.FacilSelected = selectedFacility?.FacilName ?? string.Empty;
            ViewBag.Title = "All Events for " + _facilName;
            ViewBag.ShowSearchList = true;
            //string _startDate = _stDt.HasValue ? _stDt.Value.ToString("MM/dd/yyyy") : String.Empty;
            //string _endDate = _enDt.ToString("MM/dd/yyyy");
            bool _operatorType = _opType;

            var allEvents = _allEventService.GetAllEventsAsync(_facilNo, _stDt, _enDt, searchString, _opType).Result;
                // _allEventService.GetList(_facilNo, _logTypeNo, _startDate, _endDate, _operatorType).Result?.AsEnumerable();

            if (allEvents != null)
            {
                //if (!String.IsNullOrEmpty(searchString))
                //{
                //    allEvents = allEvents.Where(e => e.EventIdentifier.ToUpper().Contains(searchString.ToUpper())
                //                   || e.EventHighlight.ToUpper().Contains(searchString.ToUpper())
                //                   || e.Details.ToUpper().Contains(searchString.ToUpper()));
                //}

                int _Count = allEvents.Count();

                int pageSize = _pageSize;
                int pageIndex = (page ?? 1);
                IPagedList<ViewAllEventsCurrent> allEventAsIPagedList = allEvents.ToPagedList(pageIndex, pageSize);

                viewmodel.count = _Count;
                viewmodel.AllEventsPagedList = allEventAsIPagedList;
            }
            else
            {
                ViewBag.Message = "There are no records found.";
                
                ViewBag.ShowSearchList = false;

                return View();
            }

            ViewBag.Shift = GetSessionValue<string>(AppConstants.AssignedShiftNoSessionKey).ToString();

            return View("Index", viewmodel);
        }

        [HttpGet]
        [Route("LogFilter")]
        public IActionResult LogFilter(_LogFilterPartialViewModel? logFilterPartial)
        {
            if (logFilterPartial is null)
            {
                logFilterPartial = new _LogFilterPartialViewModel
                {
                    SelectedFacilNo = HttpContext.Session.GetInt32("SelectedFacilNo"),
                    StartDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-1)),
                    EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1))
                };
                //logFilterPartial.CurrentFilter = string.Empty,
                //        OperatorType operatorType ?? false,

            }

            ViewData["Title"] = "All Events";
            return View("LogFilter", logFilterPartial);
        }  
        
        [HttpPost]
        public IActionResult LogFilterSubmitted(_LogFilterPartialViewModel? logFilterPartial)
        {
            if (logFilterPartial is null)
            {
                logFilterPartial = new _LogFilterPartialViewModel
                {
                    SelectedFacilNo = HttpContext.Session.GetInt32("SelectedFacilNo"),
                    StartDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-1)),
                    EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1))
                };
                //logFilterPartial.CurrentFilter = string.Empty,
                //        OperatorType operatorType ?? false,

            }

            DateOnly? startDate = logFilterPartial.StartDate;

            ViewData["Title"] = "All Events";
            return View("LogFilter", logFilterPartial);
        }

        [GET("Details")]
        private static AllEventDetails GetLogDetails(int _facilNo, int logTypeNo, string eventID, int eventID_RevNo)
        {
            int facilNo = _facilNo;
            string eventHighlight = string.Empty;
            string eventTrail = string.Empty;

            switch (logTypeNo)
            {
                case 1: //Clearance
                    eventHighlight = ClearanceIssuesManager.GetItem(facilNo, logTypeNo, eventID, eventID_RevNo).EventHighlight;
                    eventTrail = ClearanceIssuesManager.GetItem(facilNo, logTypeNo, eventID, eventID_RevNo).EventTrail;
                    break;
                case 2: //ClearanceTransfer
                    //eventHighlight = ClearanceTransferManager.GetItem(facilNo, logTypeNo, eventID, eventID_RevNo).EventHighlight;
                    //eventTrail = ClearanceTransferManager.GetItem(facilNo, logTypeNo, eventID, eventID_RevNo).EventTrail;
                    break;
                case 3: //SOC
                    eventHighlight = SOCManager.GetItem(facilNo, logTypeNo, eventID, eventID_RevNo).EventHighlight;
                    eventTrail = SOCManager.GetItem(facilNo, logTypeNo, eventID, eventID_RevNo).EventTrail;
                    break;
                case 4: //EOS
                    eventHighlight = EOSManager.GetItem(facilNo, logTypeNo, eventID, eventID_RevNo).EventHighlight;
                    eventTrail = EOSManager.GetItem(facilNo, logTypeNo, eventID, eventID_RevNo).EventTrail;
                    break;
                case 5: //FlowChange
                    eventHighlight = FlowChangeManager.GetItem(facilNo, logTypeNo, eventID, eventID_RevNo).EventHighlight;
                    eventTrail = FlowChangeManager.GetItem(facilNo, logTypeNo, eventID, eventID_RevNo).EventTrail;
                    break;
                case 6: //General
                    eventHighlight = GeneralManager.GetItem(facilNo, logTypeNo, eventID, eventID_RevNo).EventHighlight;
                    eventTrail = GeneralManager.GetItem(facilNo, logTypeNo, eventID, eventID_RevNo).EventTrail;
                    break;
                default:
                    break;
            }

            AllEventDetails myAllEventDetails = new AllEventDetails
            {
                FacilNo = facilNo,
                LogTypeNo = logTypeNo,
                EventID = eventID,
                EventID_RevNo = eventID_RevNo,
                EventHighlight = eventHighlight,
                EventTrail = eventTrail
            };

            return myAllEventDetails;
        }

        public ActionResult LogSearch(int facilNo, DateTime StartDate, DateTime EndDate, bool operatorType)
        {

            _facilNo = facilNo;
            EndDate = EndDate == null ? System.DateTime.Now.Date : EndDate;
            StartDate = EndDate.AddDays(_daysOffSet);

            _endDate = EndDate.ToString("MM/dd/yyyy");
            _startDate = StartDate.ToString("MM/dd/yyyy");
            string _operatorType = operatorType == true ? "Primary" : "Secondary";
            ViewBag.StartDate = _startDate;
            ViewBag.EndDate = _endDate;

            AllEvents allEvents = AllEventManager.GetList(_facilNo, _logTypeNo, _startDate, _endDate, _operatorType);

            if (Request.IsAjaxRequest())
            {
                if (allEvents != null)
                {
                    int _Count = allEvents.Count;
                    ViewBag.FacilNoSelected = facilNo;
                    // ViewBag.LogTypeNoSelected = _logTypeNo;
                    ViewBag.FacilSelected = GetFacilName(_facilNo); // FacilityManager.GetItem(_facilNo).FacilName.Split(' ').ElementAt(0);
                    var logTypeNames = GetLogTypeNames(); //  LogTypeManager.GetList().AsEnumerable().Where(l => l.LogTypeNo < 7 && l.LogTypeNo != 2).Select(l => new SelectListItem { Value = l.LogTypeNo.ToString(), Text = l.LogTypeName }).ToList(); //.Where(f => f.LogTypeNo )

                    AllEventsViewModel allEventsViewModel = new AllEventsViewModel
                    {
                        FacilNo = _facilNo,
                        StartDate = StartDate,
                        EndDate = EndDate,
                        OperatorType = operatorType,
                        Count = _Count,
                        logTypeNos = new SelectList(logTypeNames, "Value", "Text"),
                        AllEventList = allEvents  // AllEventManager.GetList(_facilNo, _logTypeNo, _startDate, _endDate, _operatorType)  // .AsEnumerable().ToList();  // .Select(s => new { s.EventIdentifier, s.EventHighlight })
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

        public ActionResult Rev(int facilNo, int logTypeNo, string eventID, int eventID_RevNo, string act)
        {
            _facilNo = facilNo;
            string targetController = GetLogTypeName(logTypeNo);
            string targetAction = string.Empty;
            string _act = act;
            AllEvent _allEvent = AllEventManager.GetItem(facilNo, logTypeNo, eventID, eventID_RevNo);
            switch (targetController)
            {
                case "Clearance":
                    //check if the selected Clearance is the most current log
                    int _maxRevNo = ClearanceIssuesManager.GetMaxRevNo(facilNo, eventID);
                    if (eventID_RevNo < _maxRevNo)
                    {
                        ViewBag.eventID = eventID;
                        ViewBag.eventID_RevNo = eventID_RevNo;
                        string _alert = "There is a newer log than the one selected.  You can revise: " + eventID + "-" + _maxRevNo.ToString();
                        // string _alert = "There is a newer log than the one selected.  You can revise the latest from <a href='AllEvents/Rev?facilNo=" + facilNo.ToString() + "&logTypeNo=" + logTypeNo.ToString() + "&eventID=" + eventID + "&eventID_RevNo="
                        //                    + _maxRevNo.ToString() + "'>HERE</a>";
                        return RedirectToAction("Index", "Clearance", new { alert = _alert });
                    }
                    else
                    {
                        if (_allEvent.Subject.Contains("Issue"))
                        {
                            targetAction = targetController + "Issue";
                        }
                        else if (_allEvent.Subject.Contains("Release"))
                        {
                            targetAction = targetController + "Release";
                        }
                        else if (_allEvent.Subject.Contains("Transfer"))
                        {
                            targetAction = targetController + "Transfer";
                        }
                    }
                    break;

                case "SOC":
                    if (_allEvent.Subject.Contains("Issue"))
                    {
                        targetAction = "LogIssue";
                    }
                    else if (_allEvent.Subject.Contains("Release"))
                    {
                        targetAction = "LogRelease";
                    }
                    break;

                case "EOS":
                    if (_allEvent.Subject.Contains("Issue"))
                    {
                        targetAction = "LogIssue";
                    }
                    else if (_allEvent.Subject.Contains("Release"))
                    {
                        targetAction = "LogRelease";
                    }
                    break;

                case "FlowChange":
                    targetAction = "Revise";
                    break;

                case "General":
                    targetAction = targetController + "Issue";
                    break;
            }

            return RedirectToAction(targetAction, targetController, new { facilNo = _facilNo, eventID = eventID, eventID_RevNo = eventID_RevNo, act = _act });
        }

        public ActionResult Del(int facilNo, int logTypeNo, string eventID, int eventID_RevNo)
        {
            string _act = "Deleted";
            return RedirectToAction("Rev", "AllEvents", new { facilNo = facilNo, logTypeNo = logTypeNo, eventID = eventID, eventID_RevNo = eventID_RevNo, act = _act });
        }

        public ActionResult Report(int facilNo, DateTime? startDate, DateTime? endDate, string rptOption, string searchString)
        {
            DateTime StDt = startDate.HasValue ? startDate.Value.Date : now.Date;
            DateTime EnDt = endDate.HasValue ? endDate.Value.Date : StDt.AddDays(1);

            string _startDate = StDt.ToString("yyyyMMdd");
            string _endDate = EnDt.ToString("yyyyMMdd");
            string _shiftStartTime;
            string _shiftEndTime;

            if (rptOption == "Day")
            {
                _shiftStartTime = shiftStartText;
                _shiftEndTime = shiftEndText;
                EnDt = StDt;
                _endDate = _startDate;
            }
            else if (rptOption == "Night")
            {
                _shiftStartTime = "18:00:00";
                _shiftEndTime = "05:59:00";
                EnDt = StDt.AddDays(1);
                _endDate = EnDt.ToString("yyyyMMdd");
            }
            else
            {
                rptOption = String.Empty;
                _shiftStartTime = "00:00";
                _shiftEndTime = "23:59";
            }

            // get the Date value from DatetTime? and add time
            DateTime _StDTime = StDt.Add(TimeSpan.Parse(_shiftStartTime));
            DateTime _EnDTime = EnDt.Add(TimeSpan.Parse(_shiftEndTime));

            // DateTime _EnDTime = endDate.Value.Date.AddDays(1).Add(TimeSpan.Parse(_shiftEndTime));

            Report _Report = new Report();

            var _report = AllEventManager.GetReport(facilNo, _startDate, _endDate).AsEnumerable();

            if (!String.IsNullOrEmpty(searchString))
            {
                _report = _report.Where(r => r.EventID.ToUpper().Contains(searchString.ToUpper())
                               || r.Subject.ToUpper().Contains(searchString.ToUpper())
                               || r.Details.ToUpper().Contains(searchString.ToUpper()));
            }

            if (_report != null)
            {
                _report = _report.Where(r => r.EventDate.Add(TimeSpan.Parse(r.EventTime)) >= _StDTime && r.EventDate.Add(TimeSpan.Parse(r.EventTime)) <= _EnDTime);

                // manually cast var to Report
                foreach (var _r in _report)
                {
                    Rpt _R = new Rpt()
                    {
                        FacilNo = _r.FacilNo,
                        FacilName = _r.FacilName,
                        LogTypeNo = _r.LogTypeNo,
                        LogTypeName = _r.LogTypeName,
                        EventID = _r.EventID,
                        EventID_RevNo = _r.EventID_RevNo,
                        Subject = _r.Subject,
                        Details = _r.Details,
                        EventDate = _r.EventDate,
                        EventTime = _r.EventTime,
                        UpdatedByName = _r.UpdatedByName,
                        UpdateDate = _r.UpdateDate
                    };

                    _Report.Add(_R);
                    // _Report.Insert(
                }
            }

            RptViewModel _rptViewModel = new RptViewModel()
            {
                report = _Report // (Report)AllEventManager.GetReport(facilNo, _startDate, _endDate) // .Where(r => r.EventDate.Add(TimeSpan.Parse(r.EventTime)) >= _StDTime && r.EventDate.Add(TimeSpan.Parse(r.EventTime)) <= _EnDTime)

            };

            rptOption = rptOption == "Day" ? rptOption + " Shift" : rptOption == "Night" ? rptOption + " Shift" : "Daily";

            ViewBag.Title = FacilName + " " + rptOption + " Report for " + StDt.ToString("MM/dd/yyyy") + " " + _shiftStartTime + " to " + EnDt.ToString("MM/dd/yyyy") + " " + _shiftEndTime;

            if (_rptViewModel.report.Count() > 0)
            {
                ViewBag.ShowSearchList = true;
            }
            else
            {
                ViewBag.Message = "There are no logs to report.";
            }

            return View("Report", _rptViewModel);
        }

        #region Helpers


        //Example: passing Json to view to generate selectList
        // [GET("SelectList")]
        // [OutputCache(CacheProfile = "Cache12Hours", Location = OutputCacheLocation.Client)]
        // [OutputCache(CacheProfile = "Cache1Hour", Location = OutputCacheLocation.Client)]
        public ActionResult ESLUserAutoCompleteList(string term)
        {
            int _facilNo = FacilNo;

            var eList = _coreService.GetUserListByFacilNo(_facilNo)// GetESLUsersOracle(_facilNo).AsQueryable().Select(l => new { UserID = l.UserID, Name = l.Name }).OrderBy(x => x.Name);

            var empList = eList.AsQueryable().OrderBy(e => e.UserID).Select(e => new { label = e.Name, EmpID = e.UserID }); //;

            // add filter for q
            if (!String.IsNullOrEmpty(term))
            {
                empList = empList.Where(e => e.label.ToLower().Contains(term.ToLower())).OrderBy(x => x.label);
            }

            //ESLUserList EList = new ESLUserList();


            //// For Testing or Dev environment

            //// SuperAdmin
            //ESLUser emp1 = new ESLUser()
            //{
            //    UserID = "6337",
            //    Name = "Lihan Chen"
            //};

            //// SuperAdmin
            //ESLUser emp2 = new ESLUser()
            //{
            //    UserID = "7519",
            //    Name = "Evan Ho"
            //};

            //// Admin
            //ESLUser emp3 = new ESLUser()
            //{
            //    UserID = "7829",
            //    Name = "George Dobosh"
            //};

            //// Operator
            //ESLUser emp4 = new ESLUser()
            //{
            //    UserID = "7822",
            //    Name = "Alex Pop"
            //};

            //List<ESLUser> testUserList = new ESLUserList();

            //testUserList.Add(emp1);
            //testUserList.Add(emp2);
            //testUserList.Add(emp3);
            //testUserList.Add(emp4);

            //eList.Union(testUserList);

            return Json(empList, JsonRequestBehavior.AllowGet);
        }
    }
}

