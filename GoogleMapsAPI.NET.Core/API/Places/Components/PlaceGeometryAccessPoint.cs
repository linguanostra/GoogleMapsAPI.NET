using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleMapsAPI.NET.API.Common.Components.Locations;
using GoogleMapsAPI.NET.API.Directions.Enums;

namespace GoogleMapsAPI.NET.API.Places.Components
{

    /// <summary>
    /// Place geometry access point component
    /// </summary>
    [DataContract]
    public class PlaceGeometryAccessPoint
    {

        #region Properties

        /// <summary>
        /// Location
        /// </summary>
        [DataMember(Name = "location")]
        public GeoCoordinatesLocation Location { get; set; }

        /// <summary>
        /// Travel modes
        /// </summary>
        [DataMember(Name = "travel_modes")]
        public List<TransportationModeEnum> TravelModes { get; set; }

        #endregion

    }
}