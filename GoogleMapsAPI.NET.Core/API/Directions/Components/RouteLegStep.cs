using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleMapsAPI.NET.API.Common.Components;
using GoogleMapsAPI.NET.API.Common.Components.Locations;
using GoogleMapsAPI.NET.API.Directions.Enums;

namespace GoogleMapsAPI.NET.API.Directions.Components
{
    /// <summary>
    /// Route leg step
    /// </summary>
    [DataContract]
    public class RouteLegStep
    {

        #region Properties

        /// <summary>
        /// Formatted instructions for this step, presented as an HTML text string.
        /// </summary>
        [DataMember(Name = "html_instructions")]
        public string HTMLInstructions { get; set; }

        /// <summary>
        /// Traveling mode
        /// </summary>
        [DataMember(Name = "travel_mode")]
        public TransportationModeEnum TravelMode { get; set; }

        /// <summary>
        /// The distance covered by this step until the next step
        /// </summary>
        [DataMember(Name = "distance")]
        public Distance Distance { get; set; }

        /// <summary>
        /// The typical time required to perform the step, until the next step
        /// </summary>
        [DataMember(Name = "duration")]
        public Duration Duration { get; set; }

        /// <summary>
        /// The location of the starting point of this step
        /// </summary>
        [DataMember(Name = "start_location")]
        public GeoCoordinatesLocation StartLocation { get; set; }

        /// <summary>
        /// The location of the last point of this step
        /// </summary>
        [DataMember(Name = "end_location")]
        public GeoCoordinatesLocation EndLocation { get; set; }

        /// <summary>
        /// This polyline is an approximate (smoothed) path of the step
        /// </summary>
        [DataMember(Name = "polyline")]
        public EncodedPolyline Polyline { get; set; }

        /// <summary>
        /// Detailed directions for walking or driving steps in transit directions.
        /// Substeps are only available when travel_mode is set to "transit". 
        /// </summary>
        [DataMember(Name = "steps")]
        public List<RouteLegStep> Steps { get; set; }

        /// <summary>
        /// Transit specific information. This field is only returned with travel_mode is 
        /// set to "transit".
        /// </summary>
        [DataMember(Name = "transit_details")]
        public TransitDetails TransitDetails { get; set; }

        #endregion

    }
}