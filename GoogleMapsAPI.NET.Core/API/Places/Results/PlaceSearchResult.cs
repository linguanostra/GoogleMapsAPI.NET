using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleMapsAPI.NET.API.Places.Components;
using GoogleMapsAPI.NET.API.Places.Enums;

namespace GoogleMapsAPI.NET.API.Places.Results
{
    /// <summary>
    /// Place search result component
    /// </summary>
    [DataContract]
    public class PlaceSearchResult
    {

        #region Properties

        /// <summary>
        /// The URL of a recommended icon which may be displayed to the user when indicating this result.
        /// </summary>
        [DataMember(Name = "icon")]
        public string Icon { get; set; }

        /// <summary>
        /// A unique stable identifier denoting this place.
        /// </summary>
        [DataMember(Name = "id")]
        [Obsolete("See https://developers.google.com/places/web-service/search#deprecation")]
        public string Id { get; set; }

        /// <summary>
        /// A unique stable identifier denoting this place.
        /// </summary>
        [DataMember(Name = "place_id")]
        public string PlaceId { get; set; }

        /// <summary>
        /// Geometry information about the result
        /// </summary>
        [DataMember(Name = "geometry")]
        public PlaceGeometry Geometry { get; set; }

        /// <summary>
        /// Array of photo objects, each containing a reference to an image
        /// </summary>
        [DataMember(Name = "photos")]
        public List<PlacePhoto> Photos { get; set; }

        /// <summary>
        /// Human-readable name for the returned result
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Opening hours information
        /// </summary>
        [DataMember(Name = "opening_hours")]
        public PlaceOpeningHours OpeningHours { get; set; }

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
        public decimal Rating { get; set; }

        /// <summary>
        /// A unique token that you can use to retrieve additional information about this place 
        /// </summary>
        [DataMember(Name = "reference")]
        [Obsolete]
        public string Reference { get; set; }

        /// <summary>
        /// Array of feature types describing the given result
        /// </summary>
        [DataMember(Name = "types")]
        public List<PlaceResultTypeEnum> Types { get; set; }

        /// <summary>
        /// Feature name of a nearby location.
        /// </summary>
        [DataMember(Name = "vicinity")]
        public string Vicinity { get; set; }

        /// <summary>
        /// Human-readable address of this place
        /// </summary>
        [DataMember(Name = "formatted_address")]
        public string FormattedAddress { get; set; }

        /// <summary>
        /// Flag indicating whether the place has permanently shut down 
        /// </summary>
        [DataMember(Name = "permanently_closed")]
        public bool PermanentlyClosed { get; set; }

        #endregion

    }
}