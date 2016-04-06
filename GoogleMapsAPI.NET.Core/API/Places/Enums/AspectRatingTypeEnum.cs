using System.Runtime.Serialization;

namespace GoogleMapsAPI.NET.API.Places.Enums
{

    /// <summary>
    /// Aspect rating type enum
    /// </summary>
    public enum AspectRatingTypeEnum
    {
        /// <summary>
        /// Appeal
        /// </summary>
        [EnumMember(Value = "appeal")]
        Appeal,
        /// <summary>
        /// Atmosphere
        /// </summary>
        [EnumMember(Value = "atmosphere")]
        Atmosphere,
        /// <summary>
        /// Decor
        /// </summary>
        [EnumMember(Value = "decor")]
        Decor,
        /// <summary>
        /// Facilities
        /// </summary>
        [EnumMember(Value = "facilities")]
        Facilities,
        /// <summary>
        /// Food
        /// </summary>
        [EnumMember(Value = "food")]
        Food,
        /// <summary>
        /// Overall
        /// </summary>
        [EnumMember(Value = "overall")]
        Overall,
        /// <summary>
        /// Quality
        /// </summary>
        [EnumMember(Value = "quality")]
        Quality,
        /// <summary>
        /// Service
        /// </summary>
        [EnumMember(Value = "service")]
        Service,
    }
}