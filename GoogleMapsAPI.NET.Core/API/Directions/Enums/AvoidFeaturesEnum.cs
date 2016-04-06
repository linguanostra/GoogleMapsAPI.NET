using System;
using System.Runtime.Serialization;

namespace GoogleMapsAPI.NET.API.Directions.Enums
{

    /// <summary>
    /// Avoidable features enum
    /// </summary>
    [Flags]
    public enum AvoidFeaturesEnum
    {
        /// <summary>
        /// Avoid toll roads/bridges
        /// </summary>
        [EnumMember(Value = "tolls")]
        Tolls = 1,
        /// <summary>
        /// avoid highways
        /// </summary>
        [EnumMember(Value = "highways")]
        Highways = 2,
        /// <summary>
        /// Avoid ferries
        /// </summary>
        [EnumMember(Value = "ferries")]
        Ferries = 4,
        /// <summary>
        /// Avoid indoor steps for walking and transit directions
        /// </summary>
        [EnumMember(Value = "indoors")]
        Indoors = 8
    }
}