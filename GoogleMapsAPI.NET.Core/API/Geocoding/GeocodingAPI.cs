using GoogleMapsAPI.NET.API.Client;
using GoogleMapsAPI.NET.API.Common;
using GoogleMapsAPI.NET.API.Common.Components;
using GoogleMapsAPI.NET.API.Common.Components.Locations;
using GoogleMapsAPI.NET.API.Geocoding.Enums;
using GoogleMapsAPI.NET.API.Geocoding.Responses;
using GoogleMapsAPI.NET.Requests;
using GoogleMapsAPI.NET.Utils;

namespace GoogleMapsAPI.NET.API.Geocoding
{

    /// <summary>
    /// Geocoding API
    /// </summary>
    public class GeocodingAPI : MapsAPI
    {

        #region Constructors

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="client">API client</param>
        public GeocodingAPI(MapsAPIClient client) : base(client)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Geocoding is the process of converting addresses
        /// (like "1600 Amphitheatre Parkway, Mountain View, CA") into geographic
        /// coordinates(like latitude 37.423021 and longitude -122.083739), which you
        /// can use to place markers or position the map.
        /// </summary>
        /// <param name="address">
        /// The address to geocode.
        /// </param>
        /// <param name="components">
        /// A component filter for which you wish to obtain a
        /// geocode, for example: {"administrative_area": "TX","country": "US"}
        /// </param>
        /// <param name="bounds">
        /// The bounding box of the viewport within which to bias geocode
        /// results more prominently.
        /// </param>
        /// <param name="region">
        /// The region code, specified as a ccTLD ("top-level domain") two-character value.
        /// </param>
        /// <param name="language">
        /// The language in which to return results.
        /// </param>        
        /// <returns>Geocoding results</returns>
        public GeocodeResponse Geocode(string address = null, ComponentsFilter components = null, 
            ViewportBoundingBox bounds = null, string region = null, string language = null)
        {

            // Assign query params
            var queryParams = new QueryParams();

            // Address
            if (address != null) queryParams["address"] = address;

            // Components
            if (components != null) queryParams["components"] = Converter.Components(components);

            // Bounds
            if (bounds != null) queryParams["bounds"] = Converter.Bounds(bounds);

            // Regions
            if (region != null) queryParams["region"] = region;

            // Language
            if (language != null) queryParams["language"] = language;

            // Get API response result
            var response = Client.APIGet<GeocodeResponse>("/maps/api/geocode/json", queryParams);

            // Return it
            return response;

        }

        /// <summary>
        /// Reverse geocoding is the process of converting geographic coordinates into a
        /// human-readable address.
        /// </summary>
        /// <param name="latitude">The latitude for which you wish to obtain the closest, human-readable address.</param>
        /// <param name="longitude">The longitude for which you wish to obtain the closest, human-readable address.</param>
        /// <param name="language">The language in which to return results.</param>
        /// <param name="addressType">One or more address types to restrict results to.</param>
        /// <param name="locationType">One or more location types to restrict results to.</param>
        /// <returns>Reverse geocoding results</returns>
        public ReverseGeocodeResultResponse ReverseGeocode(double latitude, double longitude, string language = null,
            AddressTypeEnum? addressType = null, GeometryLocationType? locationType = null)
        {

            return ReverseGeocode(new GeoCoordinatesLocation(latitude, longitude), language, addressType, locationType);

        }

        /// <summary>
        /// Reverse geocoding is the process of converting geographic coordinates into a
        /// human-readable address.
        /// </summary>
        /// <param name="location">The latitude/longitude for which you wish to obtain the closest, human-readable address.</param>
        /// <param name="language">The language in which to return results.</param>
        /// <param name="addressType">One or more address types to restrict results to.</param>
        /// <param name="locationType">One or more location types to restrict results to.</param>
        /// <returns>Reverse geocoding results</returns>
        public ReverseGeocodeResultResponse ReverseGeocode(GeoCoordinatesLocation location, string language = null,
            AddressTypeEnum? addressType = null, GeometryLocationType? locationType = null)
        {

            // Assign query params
            var queryParams = new QueryParams()
            {
                ["latlng"] = Converter.Location(location)
            };

            if (language != null) queryParams["language"] = language;
            if (addressType != null) queryParams["result_type"] = Converter.EnumFlagsList(addressType.Value);
            if (locationType != null) queryParams["location_type"] = Converter.EnumFlagsList(locationType.Value);

            // Get API response result
            var response = Client.APIGet<ReverseGeocodeResultResponse>("/maps/api/geocode/json", queryParams);

            // Return it
            return response;

        }

        /// <summary>
        /// Reverse geocoding is the process of converting geographic coordinates into a
        /// human-readable address.
        /// </summary>
        /// <param name="location">The place for which you wish to obtain the closest, human-readable address.</param>
        /// <param name="language">The language in which to return results.</param>
        /// <param name="addressType">One or more address types to restrict results to.</param>
        /// <param name="locationType">One or more location types to restrict results to.</param>
        /// <returns>Reverse geocoding results</returns>
        public ReverseGeocodeResultResponse ReverseGeocode(PlaceLocation location, string language = null,
            AddressTypeEnum? addressType = null, GeometryLocationType? locationType = null)
        {

            // Assign query params
            var queryParams = new QueryParams()
            {
                ["latlng"] = Converter.Location(location)
            };

            if (language != null) queryParams["language"] = language;
            if (addressType != null) queryParams["result_type"] = Converter.EnumFlagsList(addressType.Value);
            if (locationType != null) queryParams["location_type"] = Converter.EnumFlagsList(locationType.Value);

            // Get API response result
            var response = Client.APIGet<ReverseGeocodeResultResponse>("/maps/api/geocode/json", queryParams);

            // Return it
            return response;

        }

        #endregion

    }
}