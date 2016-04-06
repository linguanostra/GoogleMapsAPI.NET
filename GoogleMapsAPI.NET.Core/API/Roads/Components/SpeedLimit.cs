using System.Runtime.Serialization;
using GoogleMapsAPI.NET.API.Roads.Enums;

namespace GoogleMapsAPI.NET.API.Roads.Components
{

    /// <summary>
    /// Speed limit component
    /// </summary>
    [DataContract]
    public class SpeedLimit
    {

        #region Properties

        /// <summary>
        /// Place Id
        /// </summary>
        [DataMember(Name = "placeId")]
        public string PlaceId { get; set; }

        /// <summary>
        /// Speed limit for that road segment
        /// </summary>
        [DataMember(Name = "speedLimit")]
        public int Limit { get; set; }

        /// <summary>
        /// Units
        /// </summary>
        [DataMember(Name = "units")]
        public SpeedUnitEnum Units { get; set; }

        #endregion

    }
}