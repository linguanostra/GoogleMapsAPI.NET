using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleMapsAPI.NET.API.Roads.Components;

namespace GoogleMapsAPI.NET.API.Roads.Responses
{

    /// <summary>
    /// Speed limits response
    /// </summary>
    [DataContract]
    public class SpeedLimitsResponse : SnapToRoadsResponse
    {

        #region Properties

        /// <summary>
        /// Road metadata
        /// </summary>
        [DataMember(Name = "speedLimits")]
        public List<SpeedLimit> SpeedLimits { get; set; }

        #endregion

    }
}