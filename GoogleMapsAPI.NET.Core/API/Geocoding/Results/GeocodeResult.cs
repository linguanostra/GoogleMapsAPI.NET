using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleMapsAPI.NET.API.Geocoding.Components;

namespace GoogleMapsAPI.NET.API.Geocoding.Results
{
    /// <summary>
    /// Geocode API result
    /// </summary>
    [DataContract]
    public class GeocodeResult
    {

        #region Properties

        /// <summary>
        /// Types of the returned result
        /// </summary>
        [DataMember(Name = "types")]
        public List<string> Types { get; set; }

        /// <summary>
        /// Human-readable address of this location
        /// </summary>
        [DataMember(Name = "formatted_address")]
        public string FormattedAddress { get; set; }

        /// <summary>
        /// Unique identifier that can be used with other Google APIs
        /// </summary>
        [DataMember(Name = "place_id")]
        public string PlaceId { get; set; }

        /// <summary>
        /// Address components
        /// </summary>
        [DataMember(Name = "address_components")]
        public List<Address> AddressComponents { get; set; }

        /// <summary>
        /// Geometry component
        /// </summary>
        [DataMember(Name = "geometry")]
        public GeocodingGeometry Geometry { get; set; }

        #endregion

    }
}