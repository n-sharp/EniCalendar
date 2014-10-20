using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EniCalendar.SharedKernel;

namespace EniHolidayCalendar.Core.Model.CalendarAggregate
{
  public class Calendar : Entity<Guid>
  {
    public string CalendarCode { get; private set; }
    public DateTimeRange DateRange { get; private set; }

    public List<CalendarEntry> Entries { get; private set; }

    private Calendar()
      : base(Guid.NewGuid()) //required for EF
    {
      Entries = new List<CalendarEntry>();
    }

    public Calendar(Guid pId, string pCalendarCode)
      : base(pId)
    {
      CalendarCode = pCalendarCode;
      Entries = new List<CalendarEntry>();
    }

    public Calendar(Guid pId, DateTimeRange pDateRange, string pCalendarCode, IEnumerable<CalendarEntry> pEntries)
      : base(pId)
    {
      DateRange = pDateRange;
      CalendarCode = pCalendarCode;
      Entries = new List<CalendarEntry>(pEntries);

      //TODO register for HolidayUpdatedEvent
    }

    public CalendarEntry AddNewEntry(CalendarEntry pEntry)
    {
      if (Entries.Any(h => h.Id == pEntry.Id))
      {
        throw new ArgumentException("Cannot add duplicate entry to calendar", "entry");
      }

      pEntry.Calendar = this;
      Entries.Add(pEntry);

      //TODO raise HolidayPlannedEvent

      return pEntry;
    }
  }
}
