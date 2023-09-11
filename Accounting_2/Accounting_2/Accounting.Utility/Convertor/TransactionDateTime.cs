using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Utility.Convertor
{
    public static class TransactionDateTime
    {
        public static DateTime ToPersianDate(this DateTime date)
        {
            PersianCalendar pc = new PersianCalendar();
            return new DateTime(pc.GetYear(date), pc.GetMonth(date), pc.GetDayOfMonth(date));
        }

        public static DateTime ToPersianDateTime(this DateTime dateTime)
        {
            PersianCalendar pc = new PersianCalendar();
            return new DateTime(pc.GetYear(dateTime), pc.GetMonth(dateTime), pc.GetDayOfMonth(dateTime), pc.GetHour(dateTime), pc.GetMinute(dateTime), pc.GetSecond(dateTime));
        }

        public static bool IsGreater(DateTime dt1, DateTime dt2)
        {
            return (dt1.Year > dt2.Year) ||
                (dt1.Year == dt2.Year && dt1.Month > dt2.Month) ||
                (dt1.Year == dt2.Year && dt1.Month == dt2.Month && dt1.Day > dt2.Day);
        }

        public static bool IsLess(DateTime dt1, DateTime dt2)
        {
            return (dt1.Year < dt2.Year) ||
                (dt1.Year == dt2.Year && dt1.Month < dt2.Month) ||
                (dt1.Year == dt2.Year && dt1.Month == dt2.Month && dt1.Day < dt2.Day);
        }
        public static DateTime ToMiladi(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, new System.Globalization.PersianCalendar());
        }
    }
}
