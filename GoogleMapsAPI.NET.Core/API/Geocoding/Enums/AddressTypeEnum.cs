using System;
using System.Runtime.Serialization;

namespace GoogleMapsAPI.NET.API.Geocoding.Enums
{

    /// <summary>
    /// Address type enum
    /// </summary>
    [Flags]
    public enum AddressTypeEnum
    {
        /// <summary>
        /// Indicates a precise street address.
        /// </summary>
        [EnumMember(Value = "street_address")]
        StreetAddress = 1,
        /// <summary>
        /// Indicates a named route (such as "US 101").
        /// </summary>
        [EnumMember(Value = "route")]
        Route = 2,
        /// <summary>
        /// Indicates a major intersection, usually of two major roads.
        /// </summary>
        [EnumMember(Value = "intersection")]
        Intersection = 4,
        /// <summary>
        /// Indicates a political entity. Usually, this type indicates a polygon of some civil administration.
        /// </summary>
        [EnumMember(Value = "political")]
        Political = 8,
        /// <summary>
        /// Indicates the national political entity, and is typically the highest order type returned by the Geocoder.
        /// </summary>
        [EnumMember(Value = "country")]
        Country = 16,
        /// <summary>
        /// Indicates a first-order civil entity below the country level. Within the United States, these administrative levels are states. Not all nations exhibit these administrative levels.
        /// </summary>
        [EnumMember(Value = "administrative_area_level_1")]
        AdministrativeAreaLevel1 = 32,
        /// <summary>
        /// Indicates a second-order civil entity below the country level. Within the United States, these administrative levels are counties. Not all nations exhibit these administrative levels.
        /// </summary>
        [EnumMember(Value = "administrative_area_level_2")]
        AdministrativeAreaLevel2 = 64,
        /// <summary>
        /// Indicates a third-order civil entity below the country level. This type indicates a minor civil division. Not all nations exhibit these administrative levels.
        /// </summary>
        [EnumMember(Value = "administrative_area_level_3")]
        AdministrativeAreaLevel3 = 128,
        /// <summary>
        /// Indicates a fourth-order civil entity below the country level. This type indicates a minor civil division. Not all nations exhibit these administrative levels.
        /// </summary>
        [EnumMember(Value = "administrative_area_level_4")]
        AdministrativeAreaLevel4 = 256,
        /// <summary>
        /// Indicates a fifth-order civil entity below the country level. This type indicates a minor civil division. Not all nations exhibit these administrative levels.
        /// </summary>
        [EnumMember(Value = "administrative_area_level_5")]
        AdministrativeAreaLevel5 = 512,
        /// <summary>
        /// Indicates a commonly-used alternative name for the entity.
        /// </summary>
        [EnumMember(Value = "colloquial_area")]
        ColloquialArea = 1024,
        /// <summary>
        /// Indicates an incorporated city or town political entity.
        /// </summary>
        [EnumMember(Value = "locality")]
        Locality = 2048,
        /// <summary>
        /// Indicates a specific type of Japanese locality, to facilitate distinction between multiple locality components within a Japanese address.
        /// </summary>
        [EnumMember(Value = "ward")]
        Ward = 4096,
        /// <summary>
        /// Indicates a first-order civil entity below a locality. For some locations may receive one of the additional types: sublocality_level_1 to sublocality_level_5. Each sublocality level is a civil entity. Larger numbers indicate a smaller geographic area.
        /// </summary>
        [EnumMember(Value = "sublocality")]
        SubLocality = 8192,
        /// <summary>
        /// Indicates a named neighborhood
        /// </summary>
        [EnumMember(Value = "neighborhood")]
        Neighborhood = 16384,
        /// <summary>
        /// Indicates a named location, usually a building or collection of buildings with a common name
        /// </summary>
        [EnumMember(Value = "premise")]
        Premise = 32768,
        /// <summary>
        /// Indicates a first-order entity below a named location, usually a singular building within a collection of buildings with a common name
        /// </summary>
        [EnumMember(Value = "subpremise")]
        SubPremise = 65536,
        /// <summary>
        /// Indicates a postal code as used to address postal mail within the country.
        /// </summary>
        [EnumMember(Value = "postal_code")]
        PostalCode = 131072,
        /// <summary>
        /// Indicates a prominent natural feature.
        /// </summary>
        [EnumMember(Value = "natural_feature")]
        NaturalFeature = 262144,
        /// <summary>
        /// Indicates an airport.
        /// </summary>
        [EnumMember(Value = "airport")]
        Airport = 524288,
        /// <summary>
        /// Indicates a named park.
        /// </summary>
        [EnumMember(Value = "park")]
        Park = 1048576,
        /// <summary>
        /// Indicates a named point of interest. Typically, these "POI"s are prominent local entities that don't easily fit in another category, such as "Empire State Building" or "Statue of Liberty."
        /// </summary>
        [EnumMember(Value = "point_of_interest")]
        PointOfInterest = 2097152
    }
}