using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EniHolidayCalendar.Core.Interfaces;
using EniHolidayCalendar.Core.Model.CalendarAggregate;
using EniCalendar.SharedKernel;
using System.Diagnostics;
using System.Data.Entity;

namespace EniHolidayCalendar.Data.Repositories
{
  public class CalendarRepository : ICalendarRepository, IDisposable
  {
    CalendarContext mContext;

    public CalendarRepository(CalendarContext pContext)
    {
      mContext = pContext;
    }

    public List<CalendarRoot> GetCalendars()
    {
      return mContext.CalendarRoots.ToList();
    }

    public Calendar GetCalendarForMonth(string pCalendarCode, DateTime pDate)
    {
      //get calendar
      var lCalendar = mContext.Calendars.FirstOrDefault(c => c.CalendarCode == pCalendarCode);
      lCalendar.DateRange = DateTimeRange.CreateOneMonthRange(pDate);

      //get entries for that calendar for given month
      mContext.Entry(lCalendar).Collection(c => c.Entries)
        .Query()
        .Where(e => e.Range.Start < lCalendar.DateRange.EndExclusive && e.Range.EndExclusive > lCalendar.DateRange.Start);

      return lCalendar;
    }

    public void Update(Calendar pCalendar)
    {
      mContext.SaveChanges();
    }

    #region Dispose

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
      if (!this.disposed)
      {
        if (disposing)
        {
          mContext.Dispose();
        }
      }
      this.disposed = true;
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    #endregion
  }
}
