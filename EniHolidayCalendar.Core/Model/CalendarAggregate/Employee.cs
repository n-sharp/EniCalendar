using EniCalendar.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EniHolidayCalendar.Core.Model.CalendarAggregate
{
    public class Employee : Entity<string>
    {
        public string FullName { get; private set; }

        public Employee(string pUsername) : base(pUsername)
        {            
        }
    }
}
