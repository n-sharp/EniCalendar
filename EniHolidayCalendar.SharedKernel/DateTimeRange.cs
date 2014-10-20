using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EniCalendar.SharedKernel
{
  public class DateTimeRange : ValueObject<DateTimeRange>
  {
    public DateTime Start { get; private set; }
    public DateTime EndExclusive { get; private set; }

    public DateTime EndInclusive
    {
      get
      {
        return EndExclusive.AddDays(-1);
      }
    }

    protected DateTimeRange()
    { }

    public DateTimeRange(DateTime pStart, DateTime pEndExclusive)
    {
      Guard.ForPrecedesDate(pStart, pEndExclusive, "Start");
      Start = pStart;
      EndExclusive = pEndExclusive;
    }

    public static DateTimeRange CreateOneDayRange(DateTime pDay)
    {
      return new DateTimeRange(pDay, pDay.AddDays(1));
    }

    public static DateTimeRange CreateOneMonthRange(DateTime pDate)
    {
      var lNextMonth = pDate.AddMonths(1);
      var lRange = new DateTimeRange(new DateTime(pDate.Year, pDate.Month, 1), new DateTime(lNextMonth.Year, lNextMonth.Month, 1));
      return lRange;
    }

    public bool Overlaps(DateTimeRange dateTimeRange)
    {
      return this.Start < dateTimeRange.EndExclusive && this.EndExclusive > dateTimeRange.Start;
    }
  }
}
