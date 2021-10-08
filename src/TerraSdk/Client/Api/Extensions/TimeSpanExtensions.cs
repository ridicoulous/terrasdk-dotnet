using System;

namespace TerraSdk.Client.Api.Extensions
{
    public static class TimeSpanExtensions
    {
        public static long ToTerraDuration(this TimeSpan timeSpan)
        {
            return timeSpan.Ticks * 100;
        }

        public static long? ToTerraDuration(this TimeSpan? timeSpan)
        {
            return timeSpan?.Ticks * 100;
        }
    }
}