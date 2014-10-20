using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EniCalendar.SharedKernel.UnitTests
{
  [TestClass]
  public class DateTimeRangeUnitTests
  {
    private DateTime mTestStartDate = new DateTime(2014, 1, 1);

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void ThrowArgumentExceptionIfStartDateEqualsEndDate()
    {
      var result = new DateTimeRange(mTestStartDate, mTestStartDate);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void ThrowArgumentExceptionIfStartDateSmallerThanEndDate()
    {
      var result = new DateTimeRange(mTestStartDate, mTestStartDate.AddDays(-1));
    }

    [TestMethod]
    public void PassIfStartDateGreaterThenEndDate()
    {
      var result = new DateTimeRange(mTestStartDate, mTestStartDate.AddDays(+1));
    }

    [TestMethod]
    public void PassIfOneDayRange()
    {
      var lStartDate = new DateTime(2014, 10, 2);
      var result = DateTimeRange.CreateOneDayRange(lStartDate);

      Assert.IsTrue(result.Start == lStartDate);
      Assert.IsTrue(result.EndInclusive == lStartDate);
    }

    [TestMethod]
    public void PassIfOneMonthRange()
    {
      var lStartDate = new DateTime(2014, 10, 2);
      var result = DateTimeRange.CreateOneMonthRange(lStartDate);

      Assert.IsTrue(result.Start == new DateTime(2014,10,1));
      Assert.IsTrue(result.EndInclusive == new DateTime(2014,10,31));
    }
  }
}
