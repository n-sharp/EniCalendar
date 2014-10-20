using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EniHolidayCalendar.Data.Repositories;
using EniHolidayCalendar.Data;
using System.Collections.Generic;
using System.Linq;
using EniHolidayCalendar.Core.Model.CalendarAggregate;
using EniCalendar.SharedKernel;

namespace EniHolidayCalendar.IntergrationTests
{
  [TestClass]
  public class CalendarRepositoryTests
  {
    [TestMethod]
    public void TestGetCalendar()
    {
      var lRepository = new CalendarRepository(new CalendarContext());

      var lResult = lRepository.GetCalendarForDate("trms", DateTime.Now);

      Assert.IsNotNull(lResult);
    }

    [TestMethod]
    public void TestInsertVacation()
    {
      var lContext = new CalendarContext();

      var lCalendar = lContext.Calendars.First(c => c.CalendarCode == "trms");

      Assert.IsNotNull(lCalendar);

      lCalendar.AddNewEntry(VacationEntry.Create(DateTimeRange.CreateOneDayRange(DateTime.Now), "test", VacationType.WholeDay));

      lContext.SaveChanges();

    }
  }
}
