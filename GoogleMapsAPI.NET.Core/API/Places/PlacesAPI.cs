using System;
using System.Collections.Generic;
using System.Linq;
using GoogleMapsAPI.NET.API.Client;
using GoogleMapsAPI.NET.API.Common;
using GoogleMapsAPI.NET.API.Common.Components.Locations.Interfaces;
using GoogleMapsAPI.NET.API.Places.Enums;
using GoogleMapsAPI.NET.API.Places.Responses;
using GoogleMapsAPI.NET.Extensions;
using GoogleMapsAPI.NET.Requests;
using GoogleMapsAPI.NET.Utils;

namespace GoogleMapsAPI.NET.API.Places
{

    /// <summary>
    /// Places API
    /// </summary>
    public class PlacesAPI : MapsAPI
    {

        #region Constructors

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="client">API client</param>
        public PlacesAPI(MapsAPIClient client) : base(client)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Lets you search for places within a specified area. 
        /// Google Maps APIs Premium Plan customers should not include a client or signature parameter with their requests.
        /// </summary>
        /// <param name="location">The latitude/longitude around which to retrieve place information</param>
        /// <param name="radius">the distance (in meters) within which to return place results. The maximum allowed
        /// radius is 50 000 meters.</param>
        /// <param name="keyword">A term to be matched against all content that Google has indexed for this place.</param>
        /// <param name="language">The language code, indicating in which language the results should be returned, if possible.</param>
        /// <param name="minprice">Restricts results to only those places within the specified range.</param>
        /// <param name="maxPrice">Restricts results to only those places within the specified range.</param>
        /// <param name="name">One or more terms to be matched against the names of places</param>
        /// <param name="openNow">Returns only those places that are open for business at the time the query is sent.</param>
        /// <param name="rankBy">The order in which results are listed</param>
        /// <param name="placeType">Restricts the results to places matching the specified type.</param>
        /// <param name="pageToken">Returns the next 20 results from a previously run search</param>
        /// <param name="zagatSelected">Restrict your search to locations that are Zagat selected businesses</param>
        /// <returns>Result</returns>
        public PlaceSearchResponse NearbySearch(IGeoCoordinatesLocation location, int? radius = null, string keyword = null, string language = null, 
            int? minprice = null, int? maxPrice = null, IEnumerable<string> name = null, bool? openNow = null, PlaceRankByEnum? rankBy = null, 
            PlaceSearchTypeEnum? placeType = null, string pageToken = null, bool? zagatSelected = null)
        {

            // Validations
            if (rankBy.HasValue && rankBy.Value == PlaceRankByEnum.Distance)
            {
                if (!(keyword != null || name != null || placeType != null))
                {
                    throw new ArgumentException(
                        "Either a keyword, name, or type arg is required when rankBy is set to Distance");
                }

                if (radius != null)
                {
                    throw new ArgumentException("Radius cannot be specified when rankBY is set to Distance");
                }
            }

            // Assign query params
            var queryParams = new QueryParams
            {
                ["location"] = Converter.Location(location)                
            };

            // Radius
            if (radius.HasValue) queryParams["radius"] = Converter.Number(radius.Value);

            // Keyword
            if (keyword != null) queryParams["keyword"] = keyword;

            // Language
            if (language != null) queryParams["language"] = language;

            // Min/Max price
            if (minprice.HasValue) queryParams["minprice"] = Converter.Number(minprice.Value);
            if (maxPrice.HasValue) queryParams["maxprice"] = Converter.Number(maxPrice.Value);

            // Name
            if (name != null) queryParams["name"] = Converter.JoinList(name);

            // Open now
            if (openNow.HasValue) queryParams["opennow"] = Converter.Value(openNow.Value);

            // Rank by
            if (rankBy.HasValue) queryParams["rankby"] = rankBy.Value.GetSerializationName();

            // Place type
            if (placeType.HasValue) queryParams["type"] = placeType.Value.GetSerializationName();

            // Page token
            if (pageToken != null) queryParams["pagetoken"] = pageToken;

            // Zatgat selected
            if (zagatSelected.HasValue) queryParams["zatgatselected"] = "";

            // Get API response result
            var response = Client.APIGet<PlaceSearchResponse>("/maps/api/place/nearbysearch/json", queryParams);

            // Return it
            return response;

        }

        /// <summary>
        /// Returns information about a set of places based on a string 
        /// </summary>
        /// <param name="query">The text string on which to search,</param>
        /// <param name="location">The latitude/longitude around which to retrieve place information</param>
        /// <param name="radius">the distance (in meters) within which to return place results. The maximum allowed
        /// radius is 50 000 meters.</param>
        /// <param name="language">The language code, indicating in which language the results should be returned, if possible.</param>
        /// <param name="minprice">Restricts results to only those places within the specified range.</param>
        /// <param name="maxPrice">Restricts results to only those places within the specified range.</param>
        /// <param name="openNow">Returns only those places that are open for business at the time the query is sent.</param>
        /// <param name="placeType">Restricts the results to places matching the specified type.</param>
        /// <param name="pageToken">Returns the next 20 results from a previously run search</param>
        /// <param name="zagatSelected">Restrict your search to locations that are Zagat selected businesses</param>
        /// <returns>Results</returns>
        public PlaceSearchResponse TextSearch(string query, IGeoCoordinatesLocation location = null, int? radius = null, string language = null, int? minprice = null, int? maxPrice = null, bool? openNow = null, 
            PlaceSearchTypeEnum? placeType = null, string pageToken = null, bool? zagatSelected = null)
        {

            // Assign query params
            var queryParams = new QueryParams
            {
                ["query"] = query
            };

            // Location
            if (location != null) queryParams["location"] = Converter.Location(location);

            // Radius
            if (radius.HasValue) queryParams["radius"] = Converter.Number(radius.Value);

            // Language
            if (language != null) queryParams["language"] = language;

            // Min/Max price
            if (minprice.HasValue) queryParams["minprice"] = Converter.Number(minprice.Value);
            if (maxPrice.HasValue) queryParams["maxprice"] = Converter.Number(maxPrice.Value);

            // Open now
            if (openNow.HasValue) queryParams["opennow"] = Converter.Value(openNow.Value);

            // Place type
            if (placeType.HasValue) queryParams["type"] = placeType.Value.GetSerializationName();

            // Page token
            if (pageToken != null) queryParams["pagetoken"] = pageToken;

            // Zatgat selected
            if (zagatSelected.HasValue) queryParams["zatgatselected"] = "";

            // Get API response result
            var response = Client.APIGet<PlaceSearchResponse>("/maps/api/place/textsearch/json", queryParams);

            // Return it
            return response;

        }

        /// <summary>
        /// Lets you search for places within a specified area. 
        /// Google Maps APIs Premium Plan customers should not include a client or signature parameter with their requests.
        /// </summary>
        /// <param name="location">The latitude/longitude around which to retrieve place information</param>
        /// <param name="radius">the distance (in meters) within which to return place results. The maximum allowed
        /// radius is 50 000 meters.</param>
        /// <param name="keyword">A term to be matched against all content that Google has indexed for this place.</param>
        /// <param name="language">The language code, indicating in which language the results should be returned, if possible.</param>
        /// <param name="minprice">Restricts results to only those places within the specified range.</param>
        /// <param name="maxPrice">Restricts results to only those places within the specified range.</param>
        /// <param name="name">One or more terms to be matched against the names of places</param>
        /// <param name="openNow">Returns only those places that are open for business at the time the query is sent.</param>
        /// <param name="placeType">Restricts the results to places matching the specified type.</param>
        /// <param name="zagatSelected">Restrict your search to locations that are Zagat selected businesses</param>
        /// <returns>Result</returns>
        public PlaceRadarSearchResponse RadarSearch(IGeoCoordinatesLocation location, int radius, string keyword = null, string language = null, int? minprice = null,
            int? maxPrice = null, IEnumerable<string> name = null, bool? openNow = null,
            PlaceSearchTypeEnum? placeType = null, bool? zagatSelected = null)
        {

            // Validations
            if (!(keyword != null || name != null || placeType != null))
            {
                throw new ArgumentException(
                    "Either a keyword, name, or type arg is required when rankBy is set to Distance");
            }

            // Assign query params
            var queryParams = new QueryParams
            {
                ["location"] = Converter.Location(location),
                ["radius"] = Converter.Number(radius)
            };

            // Keyword
            if (keyword != null) queryParams["keyword"] = keyword;

            // Language
            if (language != null) queryParams["language"] = language;

            // Min/Max price
            if (minprice.HasValue) queryParams["minprice"] = Converter.Number(minprice.Value);
            if (maxPrice.HasValue) queryParams["maxprice"] = Converter.Number(maxPrice.Value);

            // Name
            if (name != null) queryParams["name"] = Converter.JoinList(name);

            // Open now
            if (openNow.HasValue) queryParams["opennow"] = Converter.Value(openNow.Value);

            // Place type
            if (placeType.HasValue) queryParams["type"] = placeType.Value.GetSerializationName();

            // Zatgat selected
            if (zagatSelected.HasValue) queryParams["zatgatselected"] = "";

            // Get API response result
            var response = Client.APIGet<PlaceRadarSearchResponse>("/maps/api/place/radarsearch/json", queryParams);

            // Return it
            return response;

        }

        /// <summary>
        /// Get more comprehensive information about the indicated place such as its complete address, 
        /// phone number, user rating and reviews.
        /// </summary>
        /// <param name="place">An identifier that uniquely identifies a place</param>
        /// <param name="extensions">Response should include additional fields.</param>
        /// <param name="language">The language code, indicating in which language the results should be returned</param>
        /// <returns>Results</returns>
        public PlaceDetailsResponse GetPlaceDetails(IPlaceLocation place, PlaceDetailsExtensionEnum? extensions = null,
            string language = null)
        {

            return GetPlaceDetails(place.PlaceId, extensions, language);
            
        }

        /// <summary>
        /// Get more comprehensive information about the indicated place such as its complete address, 
        /// phone number, user rating and reviews.
        /// </summary>
        /// <param name="placeId">A textual identifier that uniquely identifies a place</param>
        /// <param name="extensions">Response should include additional fields.</param>
        /// <param name="language">The language code, indicating in which language the results should be returned</param>
        /// <returns>Results</returns>
        public PlaceDetailsResponse GetPlaceDetails(string placeId, PlaceDetailsExtensionEnum? extensions = null,
            string language = null)
        {

            // Assign query params
            var queryParams = new QueryParams
            {
                ["placeid"] = placeId
            };

            // Extensions
            if (extensions.HasValue) queryParams["extensions"] = Converter.EnumFlagsList(extensions.Value);

            // Language
            if (language != null) queryParams["language"] = language;

            // Get API response result
            var response = Client.APIGet<PlaceDetailsResponse>("/maps/api/place/details/json", queryParams);

            // Return it
            return response;

        }

        /// <summary>
        /// Get a place photo
        /// </summary>
        /// <param name="photoReference">Identifier that uniquely identifies a photo</param>
        /// <param name="maxWidth">Maximum desired width</param>
        /// <param name="maxHeight">Maximum desired height</param>
        /// <returns>Result</returns>
        public PlacePhotoResponse GetPlacePhoto(string photoReference, int? maxWidth = null, int? maxHeight = null)
        {

            // Assign query params
            var queryParams = new QueryParams
            {
                ["photoreference"] = photoReference,
            };

            // Max width/height
            if (!maxWidth.HasValue && !maxHeight.HasValue)
            {
                throw new ArgumentException("A maxWidth or maxHeight value is required");
            }

            if(maxWidth.HasValue) queryParams["maxwidth"] = Converter.Number(maxWidth.Value);
            if(maxHeight.HasValue) queryParams["maxheight"] = Converter.Number(maxHeight.Value);

            // Get response content
            var responseContent = Client.GetBinary("/maps/api/place/photo", queryParams);

            // Return response
            return new PlacePhotoResponse(responseContent);

        }

        /// <summary>
        /// Returns Place predictions given a textual search string and optional geographic bounds.
        /// </summary>
        /// <param name="input">The text string on which to search</param>
        /// <param name="offset">The position, in the input term, of the last character that 
        /// the service uses to match predictions.For example, if the input is 'Google' and 
        /// the offset is 3, the service will match on 'Goo'.</param>
        /// <param name="location">The latitude/longitude value for which you wish to obtain 
        /// the closest, human-readable address.</param>
        /// <param name="radius">The distance (in meters) within which to return place results.</param>
        /// <param name="language">The language code, indicating in which language the results should be returned, if possible</param>
        /// <param name="types">The types of place results to return</param>
        /// <param name="components">A grouping of places to which you would like to restrict your results.</param>        
        /// <returns>Result</returns>
        public PlaceAutocompleteResponse AutoComplete(string input, int? offset = null, IGeoCoordinatesLocation location = null,
            int? radius = null, string language = null, IEnumerable<string> types = null, 
            ComponentsFilter components = null)
        {

            // Assign query params
            var queryParams = new QueryParams
            {
                ["input"] = input
            };

            // Offset
            if (offset.HasValue) queryParams["offset"] = Converter.Number(offset.Value);

            // Location
            if (location != null) queryParams["location"] = Converter.Location(location);

            // Radius
            if (radius.HasValue) queryParams["radius"] = Converter.Number(radius.Value);

            // Language
            if (language != null) queryParams["language"] = language;

            // Types
            if (types != null) queryParams["types"] = Converter.JoinList(types);

            // Components
            if (components != null) queryParams["components"] = Converter.Components(components);

            // Get API response result
            var response = Client.APIGet<PlaceAutocompleteResponse>("/maps/api/place/autocomplete/json", queryParams);

            // Return it
            return response;

        }

        /// <summary>
        /// Returns Place predictions given a textual search query, such as 
        /// "pizza near New York", and optional geographic bounds.
        /// </summary>
        /// <param name="input">The text query on which to search</param>
        /// <param name="offset">The position, in the input term, of the last character that 
        /// the service uses to match predictions.For example, if the input is 'Google' and 
        /// the offset is 3, the service will match on 'Goo'.</param>
        /// <param name="location">The latitude/longitude value for which you wish to obtain 
        /// the closest, human-readable address.</param>
        /// <param name="radius">The distance (in meters) within which to return place results.</param>
        /// <param name="language">The language code, indicating in which language the results should be returned, if possible</param>
        /// <returns>Result</returns>
        public PlaceQueryAutoCompleteResponse QueryAutoComplete(string input, int? offset = null, IGeoCoordinatesLocation location = null,
            int? radius = null, string language = null)
        {

            // Assign query params
            var queryParams = new QueryParams
            {
                ["input"] = input
            };

            // Offset
            if (offset.HasValue) queryParams["offset"] = Converter.Number(offset.Value);

            // Location
            if (location != null) queryParams["location"] = Converter.Location(location);

            // Radius
            if (radius.HasValue) queryParams["radius"] = Converter.Number(radius.Value);

            // Language
            if (language != null) queryParams["language"] = language;

            // Get API response result
            var response = Client.APIGet<PlaceQueryAutoCompleteResponse>("/maps/api/place/queryautocomplete/json", queryParams);

            // Return it
            return response;

        }

        #endregion

    }
}