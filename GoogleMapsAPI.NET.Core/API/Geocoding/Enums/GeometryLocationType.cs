using System;
using System.Runtime.Serialization;

namespace GoogleMapsAPI.NET.API.Geocoding.Enums
{
    /// <summary>
    /// Geometry location type enum
    /// </summary>
    [Flags]
    public enum GeometryLocationType
    {
        /// <summary>
        /// Precise geocode for which we have location information accurate down 
        /// to street address precision
        /// </summary>
        [EnumMember(Value = "ROOFTOP")]
        Rooftop = 1,
        /// <summary>
        /// Reflects an approximation (usually on a road) interpolated between two 
        /// precise points (such as intersections). Interpolated results are generally 
        /// returned when rooftop geocodes are unavailable for a street address.
        /// </summary>
        [EnumMember(Value = "RANGE_INTERPOLATED")]
        RangeInterpolated = 2,
        /// <summary>
        /// Geometric center of a result such as a polyline (for example, a street) 
        /// or polygon (region)
        /// </summary>
        [EnumMember(Value = "GEOMETRIC_CENTER")]
        GeometricCenter = 4,
        /// <summary>
        /// Returned result is approximate
        /// </summary>
        [EnumMember(Value = "APPROXIMATE")]
        Approximate = 8
    }
}