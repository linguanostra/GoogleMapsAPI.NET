using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleMapsAPI.NET.API.Common.Components;
using GoogleMapsAPI.NET.API.Common.Components.Locations;
using GoogleMapsAPI.NET.API.Directions.Components;

namespace GoogleMapsAPI.NET.API.Directions.Results
{

    /// <summary>
    /// Get directions route result
    /// </summary>
    [DataContract]
    public class GetDirectionsRouteResult
    {

        #region Properties

        /// <summary>
        /// Short textual description for the route
        /// </summary>
        [DataMember(Name = "summary")]
        public string Summary { get; set; }

        /// <summary>
        /// The copyrights text to be displayed for this route
        /// </summary>
        [DataMember(Name = "copyrights")]
        public string Copyrights { get; set; }

        /// <summary>
        /// Warnings to be displayed when showing these directions
        /// </summary>
        [DataMember(Name = "warnings")]
        public List<string> Warnings { get; set; }

        /// <summary>
        /// The total fare (that is, the total ticket costs) on this route.
        /// </summary>
        [DataMember(Name = "fare")]
        public Fare Fare { get; set; }

        /// <summary>
        /// The viewport bounding box of the overview_polyline
        /// </summary>
        [DataMember(Name = "bounds")]
        public ViewportBoundingBox Bounds { get; set; }

        /// <summary>
        /// This polyline is an approximate (smoothed) path of the resulting directions
        /// </summary>
        [DataMember(Name = "overview_polyline")]
        public EncodedPolyline OverviewPolyline { get; set; }

        /// <summary>
        /// Legs of the route
        /// </summary>
        [DataMember(Name = "legs")]
        public List<RouteLeg> Legs { get; set; }

        /// <summary>
        /// An array indicating the order of any waypoints in the calculated route
        /// </summary>
        [DataMember(Name = "waypoint_order")]
        public List<int> WaypointOrder { get; set; }

        #endregion

        #region Computed properties

        /// <summary>
        /// Overview path coordinates
        /// </summary>
        [DataMember(Name = "overview_path")]
        public List<GeoCoordinatesLocation> OverviewPath => OverviewPolyline.DecodePoints();

        #endregion

    }
}