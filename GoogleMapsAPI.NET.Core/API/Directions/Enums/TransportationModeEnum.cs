using System.Runtime.Serialization;

namespace GoogleMapsAPI.NET.API.Directions.Enums
{

    /// <summary>
    /// Transportation mode enum
    /// </summary>
    public enum TransportationModeEnum
    {
        /// <summary>
        /// Standard driving directions using the road network
        /// </summary>
        [EnumMember(Value = "driving")]
        Driving,
        /// <summary>
        /// Via pedestrian paths and sidewalks (where available).
        /// </summary>
        [EnumMember(Value = "walking")]
        Walking,
        /// <summary>
        /// Bicycle paths and preferred streets (where available).
        /// </summary>
        [EnumMember(Value = "bicycling")]
        Bicycling,
        /// <summary>
        /// Via public transit routes (where available)
        /// </summary>
        [EnumMember(Value = "transit")]
        Transit
    }
}