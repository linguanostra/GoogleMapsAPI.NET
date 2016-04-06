using System.Runtime.Serialization;
using GoogleMapsAPI.NET.API.Common.Components;
using GoogleMapsAPI.NET.API.Common.Responses;

namespace GoogleMapsAPI.NET.API.DistanceMatrix.Components
{
    /// <summary>
    /// Row element component
    /// </summary>
    [DataContract]
    public class DistanceMatrixRowElement : APIResponse
    {

        #region Properties

        /// <summary>
        /// Duration
        /// </summary>
        [DataMember(Name = "duration")]
        public Duration Duration { get; set; }

        /// <summary>
        /// Distance
        /// </summary>
        [DataMember(Name = "distance")]
        public Duration Distance { get; set; }

        #endregion

    }
}