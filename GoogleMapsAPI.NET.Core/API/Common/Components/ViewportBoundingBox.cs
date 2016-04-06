using System.Runtime.Serialization;
using GoogleMapsAPI.NET.API.Common.Components.Locations;

namespace GoogleMapsAPI.NET.API.Common.Components
{
    /// <summary>
    /// Viewport bounding box
    /// </summary>
    [DataContract]
    public class ViewportBoundingBox
    {

        #region Properties

        /// <summary>
        /// South west corner of the viewport bounding box
        /// </summary>
        [DataMember(Name = "southwest")]
        public GeoCoordinatesLocation Southwest { get; set; }

        /// <summary>
        /// North east corner of the viewport bounding box
        /// </summary>
        [DataMember(Name = "northeast")]
        public GeoCoordinatesLocation NorthEast { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new instance
        /// </summary>
        public ViewportBoundingBox()
        {
            NorthEast = new GeoCoordinatesLocation();
            Southwest = new GeoCoordinatesLocation();
        }

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="southwest">South west corner of the viewport bounding box</param>
        /// <param name="northEast">North east corner of the viewport bounding box</param>
        public ViewportBoundingBox(GeoCoordinatesLocation southwest, GeoCoordinatesLocation northEast)
        {
            Southwest = southwest;
            NorthEast = northEast;
        }

        #endregion

    }
}