using System;

namespace GoogleMapsAPI.NET.Extensions
{

    /// <summary>
    /// Date/Time extensions
    /// </summary>
    public static class DateTimeExtensions
    {

        #region Extension methods

        /// <summary>
        /// Get the number of seconds since Unix epoch
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>Result value</returns>
        public static long SecondsSinceEpoch(this DateTime value)
        {
            
            return (long)(value.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;

        }

        /// <summary>
        /// Convert numeric value of seconds since Unix epoch to DateTime
        /// </summary>
        /// <param name="seconds">Seconds since Unix epoch</param>
        /// <returns>Result value</returns>
        public static DateTime ToDateTimeFromEpochSeconds(this long seconds)
        {

            // Get Unix epoch date
            var epochDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            // Add seconds
            return epochDate.AddSeconds(seconds);

        }

        #endregion

    }
}