using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EniCalendar.SharedKernel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EniHolidayCalendar.Core.Model.CalendarAggregate
{
  [Table("Calendars")]
  public class Calendar : CalendarRoot
  {
    //public string CalendarCode { get; private set; }
    //public string DisplayName { get; private set; }
    public DateTimeRange DateRange { get; set; }

    public List<CalendarEntry> Entries { get; private set; }

    private Calendar()
      : base(Guid.NewGuid()) //required for EF
    {
      Entries = new List<CalendarEntry>();
    }

    //used for initial setup
    public Calendar(Guid pId, string pCalendarCode, string pDisplayName)
      : base(pId)
    {
      CalendarCode = pCalendarCode;
      DisplayName = pDisplayName;
      Entries = new List<CalendarEntry>();
    }

    //not used
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

      Entries.Add(pEntry);

      //TODO raise HolidayPlannedEvent

      return pEntry;
    }
  }

  [Table("Calendars")]
  public class CalendarRoot : Entity<Guid>
  {
    public string CalendarCode { get; protected set; }
    public string DisplayName { get; protected set; }
    
    protected CalendarRoot()
      : base(Guid.NewGuid()) //required for EF
    {      
    }

    protected CalendarRoot(Guid pId) : base(pId) { }
  }
}
