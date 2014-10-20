using EniCalendar.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EniHolidayCalendar.Core.Model.CalendarAggregate
{
  public abstract class CalendarEntry : Entity<Guid>
  {
    public virtual Calendar Calendar { get; set; }
    public DateTimeRange Range { get; protected set; }
    public string Title { get; protected set; }
    public string Comments { get; protected set; }

    public CalendarEntry(Guid pId)
      : base(pId)
    {
    }
  }
}
