using System.Runtime.Serialization;

namespace GoogleMapsAPI.NET.API.Places.Components
{
    /// <summary>
    /// Place opening period day time
    /// </summary>
    [DataContract]
    public class PlaceOpeningPeriodDayTime
    {

        #region Properties

        /// <summary>
        /// Corresponding to the days of the week, starting on Sunday.
        /// </summary>
        [DataMember(Name = "day")]
        public int Day { get; set; }

        /// <summary>
        /// Contain a time of day in 24-hour hhmm format. Values are in the range 0000–2359. The
        /// time will be reported in the place’s time zone.
        /// </summary>
        [DataMember(Name = "time")]
        public int Time { get; set; }

        #endregion
        
    }
}