using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EniCalendar.SharedKernel
{
    public class Guard
    {
        public static void ForPrecedesDate(DateTime pValue, DateTime pDateToProcees, string pParameterName)
        {
            if (pValue >= pDateToProcees)
            {
                throw new ArgumentOutOfRangeException(pParameterName);
            }
        }
    }
}
