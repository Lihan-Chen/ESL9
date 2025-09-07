using Application.Dtos;
using Core.Models.BusinessEntities;
using X.PagedList;

namespace Mvc.ViewModels
{
    public class AllEventsOutstanding
    {
        public _LogFilterPartialViewModel logFilterPartial { get; set; } = new _LogFilterPartialViewModel();
        public IPagedList<ViewAllEventsCurrent> AllEventsPagedList { get; set; } = new PagedList<ViewAllEventsCurrent>(new List<ViewAllEventsCurrent> { }, 1, 10);
        public int count { get; set; }
        public AllEventDetailsDto AllEventDetails { get; set; } = new AllEventDetailsDto();
        public RealTimeDto realtime { get; set; } = new RealTimeDto();
        public UserSessionDto UserSession { get; set; } = new UserSessionDto();
    }
}
