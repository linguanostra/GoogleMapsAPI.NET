using System.Runtime.Serialization;

namespace GoogleMapsAPI.NET.API.Roads.Enums
{

    /// <summary>
    /// Speed unit enum
    /// </summary>
    public enum SpeedUnitEnum
    {
        /// <summary>
        /// Kilometers per hour
        /// </summary>
        [EnumMember(Value = "KPH")]
        KPH,
        /// <summary>
        /// Miles per hour
        /// </summary>
        [EnumMember(Value = "MPH")]
        MPH
    }
}