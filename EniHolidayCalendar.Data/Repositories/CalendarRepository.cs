using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EniHolidayCalendar.Core.Interfaces;
using EniHolidayCalendar.Core.Model.CalendarAggregate;
using EniCalendar.SharedKernel;

namespace EniHolidayCalendar.Data.Repositories
{
  public class CalendarRepository : ICalendarRepository, IDisposable
  {
    CalendarContext mContext;

    public CalendarRepository(CalendarContext pContext)
    {
      mContext = pContext;
    }

    public Calendar GetCalendarForDate(string pCalendarCode, DateTime pDate)
    {
      var mEntries = mContext.Entries;
      var lCalendar = mContext.Calendars.First(c => c.CalendarCode == pCalendarCode);
      var lEntries = lCalendar.Entries.ToList();     

      var lTest = mContext.Entry(lCalendar).State;
      return new Calendar(lCalendar.Id, DateTimeRange.CreateOneMonthRange(pDate), lCalendar.CalendarCode, lEntries);
    }

    public void Update(Calendar pCalendar)
    {
      foreach (var pEntry in pCalendar.Entries)
      {
        //mContext.Entry(pEntry).State = System.Data.EntityState.Added;
        mContext.Entries.Add(pEntry);
      }

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
