using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GoogleMapsAPI.NET.API.Places.Components
{
    /// <summary>
    /// Place details opening hours component
    /// </summary>
    [DataContract]
    public class PlaceDetailsOpeningHours : PlaceOpeningHours
    {

        #region Properties

        /// <summary>
        /// Opening periods covering seven days, starting from Sunday, in chronological order. 
        /// </summary>
        [DataMember(Name = "periods")]
        public List<PlaceOpeningPeriods> Periods { get; set; }

        /// <summary>
        /// Seven strings representing the formatted opening hours for each day of the week
        /// </summary>
        [DataMember(Name = "weekday_text")]
        public List<string> WeekdayText { get; set; }

        #endregion

    }
}