using EniCalendar.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EniHolidayCalendar.Core.Model.CalendarAggregate
{
  public class VacationEntry : CalendarEntry
  {
    public VacationType Type { get; private set; }
    public ApprovalStatus Status { get; set; }

    private VacationEntry() : base(Guid.NewGuid()) { }

    public VacationEntry(Guid pId)
      : base(pId)
    {
    }

    //Factory method for creation
    public static VacationEntry Create(DateTimeRange pRange, string pTitle, VacationType pType)
    {
      var lVacation = new VacationEntry(Guid.NewGuid());
      lVacation.Range = pRange;
      lVacation.Title = pTitle;
      lVacation.Type = pType;
      lVacation.Status = ApprovalStatus.New;

      return lVacation;
    }
  }
}
