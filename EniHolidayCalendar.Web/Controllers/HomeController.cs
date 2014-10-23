using EniHolidayCalendar.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EniHolidayCalendar.Web.Controllers
{
  public class HomeController : Controller
  {
    ICalendarRepository mRepository;

    public HomeController(ICalendarRepository pRepository)
    {
      mRepository = pRepository;
    }

    public ActionResult Index()
    {
      var lModel = new HomeModel();

      lModel.Calendars = from c in mRepository.GetCalendars()
                         select new CalendarModel
                         {
                           CalendarCode = c.CalendarCode,
                           DisplayName = c.DisplayName
                         };
      
      return View(lModel);
    }

    public ActionResult About()
    {
      ViewBag.Message = "Your app description page.";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }
  }

  public class HomeModel
  {
    public IEnumerable<CalendarModel> Calendars { get; set; }
  }

  public class CalendarModel
  {
    public string DisplayName { get; set; }
    public string CalendarCode { get; set; }
  }
}
