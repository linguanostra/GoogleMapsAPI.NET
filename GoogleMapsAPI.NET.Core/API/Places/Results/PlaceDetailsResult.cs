using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleMapsAPI.NET.API.Common.Attributes;
using GoogleMapsAPI.NET.API.Geocoding.Components;
using GoogleMapsAPI.NET.API.Places.Components;
using GoogleMapsAPI.NET.API.Places.Components.Premium;
using GoogleMapsAPI.NET.API.Places.Enums;

namespace GoogleMapsAPI.NET.API.Places.Results
{

    /// <summary>
    /// Place details results
    /// </summary>
    [DataContract]
    public class PlaceDetailsResult
    {

        #region Properties

        /// <summary>
        /// Address components
        /// </summary>
        [DataMember(Name = "address_components")]
        public List<Address> AddressComponents { get; set; }

        /// <summary>
        /// Geometry information about the place
        /// </summary>
        [DataMember(Name = "geometry")]
        public PlaceDetailsGeometry Geometry { get; set; }

        /// <summary>
        /// Human-readable address of this place
        /// </summary>
        [DataMember(Name = "formatted_address")]
        public string FormattedAddress { get; set; }

        /// <summary>
        /// The place's phone number in its local format.
        /// </summary>
        [DataMember(Name = "formatted_phone_number")]
        public string FormattedPhoneNumber { get; set; }

        /// <summary>
        /// The place's phone number in international format.
        /// </summary>
        [DataMember(Name = "international_phone_number")]
        public string InternationalPhoneNumber { get; set; }

        /// <summary>
        /// A unique stable identifier denoting this place.
        /// </summary>
        [DataMember(Name = "id")]
        [Obsolete("See https://developers.google.com/places/web-service/search#deprecation")]
        public string Id { get; set; }

        /// <summary>
        /// The URL of a recommended icon which may be displayed to the user when indicating this result.
        /// </summary>
        [DataMember(Name = "icon")]
        public string Icon { get; set; }

        /// <summary>
        /// Human-readable name for the returned result
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Opening hours information
        /// </summary>
        [DataMember(Name = "opening_hours")]
        public PlaceDetailsOpeningHours OpeningHours { get; set; }

        /// <summary>
        /// Flag indicating whether the place has permanently shut down 
        /// </summary>
        [DataMember(Name = "permanently_closed")]
        public bool PermanentlyClosed { get; set; }

        /// <summary>
        /// Array of photo objects, each containing a reference to an image
        /// </summary>
        [DataMember(Name = "photos")]
        public List<PlacePhoto> Photos { get; set; }

        /// <summary>
        /// A unique stable identifier denoting this place.
        /// </summary>
        [DataMember(Name = "place_id")]
        public string PlaceId { get; set; }

        /// <summary>
        /// The scope of the Place Id
        /// </summary>
        [DataMember(Name = "scope")]
        public PlaceScopeEnum? Scope { get; set; }

        /// <summary>
        /// Alternative place IDs for the place
        /// </summary>
        [DataMember(Name = "alt_ids")]
        public List<PlaceAlternativeId> AlternativeIds { get; set; }

        /// <summary>
        /// The price level of the place
        /// </summary>
        [DataMember(Name = "price_level")]
        public PlacePriceLevelEnum PriceLevel { get; set; }

        /// <summary>
        /// The place's rating, from 1.0 to 5.0, based on aggregated user reviews.
        /// </summary>
        [DataMember(Name = "rating")]
        public double Rating { get; set; }

        /// <summary>
        /// A unique token that you can use to retrieve additional information about this place 
        /// </summary>
        [DataMember(Name = "reference")]
        [Obsolete]
        public string Reference { get; set; }

        /// <summary>
        /// Reviews
        /// </summary>
        [DataMember(Name = "reviews")]
        public List<PlaceReview> Reviews { get; set; }

        /// <summary>
        /// Array of feature types describing the given result
        /// </summary>
        [DataMember(Name = "types")]
        public List<PlaceResultTypeEnum> Types { get; set; }

        /// <summary>
        /// The URL of the official Google page for this place.
        /// </summary>
        [DataMember(Name = "url")]
        public string Url { get; set; }

        /// <summary>
        /// Total of user ratings
        /// </summary>
        [DataMember(Name = "user_ratings_total")]
        [GoogleAPIUndocumented(2016, 4, 5)]
        public int UserRatingsTotal { get; set; }

        /// <summary>
        /// The number of minutes this place’s current timezone is offset from UTC
        /// </summary>
        [DataMember(Name = "utc_offset")]
        public int UTCOffset { get; set; }

        /// <summary>
        /// Feature name of a nearby location.
        /// </summary>
        [DataMember(Name = "vicinity")]
        public string Vicinity { get; set; }

        /// <summary>
        /// The authoritative website for this place
        /// </summary>
        [DataMember(Name = "website")]
        public string Website { get; set; }

        /// <summary>
        /// Premium: Rating of aspects of the establishment
        /// </summary>
        [DataMember(Name = "aspects")]
        public List<PlacePremiumAspectRating> Aspects { get; set; }

        /// <summary>
        /// Premium: A rich and concise review curated by Google's editorial staff
        /// </summary>
        [DataMember(Name = "review_summary")]
        public string ReviewSummary { get; set; }

        /// <summary>
        /// Premium: Indicates that the place has been selected as a Zagat quality location.
        /// </summary>
        [DataMember(Name = "zagat_selected")]
        public string ZagatSelected { get; set; }

        #endregion


    }
}