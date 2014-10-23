using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EniHolidayCalendar.Data.Repositories;
using EniHolidayCalendar.Data;
using System.Collections.Generic;
using System.Linq;
using EniHolidayCalendar.Core.Model.CalendarAggregate;
using EniCalendar.SharedKernel;
using EFlogger.Profiling;
using EFlogger.EntityFramework6;

namespace EniHolidayCalendar.IntergrationTests
{
  [TestClass]
  public class CalendarRepositoryTests
  {
    [TestInitialize]
    public void Initialize()
    {
      EFloggerFor6.Initialize();
    }

    [TestMethod]
    public void TestGetCalendars()
    {
      var lRepository = new CalendarRepository(new CalendarContext());
      var lResult = lRepository.GetCalendars();
      Assert.IsNotNull(lResult);
    }

    [TestMethod]
    public void TestGetCalendar()
    {
      var lRepository = new CalendarRepository(new CalendarContext());
      var lResult = lRepository.GetCalendarForMonth("trms", DateTime.Now);
      Assert.IsNotNull(lResult);
    }

    [TestMethod]
    public void TestInsertVacation()
    {
      var lRepo = new CalendarRepository(new CalendarContext());
      var lCalendar = lRepo.GetCalendarForMonth("trms", DateTime.Now);

      var lVacation = VacationEntry.Create(DateTimeRange.CreateOneDayRange(DateTime.Now), "insert from unit test", VacationType.Afternoon);
      lCalendar.AddNewEntry(lVacation);

      lRepo.Update(lCalendar);
    }
  }
}
