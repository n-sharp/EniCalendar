using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EniHolidayCalendar.Web.Controllers
{
  public class HolidayController : Controller
  {
    //
    // GET: /Holiday/

    public ActionResult Index()
    {
      return View();
    }

    public ActionResult Create()
    {
      var lModel = new HolidayEntryModel { Start = DateTime.Now.Date, EndInclusive = DateTime.Now.Date.AddDays(1) };
      return View(lModel);
    }

    [HttpPost]
    public ActionResult Create(HolidayEntryModel Model)
    {
      System.Diagnostics.Debug.WriteLine("Create Holiday");
      return RedirectToAction("Index", "Calendar", new { CalendarCode = "trms" });
    }

  }
}
