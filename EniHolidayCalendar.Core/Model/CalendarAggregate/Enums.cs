using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EniHolidayCalendar.Core.Model.CalendarAggregate
{
    public enum VacationType
    {
        WholeDay,
        Morning,
        Afternoon
    }

    public enum ApprovalStatus
    {
        New,
        Modified,
        Canceled,
        Approved,
        Rejected
    }
}
