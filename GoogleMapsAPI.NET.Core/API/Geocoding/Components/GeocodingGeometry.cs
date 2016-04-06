using System.Runtime.Serialization;
using GoogleMapsAPI.NET.API.Common.Components;
using GoogleMapsAPI.NET.API.Common.Components.Locations;
using GoogleMapsAPI.NET.API.Geocoding.Enums;

namespace GoogleMapsAPI.NET.API.Geocoding.Components
{
    /// <summary>
    /// Geocoding geometry component
    /// </summary>
    [DataContract]
    public class GeocodingGeometry
    {

        #region Properties

        /// <summary>
        /// The geocoded latitude, longitude value
        /// </summary>
        [DataMember(Name = "location")]
        public GeoCoordinatesLocation Location { get; set; }

        /// <summary>
        /// Location type
        /// </summary>
        [DataMember(Name = "location_type")]
        public GeometryLocationType LocationType { get; set; }

        /// <summary>
        /// Recommended viewport for displaying the returned result
        /// </summary>
        [DataMember(Name = "viewport")]
        public ViewportBoundingBox Viewport { get; set; }

        #endregion

    }
}