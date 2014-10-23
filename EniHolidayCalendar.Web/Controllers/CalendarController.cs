using EniHolidayCalendar.Core.Interfaces;
using EniHolidayCalendar.Core.Model.CalendarAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EniHolidayCalendar.Web.Controllers
{
  public class CalendarController : Controller
  {
    private ICalendarRepository mRepository;

    public CalendarController(ICalendarRepository pRepository)
    {
      mRepository = pRepository;
    }

    //
    // GET: /Calendar/
    public ActionResult Index(string CalendarCode)
    {
      var lEntries = new List<CalendarEntryModel>();
      foreach (dynamic pEntry in mRepository.GetCalendarForMonth(CalendarCode, DateTime.Now).Entries)
      {
        lEntries.Add(CalendarEntryManager.Display(pEntry));
      }
      
      return View(lEntries);
    }

    //GET calendar/create/{entrytype}
    public ActionResult Create(string EntryType)
    {
      return RedirectToAction("Create", EntryType, null);
    }
  }

  public class CalendarEntryManager
  {
    public static HolidayEntryModel Display(HolidayEntry pEntry)
    {
      return new HolidayEntryModel
                     {
                       Id = pEntry.Id,
                       Title = "Holiday: " + pEntry.Title,
                       Start = pEntry.Range.Start,
                       EndInclusive = pEntry.Range.EndInclusive
                     };
    }

    public static VacationEntryModel Display(VacationEntry pEntry)
    {
      return new VacationEntryModel
      {
        Id = pEntry.Id,
        Title = pEntry.Title,
        Start = pEntry.Range.Start,
        EndInclusive = pEntry.Range.EndInclusive,
        Type = pEntry.Type,
        Status = pEntry.Status
      };
    }
  }

  // MODELS
  public class CalendarEntryModel
  {
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateTime Start { get; set; }
    public DateTime EndInclusive { get; set; }
  }

  public class HolidayEntryModel : CalendarEntryModel
  {

  }

  public class VacationEntryModel : CalendarEntryModel
  {
    public VacationType Type { get; set; }
    public ApprovalStatus Status { get; set; }
  }
}
