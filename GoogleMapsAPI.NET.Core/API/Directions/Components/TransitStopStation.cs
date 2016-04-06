using System.Runtime.Serialization;
using GoogleMapsAPI.NET.API.Common.Components.Locations;

namespace GoogleMapsAPI.NET.API.Directions.Components
{
    /// <summary>
    /// Transit/stop station component
    /// </summary>
    [DataContract]
    public class TransitStopStation
    {

        #region Properties

        /// <summary>
        /// Name of the transit station/stop
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Location of the transit station/stop
        /// </summary>
        [DataMember(Name = "location")]
        public GeoCoordinatesLocation Location { get; set; }

        #endregion

    }
}