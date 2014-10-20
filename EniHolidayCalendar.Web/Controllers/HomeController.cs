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
    public ActionResult Index()
    {
      var lModel = new HomeModel();
      //lModel.CalendarAnchors = new List<string>
      //    {
      //    HtmlHelper.GenerateLink(
      //              this.Request.RequestContext,
      //              RouteTable.Routes,
      //              "TRMS Holiday Calendar",
      //              "",
      //              "Index",
      //              "Calendar",
      //              new RouteValueDictionary(new { Calendar = "trms" }),
      //              null),

      //    HtmlHelper.GenerateLink(
      //              this.Request.RequestContext,
      //              RouteTable.Routes,
      //              "GO Holiday Calendar",
      //              "",
      //              "Index",
      //              "Calendar",
      //              new RouteValueDictionary(new { Calendar = "go" }),
      //              null)
      //    };



      lModel.Calendars = new List<CalendarModel> { 
        new CalendarModel{ CalendarCode = "trms", DisplayName = "TRMS Holiday Calendar"},
        new CalendarModel{ CalendarCode = "go", DisplayName = "GO Holiday Calendar"}
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
    public List<CalendarModel> Calendars { get; set; }
  }

  public class CalendarModel
  {
    public string DisplayName { get; set; }
    public string CalendarCode { get; set; }
  }
}
