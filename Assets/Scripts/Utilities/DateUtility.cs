using System;

namespace Utilities
{
    public static class DateUtility
    {
        public static bool DateIsPassed(string date)
        {
            DateTime dateTime = DateTime.Parse(date);
            DateTime nowTime = DateTime.Now;
            return dateTime <= nowTime;
        }
    }
}