using EniHolidayCalendar.Core.Model.CalendarAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EniHolidayCalendar.Core.Interfaces
{
  public interface ICalendarRepository
  {
    List<CalendarRoot> GetCalendars();
    Calendar GetCalendarForMonth(string pCalendarCode, DateTime pDate);
    void Update(Calendar pCalendar);
  }
}
