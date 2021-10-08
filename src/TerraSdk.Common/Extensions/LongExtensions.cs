using System;

namespace TerraSdk.Common.Extensions
{
    public static class LongExtensions
    {
        /// <summary>
        /// Converts Terra duration to dotnet <see cref="TimeSpan"/>. Warning: possible loss of precision.
        /// </summary>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static TimeSpan TerraDurationToTimeSpan(this long duration)
        {
            return new TimeSpan(duration / 100);
        }

        /// <summary>
        /// Converts Terra duration to dotnet <see cref="TimeSpan"/>. Warning: possible loss of precision.
        /// </summary>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static TimeSpan? TerraDurationToTimeSpan(this long? duration)
        {
            if (duration == null)
            {
                return null;
            }
            return new TimeSpan(duration.Value / 100);
        }
    }
}