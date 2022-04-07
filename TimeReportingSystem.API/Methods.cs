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
            DateTime date = fDOY;

            if (fDOY.DayOfWeek == DayOfWeek.Tuesday || fDOY.DayOfWeek == DayOfWeek.Wednesday || fDOY.DayOfWeek == DayOfWeek.Thursday)
            {
                // Get Monday/first day of current week
                while (date.DayOfWeek != DayOfWeek.Monday)
                    date = date.AddDays(-1);
            }
            else if (fDOY.DayOfWeek == DayOfWeek.Friday || fDOY.DayOfWeek == DayOfWeek.Saturday || fDOY.DayOfWeek == DayOfWeek.Sunday)
            {
                // Get Monday/first day of the next week
                while (date.DayOfWeek != DayOfWeek.Monday)
                    date = date.AddDays(1);
            }

            // Add weeks
            date = date.AddDays((weekNumber - 1) * 7);

            return date;
        }
    }
}
