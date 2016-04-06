using System.Runtime.Serialization;

namespace GoogleMapsAPI.NET.API.Places.Enums
{

    /// <summary>
    /// Place rank by enum
    /// </summary>
    public enum PlaceRankByEnum
    {
        /// <summary>
        /// Sorts results based on their importance.
        /// </summary>
        [EnumMember(Value = "prominence")]
        Prominence,
        /// <summary>
        /// Biases search results in ascending order by their distance from the specified location
        /// </summary>
        [EnumMember(Value = "distance")]
        Distance
    }
}