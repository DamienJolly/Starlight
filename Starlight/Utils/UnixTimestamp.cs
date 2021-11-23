using System;

namespace Starlight.Utils
{
    internal static class UnixTimestamp
    {
		internal static DateTime FromUnixTimestamp(double timestamp) =>
            DateTime.UnixEpoch.AddSeconds(timestamp);

        internal static long Now =>
            DateTimeOffset.Now.ToUnixTimeSeconds();

        internal static bool IsToday(double timestamp) =>
            IsToday(FromUnixTimestamp(timestamp));

        internal static bool IsToday(DateTime time) =>
            time.Date == DateTime.Today;

        internal static bool IsYesterday(double timestamp) =>
            IsYesterday(FromUnixTimestamp(timestamp));

        internal static bool IsYesterday(DateTime time) =>
            DateTime.Today - TimeSpan.FromDays(1) == time.Date;
    }
}
