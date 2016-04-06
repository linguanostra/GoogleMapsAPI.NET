using System.Runtime.Serialization;
using GoogleMapsAPI.NET.API.Common.Components.Locations.Common;
using GoogleMapsAPI.NET.API.Common.Components.Locations.Interfaces;

namespace GoogleMapsAPI.NET.API.Common.Components.Locations
{

    /// <summary>
    /// Geographic coordinates location
    /// </summary>
    [DataContract]
    public class GeoCoordinatesLocation : Location, IGeoCoordinatesLocation
    {

        #region Properties

        /// <summary>
        /// Latitude value
        /// </summary>
        [DataMember(Name = "lat")]
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude value
        /// </summary>
        [DataMember(Name = "lng")]
        public double Longitude { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new instance
        /// </summary>
        public GeoCoordinatesLocation()
        {
        }

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="latitude">Latitude</param>
        /// <param name="longitude">Longitude</param>
        public GeoCoordinatesLocation(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        #endregion

    }

}