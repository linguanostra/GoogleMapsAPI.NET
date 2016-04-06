using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleMapsAPI.NET.API.Common.Responses;
using GoogleMapsAPI.NET.API.Directions.Components;
using GoogleMapsAPI.NET.API.Directions.Results;

namespace GoogleMapsAPI.NET.API.Directions.Responses
{

    /// <summary>
    /// Get directions response
    /// </summary>
    [DataContract]
    public class GetDirectionsResponse : APIResponse
    {

        #region Properties

        /// <summary>
        /// Routes
        /// </summary>
        [DataMember(Name = "routes")]
        public List<GetDirectionsRouteResult> Routes { get; set; }

        /// <summary>
        /// Geocoded waypoints
        /// </summary>
        [DataMember(Name = "geocoded_waypoints")]        
        public List<GeocodedWaypoint> GeocodedWaypoints { get; set; }

        #endregion

    }

}