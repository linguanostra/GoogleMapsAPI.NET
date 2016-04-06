using System.Runtime.Serialization;
using GoogleMapsAPI.NET.API.Places.Enums;

namespace GoogleMapsAPI.NET.API.Places.Components.Premium
{

    /// <summary>
    /// Place premium aspect rating component
    /// </summary>
    [DataContract]
    public class PlacePremiumAspectRating
    {

        #region Properties

        /// <summary>
        /// The aspect that is being rated.
        /// </summary>
        [DataMember(Name = "type")]
        public AspectRatingTypeEnum Type { get; set; }

        /// <summary>
        /// the aggregate rating for this particular aspect, from 0 to 30. Note that aggregate ratings
        /// range from 0 to 30, while ratings that appear as part of a review range from 0 to 3.
        /// </summary>
        [DataMember(Name = "rating")]
        public int Rating { get; set; }

        #endregion

    }
}