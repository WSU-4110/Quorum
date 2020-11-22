using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quorum.Data
{
    public static class TimeAgo
    {
        public static string getTimeAgo(DateTimeOffset date)
        {
            TimeSpan t = DateTime.UtcNow - date;
            double deltaSeconds = t.TotalSeconds;

            double deltaMinutes = deltaSeconds / 60.0f;
            int minutes;

            if (deltaSeconds < 10)
            {
                return "Just now";
            }
            else if (deltaSeconds < 60)
            {
                return Math.Floor(deltaSeconds) + " seconds ago";
            }
            else if (deltaSeconds < 120)
            {
                return "A minute ago";
            }
            else if (deltaMinutes < 60)
            {
                return Math.Floor(deltaMinutes) + " minutes ago";
            }
            else if (deltaMinutes < 120)
            {
                return "An hour ago";
            }
            else if (deltaMinutes < (24 * 60))
            {
                minutes = (int)Math.Floor(deltaMinutes / 60);
                return minutes + " hours ago";
            }
            else if (deltaMinutes < (24 * 60 * 2))
            {
                return "Yesterday";
            }
            else if (deltaMinutes < (24 * 60 * 7))
            {
                minutes = (int)Math.Floor(deltaMinutes / (60 * 24));
                return minutes + " days ago";
            }
            else if (deltaMinutes < (24 * 60 * 14))
            {
                return "Last week";
            }
            else if (deltaMinutes < (24 * 60 * 31))
            {
                minutes = (int)Math.Floor(deltaMinutes / (60 * 24 * 7));
                return minutes + " weeks ago";
            }
            else if (deltaMinutes < (24 * 60 * 61))
            {
                return "Last month";
            }
            else if (deltaMinutes < (24 * 60 * 365.25))
            {
                minutes = (int)Math.Floor(deltaMinutes / (60 * 24 * 30));
                return minutes + " months ago";
            }
            else if (deltaMinutes < (24 * 60 * 731))
            {
                return "Last year";
            }
            else
            {
                minutes = (int)Math.Floor(deltaMinutes / (60 * 24 * 365));
                return minutes + " years ago";
            }
        }
    }
}
