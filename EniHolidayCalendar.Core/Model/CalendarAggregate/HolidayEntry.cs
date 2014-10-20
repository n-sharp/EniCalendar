using EniCalendar.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EniHolidayCalendar.Core.Model.CalendarAggregate
{
  public class HolidayEntry : CalendarEntry
  {
    private HolidayEntry() : base(Guid.NewGuid()) { }
    public HolidayEntry(Guid pId)
      : base(pId)
    {
    }

    //Factory method for creation
    public static HolidayEntry Create(DateTimeRange pRange, string pTitle)
    {
      var lHoliday = new HolidayEntry(Guid.NewGuid());
      lHoliday.Range = pRange;
      lHoliday.Title = pTitle;

      return lHoliday;
    }
  }
}
