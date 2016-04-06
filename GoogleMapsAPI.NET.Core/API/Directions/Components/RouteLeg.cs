using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleMapsAPI.NET.API.Common.Components;
using GoogleMapsAPI.NET.API.Common.Components.Locations;

namespace GoogleMapsAPI.NET.API.Directions.Components
{

    /// <summary>
    /// Route leg component
    /// </summary>
    [DataContract]
    public class RouteLeg
    {

        #region Properties

        /// <summary>
        /// Steps of the leg of the journey
        /// </summary>
        [DataMember(Name = "steps")]
        public List<RouteLegStep> Steps { get; set; }

        /// <summary>
        /// The total distance covered by this leg
        /// </summary>
        [DataMember(Name = "distance")]
        public Distance Distance { get; set; }

        /// <summary>
        /// The total duration of this leg
        /// </summary>
        [DataMember(Name = "duration")]
        public Duration Duration { get; set; }

        /// <summary>
        /// The total duration in traffic of this leg
        /// </summary>
        [DataMember(Name = "duration_in_traffic")]
        public Duration DurationInTraffic { get; set; }

        /// <summary>
        /// The location of the starting point of this leg
        /// </summary>
        [DataMember(Name = "start_location")]
        public GeoCoordinatesLocation StartLocation { get; set; }

        /// <summary>
        /// The location of the last point of this leg
        /// </summary>
        [DataMember(Name = "end_location")]
        public GeoCoordinatesLocation EndLocation { get; set; }

        /// <summary>
        /// Human-readable address (typically a street address) resulting from reverse geocoding the 
        /// start_location of this leg.
        /// </summary>
        [DataMember(Name = "start_address")]
        public string StartAddress { get; set; }

        /// <summary>
        /// Human-readable address (typically a street address) from reverse geocoding the end_location
        /// of this leg.
        /// </summary>
        [DataMember(Name = "end_address")]
        public string EndAddress { get; set; }

        #endregion

    }
}