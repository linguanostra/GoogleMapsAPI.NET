using System.Runtime.Serialization;
using GoogleMapsAPI.NET.API.Common.Components.Locations.Common;
using GoogleMapsAPI.NET.API.Common.Components.Locations.Interfaces;

namespace GoogleMapsAPI.NET.API.Roads.Components
{

    /// <summary>
    /// Snapped point geographic coordinates location
    /// </summary>
    [DataContract]
    public class SnappedPointGeoCoordinatesLocation : Location, IGeoCoordinatesLocation
    {

        #region Properties

        /// <summary>
        /// Latitude value
        /// </summary>
        [DataMember(Name = "latitude")]
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude value
        /// </summary>
        [DataMember(Name = "longitude")]
        public double Longitude { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new instance
        /// </summary>
        public SnappedPointGeoCoordinatesLocation()
        {
        }

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="latitude">Latitude</param>
        /// <param name="longitude">Longitude</param>
        public SnappedPointGeoCoordinatesLocation(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        #endregion

    }
}