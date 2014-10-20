using EniCalendar.SharedKernel;
using EniHolidayCalendar.Core.Interfaces;
using EniHolidayCalendar.Core.Model.CalendarAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EniHolidayCalendar.Web.Controllers
{
  public class VacationController : Controller
  {
    private ICalendarRepository mCalendarRepository;

    public VacationController(ICalendarRepository pCalendarRepository)
    {
      mCalendarRepository = pCalendarRepository;
    }
    
    //GET vacation/create
    public ActionResult Create()
    {
      var lModel = new VacationEntryModel { Start = DateTime.Now.Date, EndInclusive = DateTime.Now.Date };
      return View(lModel);
    }

    //POST vacation/create
    [HttpPost]
    public ActionResult Create(VacationEntryModel Model)
    {
      //todo retrieve calendarcode from session?
      string pCalendarCode = "trms";
      
      var lCalendar = mCalendarRepository.GetCalendarForDate(pCalendarCode, Model.Start);

      var lNewEntry = VacationEntry.Create(new DateTimeRange(Model.Start, Model.EndInclusive.AddDays(1)), Model.Title, Model.Type);
      lCalendar.AddNewEntry(lNewEntry);

      mCalendarRepository.Update(lCalendar);

      return RedirectToAction("Index", "Calendar", new { CalendarCode = pCalendarCode });
    }
  }
}
