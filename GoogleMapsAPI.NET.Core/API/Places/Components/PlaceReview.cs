using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleMapsAPI.NET.API.Common.Attributes;
using GoogleMapsAPI.NET.Utils.Serialization;
using Newtonsoft.Json;

namespace GoogleMapsAPI.NET.API.Places.Components
{

    /// <summary>
    /// Place review component
    /// </summary>
    [DataContract]
    public class PlaceReview
    {

        #region Properties

        /// <summary>
        /// Rating of aspects of the establishment
        /// </summary>
        [DataMember(Name = "aspects")]
        public List<PlaceAspectRating> Aspects { get; set; }

        /// <summary>
        /// The name of the user who submitted the review.
        /// </summary>
        [DataMember(Name = "author_name")]
        public string AuthorName { get; set; }

        /// <summary>
        /// The URL to the users Google+ profile, if available.
        /// </summary>
        [DataMember(Name = "author_url")]
        public string AuthorUrl { get; set; }

        /// <summary>
        /// The URL to the users Google+ photo, if available.
        /// </summary>
        [DataMember(Name = "profile_photo_url")]
        [GoogleAPIUndocumented(2016,4,5)]
        public string ProfilePhotoUrl { get; set; }

        /// <summary>
        /// an IETF language code indicating the language used in the user's review.
        /// </summary>
        [DataMember(Name = "language")]
        public string Language { get; set; }

        /// <summary>
        /// the user's overall rating for this place. This is a whole number, ranging from 1 to 5.
        /// </summary>
        [DataMember(Name = "rating")]
        public int Rating { get; set; }

        /// <summary>
        /// The user's review. 
        /// </summary>
        [DataMember(Name = "text")]
        public string Text { get; set; }

        /// <summary>
        /// The time that the review was submitted
        /// TODO: Custom test for this converter
        /// </summary>
        [DataMember(Name = "time")]
        [JsonConverter(typeof(JsonEpochDateTimeConverter))]
        public DateTime Time { get; set; }

        #endregion

    }
}