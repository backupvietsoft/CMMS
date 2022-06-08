using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq;
namespace MVControl
{
    public static class Class1
    {
        public static void Total1()
        {
            DateTime a = new DateTime(2010, 10, 30, 21, 00, 00);
            DateTime b = a + new TimeSpan(1, 12, 0, 0, 0);

            var minutes = from day in a.DaysInRangeUntil(b)
                          where !day.IsWeekendDay()
                          let start = Max(day.AddHours(8), a)
                          let end = Min(day.AddHours(17), b)
                          select (end - start).TotalMinutes;

            //            var result = minutes.Sum();
            var  result = minutes.Sum();
        }



        static IEnumerable<DateTime> DaysInRangeUntil(this DateTime start, DateTime end)
        {
            return Enumerable.Range(0, 1 + (int)(end.Date - start.Date).TotalDays)
                             .Select(dt => start.Date.AddDays(dt));
        }

        static bool IsWeekendDay(this DateTime dt)
        {
            return dt.DayOfWeek == DayOfWeek.Saturday
                || dt.DayOfWeek == DayOfWeek.Sunday;
        }

        static DateTime Max(DateTime a, DateTime b)
        {
            return new DateTime(Math.Max(a.Ticks, b.Ticks));
        }

        static DateTime Min(DateTime a, DateTime b)
        {
            return new DateTime(Math.Min(a.Ticks, b.Ticks));
        }

    }
}
