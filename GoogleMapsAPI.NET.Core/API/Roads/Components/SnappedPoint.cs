using System.Runtime.Serialization;

namespace GoogleMapsAPI.NET.API.Roads.Components
{

    /// <summary>
    /// Snapped point component
    /// </summary>
    [DataContract]
    public class SnappedPoint
    {

        #region Properties

        /// <summary>
        /// Location
        /// </summary>
        [DataMember(Name = "location")]
        public SnappedPointGeoCoordinatesLocation Location { get; set; }

        /// <summary>
        /// Original index
        /// </summary>
        [DataMember(Name = "originalIndex")]
        public int? OriginalIndex { get; set; }

        /// <summary>
        /// A unique identifier for a place.
        /// </summary>
        [DataMember(Name = "placeId")]
        public string PlaceId { get; set; }

        #endregion

    }
}