using EniHolidayCalendar.Core.Model.CalendarAggregate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EniHolidayCalendar.Data
{
  public class CalendarContext : DbContext
  {
    public CalendarContext()
      : base("name=EniCalendar")
    {
    }

    public DbSet<CalendarRoot> CalendarRoots {get;set;}
    public DbSet<Calendar> Calendars { get; set; }
    //public DbSet<CalendarEntry> Entries { get; set; }
    //public DbSet<VacationType> VacationTypes { get; set; }
    //public DbSet<ApprovalStatus> ApprovalStatus { get; set; }
    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Calendar>().Ignore(c => c.DateRange);

      base.OnModelCreating(modelBuilder);
    }
  }

  public class CalendarContextInitializer : DropCreateDatabaseIfModelChanges<CalendarContext>
  {
    protected override void Seed(CalendarContext context)
    {
      List<Calendar> lCalendars = new List<Calendar>
        {
            new Calendar(Guid.NewGuid(), "trms", "TRMS Holiday Calendar"),
            new Calendar(Guid.NewGuid(), "go", "GO Holiday Calendar")
        };

      // add data into context and save to db
      foreach (Calendar lCalendar in lCalendars)
      {
        context.Calendars.Add(lCalendar);
      }
      context.SaveChanges();

      base.Seed(context);
    }
  }
}
