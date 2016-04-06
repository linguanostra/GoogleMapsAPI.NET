using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleMapsAPI.NET.API.Common.Responses;
using GoogleMapsAPI.NET.API.Roads.Components;

namespace GoogleMapsAPI.NET.API.Roads.Responses
{

    /// <summary>
    /// Snap to roads response
    /// </summary>
    [DataContract]
    public class SnapToRoadsResponse : APIV1Response
    {

        #region Properties

        /// <summary>
        /// Snapped points
        /// </summary>
        [DataMember(Name = "snappedPoints")]
        public List<SnappedPoint> SnappedPoints { get; set; }

        #endregion
         
    }
}