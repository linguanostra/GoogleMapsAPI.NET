using System.Runtime.Serialization;
using GoogleMapsAPI.NET.API.Places.Enums;

namespace GoogleMapsAPI.NET.API.Places.Components
{

    /// <summary>
    /// Place aspect rating component
    /// </summary>
    [DataContract]
    public class PlaceAspectRating
    {

        #region Properties

        /// <summary>
        /// The aspect that is being rated.
        /// </summary>
        [DataMember(Name = "type")]
        public AspectRatingTypeEnum Type { get; set; }

        /// <summary>
        /// The user's rating for this particular aspect, from 0 to 3.
        /// </summary>
        [DataMember(Name = "rating")]
        public int Rating { get; set; }

        #endregion

    }
}