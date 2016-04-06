using System.Runtime.Serialization;
using GoogleMapsAPI.NET.API.Common.Components.Locations;

namespace GoogleMapsAPI.NET.API.Elevation.Results
{

    /// <summary>
    /// Get elevation result
    /// </summary>
    [DataContract]
    public class GetElevationResult
    {

        #region Properties

        /// <summary>
        /// Elevation
        /// </summary>
        [DataMember(Name = "elevation")]
        public double Elevation { get; set; }

        /// <summary>
        /// Location
        /// </summary>
        [DataMember(Name = "location")]
        public GeoCoordinatesLocation Location { get; set; }

        /// <summary>
        /// Resolution
        /// </summary>
        [DataMember(Name = "resolution")]
        public double Resolution { get; set; }

        #endregion

    }
}