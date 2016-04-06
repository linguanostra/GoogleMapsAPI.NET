using System.Runtime.Serialization;

namespace GoogleMapsAPI.NET.API.Directions.Enums
{

    /// <summary>
    /// Unit system enum
    /// </summary>
    public enum UnitSystemEnum
    {
        /// <summary>
        /// Metric system. Textual distances are returned using kilometers and meters.
        /// </summary>
        [EnumMember(Value = "metric")]
        Metric,
        /// <summary>
        /// Imperial (English) system. Textual distances are returned using miles and feet.
        /// </summary>
        [EnumMember(Value = "imperial")]
        Imperial
    }
}