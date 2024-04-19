using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Efox.LeadManager.Helper
{
    public static class DateFormatHelper
    {
        public static string ToRemainingTimeValue(this DateTime? str)
        {
            if (str == null)
            {
                str = DateTime.Now;
            }
            DateTime myDate = (DateTime)str;

            TimeSpan timeToEvent = myDate.Subtract(DateTime.Now);
            if (timeToEvent.Days > 0)
                return string.Format(" {0} Days, {1} Hours {2} Minutes",
                                               timeToEvent.Days, timeToEvent.Hours, timeToEvent.Minutes);
            else
            if (timeToEvent.Hours > 0)
                return string.Format("{0} Hours, {1} Minutes",
                                               timeToEvent.Hours, timeToEvent.Minutes);
            else
            if (timeToEvent.Minutes > 0)
                return string.Format("{0} Minutes",
                                               timeToEvent.Minutes);
            return "";
        }
        public static string ToRelateiveTimeString(this DateTime? str)
        {
            const int SECOND = 1;
            const int MINUTE = 60 * SECOND;
            const int HOUR = 60 * MINUTE;
            const int DAY = 24 * HOUR;
            const int MONTH = 30 * DAY;
            var dtime = str == null ? DateTime.Now : (DateTime)str;
            var ts = new TimeSpan(DateTime.Now.Ticks - dtime.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 1 * MINUTE)
                return ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";

            if (delta < 2 * MINUTE)
                return "a minute ago";

            if (delta < 45 * MINUTE)
                return ts.Minutes + " minutes ago";

            if (delta < 90 * MINUTE)
                return "an hour ago";

            if (delta < 24 * HOUR)
                return ts.Hours + " hours ago";

            if (delta < 48 * HOUR)
                return ts.Hours + " hours ago";

            if (delta < 30 * DAY)
                return ts.Days + " days ago";

            if (delta < 12 * MONTH)
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "one month ago" : months + " months ago";
            }
            else
            {
                int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                return years <= 1 ? "one year ago" : years + " years ago";
            }
        }
    }
}
