using System;

namespace GoogleMapsAPI.NET.API.Geometry.Extensions
{

    /// <summary>
    /// Geometry extensions
    /// </summary>
    public static class GeometryExtensions
    {

        #region Extension methods

        /// <summary>
        /// Convert degrees to radians
        /// </summary>
        /// <param name="degrees">Degrees</param>
        /// <returns>Result radians</returns>
        public static double ToRadians(this double degrees)
        {

            return degrees * Math.PI / 180;

        } 

        /// <summary>
        /// Convert radians to degrees
        /// </summary>
        /// <param name="radians">Radians</param>
        /// <returns>Result degrees</returns>
        public static double ToDegrees(this double radians)
        {

            return radians * 180 / Math.PI;

        } 

        #endregion
         
    }
}