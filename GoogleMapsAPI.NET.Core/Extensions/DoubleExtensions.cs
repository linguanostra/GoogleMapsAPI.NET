using System;

namespace GoogleMapsAPI.NET.Extensions
{

    /// <summary>
    /// Double values extensions
    /// </summary>
    public static class DoubleExtensions
    {

        #region Static methods

        /// <summary>
        /// Round geo coordinate (lat/lng) value
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>Rounded value</returns>
        public static double RoundGeoCoordinate(this double value)
        {

            return Math.Round(value*1e5) / 1e5;

        } 

        #endregion
         
    }
}