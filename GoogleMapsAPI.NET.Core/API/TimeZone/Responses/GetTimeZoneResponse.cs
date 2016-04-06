using System.Runtime.Serialization;
using GoogleMapsAPI.NET.API.Common.Responses;

namespace GoogleMapsAPI.NET.API.TimeZone.Responses
{

    /// <summary>
    /// Get time zone response
    /// </summary>
    [DataContract]
    public class GetTimeZoneResponse : APIResponse
    {

        #region Properties

        /// <summary>
        /// The offset for daylight-savings time in seconds. This will be zero if the time zone is not in Daylight Savings 
        /// Time during the specified timestamp.
        /// </summary>
        [DataMember(Name = "dstOffset")]
        public long DstOffset { get; set; }

        /// <summary>
        /// The offset from UTC (in seconds) for the given location. This does not take into effect daylight savings.
        /// </summary>
        [DataMember(Name = "rawOffset")]
        public long RawOffset { get; set; }

        /// <summary>
        /// The "tz" ID of the time zone, such as "America/Los_Angeles" or "Australia/Sydney". 
        /// </summary>
        [DataMember(Name = "timeZoneId")]
        public string TimeZoneId { get; set; }

        /// <summary>
        /// The long form name of the time zone
        /// </summary>
        [DataMember(Name = "timeZoneName")]
        public string TimeZoneName { get; set; }

        #endregion

    }
}