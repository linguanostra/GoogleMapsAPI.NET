using System.Runtime.Serialization;

namespace GoogleMapsAPI.NET.API.Places.Enums
{

    /// <summary>
    /// Place scope enum
    /// </summary>
    public enum PlaceScopeEnum
    {
        /// <summary>
        /// Is recognised by your application only
        /// </summary>
        [EnumMember(Value = "APP")]
        Application,
        /// <summary>
        /// Is available to other applications and on Google Maps
        /// </summary>
        [EnumMember(Value = "GOOGLE")]
        Google
    }
}