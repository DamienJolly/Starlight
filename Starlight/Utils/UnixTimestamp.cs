using System;

namespace Starlight.Utils
{
    internal static class UnixTimestamp
    {
		internal static DateTime FromUnixTimestamp(double timestamp) => 
            new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(timestamp);

		internal static double Now => 
            (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;

        internal static bool IsToday(double timestamp) =>
            IsToday(FromUnixTimestamp(timestamp));

        internal static bool IsToday(DateTime time) =>
            time.Date == DateTime.Today;

        internal static bool IsYesterday(double timestamp) =>
            IsYesterday(FromUnixTimestamp(timestamp));

        internal static bool IsYesterday(DateTime time) =>
            DateTime.Today - time.Date == TimeSpan.FromDays(1);
    }
}
