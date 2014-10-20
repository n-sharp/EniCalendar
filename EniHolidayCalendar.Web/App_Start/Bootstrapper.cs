using Autofac;
using Autofac.Integration.Mvc;
using EniHolidayCalendar.Core.Interfaces;
using EniHolidayCalendar.Data;
using EniHolidayCalendar.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace EniHolidayCalendar.Web.App_Start
{
    public class Bootstrapper
    {
        public IContainer EniContainer { get; private set; }

        public void Configure()
        {
            ContainerBuilder lBuilder = new ContainerBuilder();
            OnConfigure(lBuilder);

            if (EniContainer == null)
            {
                EniContainer = lBuilder.Build();
            }
            else
            {
                lBuilder.Update(EniContainer);
            }

            //this tells the MVC application to use MyContrainer as its dependency resolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(EniContainer));
        }

        private void OnConfigure(ContainerBuilder pBuilder)
        {
            //this is where you register all dependencies

            //The line below tells autofac, when a controller is initialized, pass into its constructor, the implementations of the required interfaces
            pBuilder.RegisterControllers(Assembly.GetExecutingAssembly());

            pBuilder.RegisterType<CalendarContext>().AsSelf().InstancePerDependency();
            pBuilder.RegisterType<CalendarRepository>().As<ICalendarRepository>().InstancePerDependency();
        }
    }
}