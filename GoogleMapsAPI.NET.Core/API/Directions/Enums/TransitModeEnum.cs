using System;
using System.Runtime.Serialization;

namespace GoogleMapsAPI.NET.API.Directions.Enums
{

    /// <summary>
    /// Transit mode enum
    /// </summary>
    [Flags]
    public enum TransitModeEnum
    {
        /// <summary>
        /// By bus
        /// </summary>
        [EnumMember(Value = "bus")]
        Bus = 1,
        /// <summary>
        /// By subway
        /// </summary>
        [EnumMember(Value = "subway")]
        Subway = 2,
        /// <summary>
        /// By train
        /// </summary>
        [EnumMember(Value = "train")]
        Train = 4,
        /// <summary>
        /// By tram and light rail.
        /// </summary>
        [EnumMember(Value = "tram")]
        Tram = 8,
        /// <summary>
        /// By train, tram, light rail, and subway
        /// </summary>
        [EnumMember(Value = "rail")]
        Rail = 16
    }
}