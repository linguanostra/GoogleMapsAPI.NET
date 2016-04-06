using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleMapsAPI.NET.API.Common.Attributes;
using GoogleMapsAPI.NET.API.Common.Components.Locations;

namespace GoogleMapsAPI.NET.API.Places.Components
{

    /// <summary>
    /// Place details geometry component
    /// </summary>
    [DataContract]
    public class PlaceDetailsGeometry
    {

        #region Properties

        /// <summary>
        /// The geocoded latitude, longitude value
        /// </summary>
        [DataMember(Name = "location")]
        public GeoCoordinatesLocation Location { get; set; }

        /// <summary>
        /// Access points
        /// </summary>
        [DataMember(Name = "access_points")]
        [GoogleAPIUndocumented(2016,4,5)]
        public List<PlaceGeometryAccessPoint> AccessPoints { get; set; }

        #endregion

    }
}