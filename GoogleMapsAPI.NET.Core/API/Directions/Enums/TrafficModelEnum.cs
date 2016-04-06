using System.Runtime.Serialization;

namespace GoogleMapsAPI.NET.API.Directions.Enums
{

    /// <summary>
    /// Traffic model enum
    /// </summary>
    public enum TrafficModelEnum
    {
        /// <summary>
        /// The returned duration in traffic should be the best estimate of travel time given
        ///  what is known about both historical traffic conditions and live traffic
        /// </summary>
        [EnumMember(Value = "best_guess")]
        BestGuess,
        /// <summary>
        /// The returned duration in traffic should be longer than the actual travel time on 
        /// most days, though occasional days with particularly bad traffic conditions may 
        /// exceed this value.
        /// </summary>
        [EnumMember(Value = "pessimistic")]
        Pessimistic,
        /// <summary>
        /// the returned duration in traffic should be shorter than the actual travel time 
        /// on most days, though occasional days with particularly good traffic conditions 
        /// may be faster than this value.
        /// </summary>
        [EnumMember(Value = "optimistic")]
        Optimistic
    }
}