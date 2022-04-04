using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeReportingSystem.API
{
    public class Methods
    {
        public static DateTime GetFirstDayOfWeek(int year, int weekNumber)
        {
            DateTime fDOY = new DateTime(year, 1, 1);
            DateTime dt = fDOY;

            if (fDOY.DayOfWeek == DayOfWeek.Tuesday || fDOY.DayOfWeek == DayOfWeek.Wednesday || fDOY.DayOfWeek == DayOfWeek.Thursday)
            {
                // Get Monday/first day of the week
                while (dt.DayOfWeek != DayOfWeek.Monday)
                    dt = dt.AddDays(-1);
            }
            else if (fDOY.DayOfWeek == DayOfWeek.Friday || fDOY.DayOfWeek == DayOfWeek.Saturday || fDOY.DayOfWeek == DayOfWeek.Sunday)
            {
                // Add another week since this won't be the first week of the year
                //dt = dt.AddDays(7);

                // Get Monday/first day of the week
                while (dt.DayOfWeek != DayOfWeek.Monday)
                    dt = dt.AddDays(1);
            }

            // Add weeks
            dt = dt.AddDays((weekNumber - 1) * 7);

            return dt;
        }
    }
}
