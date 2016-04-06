using System;
using GoogleMapsAPI.NET.API.Common.Components.Locations;
using GoogleMapsAPI.NET.API.Geometry.Extensions;

namespace GoogleMapsAPI.NET.API.Geometry.Types
{
    /// <summary>
    /// Spherical geometry API
    /// </summary>
    public class SphericalGeometry
    {

        #region Methods

        #region Public

        /// <summary>
        /// Compute distance between 2 coordinates
        /// </summary>
        /// <param name="origin">Origin</param>
        /// <param name="destination">Destination</param>
        /// <param name="radius">Earth's mean radius (in meters)</param>
        /// <returns>Result distance</returns>
        public double ComputeDistanceBetween(GeoCoordinatesLocation origin, GeoCoordinatesLocation destination, double radius = 6378137)
        {

            // Get radians
            var origLatRad = origin.Latitude.ToRadians();
            var origLngRad = origin.Longitude.ToRadians();
            var destLatRad = destination.Latitude.ToRadians();
            var destLngRad = destination.Longitude.ToRadians();

            // Compute distance using Haversine formula
            var distance =
                (2*Math.Asin(
                    Math.Sqrt(Math.Pow(Math.Sin((origLatRad - destLatRad)/2), 2) +
                              Math.Cos(origLatRad)*Math.Cos(destLatRad)*
                              Math.Pow(Math.Sin((origLngRad - destLngRad)/2), 2))))
                    * radius;

            // Return it
            return distance;

        }

        #endregion

        #endregion

    }
}