using System.Runtime.Serialization;

namespace GoogleMapsAPI.NET.API.Directions.Enums
{

    /// <summary>
    /// Geocoder status enum
    /// </summary>
    public enum GeocoderStatusEnum
    {
        /// <summary>
        /// No errors occurred; the address was successfully parsed and at least one geocode 
        /// was returned
        /// </summary>
        [EnumMember(Value = "OK")]
        OK,
        /// <summary>
        /// The geocode was successful but returned no results
        /// </summary>
        [EnumMember(Value = "ZERO_RESULTS")]
        ZeroResults
    }
}