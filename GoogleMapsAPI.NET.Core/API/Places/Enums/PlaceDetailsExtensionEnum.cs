using System;
using System.Runtime.Serialization;

namespace GoogleMapsAPI.NET.API.Places.Enums
{

    /// <summary>
    /// Place details extension enum
    /// </summary>
    [Flags]
    public enum PlaceDetailsExtensionEnum
    {
        /// <summary>
        /// Includes a rich and concise review curated by Google's editorial staff.
        /// </summary>
        [EnumMember(Value = "review_summary")]
        ReviewSummary
    }
}