using System.Runtime.Serialization;
using GoogleMapsAPI.NET.API.Common.Components;
using GoogleMapsAPI.NET.API.Common.Components.Locations;

namespace GoogleMapsAPI.NET.API.Places.Components
{

    /// <summary>
    /// Place geometry component
    /// </summary>
    [DataContract]
    public class PlaceGeometry
    {

        #region Properties

        /// <summary>
        /// The geocoded latitude, longitude value
        /// </summary>
        [DataMember(Name = "location")]
        public GeoCoordinatesLocation Location { get; set; }

        /// <summary>
        /// Recommended viewport for displaying the returned result
        /// </summary>
        [DataMember(Name = "viewport")]
        public ViewportBoundingBox Viewport { get; set; }

        #endregion
         
    }
}