using System;
using System.Net;
using GoogleMapsAPI.NET.API.Common.Responses;
using GoogleMapsAPI.NET.API.Directions;
using GoogleMapsAPI.NET.API.DistanceMatrix;
using GoogleMapsAPI.NET.API.Elevation;
using GoogleMapsAPI.NET.API.Geocoding;
using GoogleMapsAPI.NET.API.Geometry;
using GoogleMapsAPI.NET.API.Places;
using GoogleMapsAPI.NET.API.Roads;
using GoogleMapsAPI.NET.API.StreetViewImage;
using GoogleMapsAPI.NET.API.TimeZone;
using GoogleMapsAPI.NET.Common;
using GoogleMapsAPI.NET.Requests;
using GoogleMapsAPI.NET.Requests.Interfaces;

namespace GoogleMapsAPI.NET.API.Client.Interfaces
{

    /// <summary>
    /// Google Maps API web services client interface
    /// </summary>
    public interface IMapsAPIClient : IDisposable
    {

        #region Properties

        #region Credentials

        /// <summary>
        /// API key
        /// </summary>
        string APIKey { get; }

        /// <summary>
        /// Client id
        /// </summary>
        string ClientId { get; }

        /// <summary>
        /// Client secret
        /// </summary>
        string ClientSecret { get; }

        /// <summary>
        /// Is using API key
        /// </summary>
        bool IsUsingAPIKey { get; }

        /// <summary>
        /// Is using enterprise credentials
        /// </summary>
        bool IsUsingEnterpriseCredentials { get; }

        #endregion

        #region API

        /// <summary>
        /// Directions API
        /// </summary>
        DirectionsAPI Directions { get; }

        /// <summary>
        /// Elevation API
        /// </summary>
        ElevationAPI Elevation { get; }

        /// <summary>
        /// Geocoding API
        /// </summary>
        GeocodingAPI Geocoding { get; }

        /// <summary>
        /// Geometry API
        /// </summary>
        GeometryAPI Geometry { get; }

        /// <summary>
        /// Street view image API
        /// </summary>
        StreetViewImageAPI StreetViewImage { get; }

        /// <summary>
        /// TimeZone API
        /// </summary>
        TimeZoneAPI TimeZone { get; }

        /// <summary>
        /// Roads API
        /// </summary>
        RoadsAPI Roads { get; }

        /// <summary>
        /// Distance matrix API
        /// </summary>
        DistanceMatrixAPI DistanceMatrix { get; }

        /// <summary>
        /// Places API
        /// </summary>
        PlacesAPI Places { get; }

        #endregion

        #region Utils

        /// <summary>
        /// Web request utility
        /// </summary>
        IWebRequestUtility WebRequestUtility { get; }

        #endregion

        #endregion

        #region Methods

        /// <summary>
        /// Performs HTTP GET request with credentials, returning the body as text
        /// </summary>
        /// <param name="url">Url</param>
        /// <param name="queryParams">Query params</param>
        /// <param name="extractBody">Extract body</param>
        /// <param name="firstRequestTime">First request time</param>
        /// <param name="retryCounter">Retry counter</param>
        /// <param name="baseUrl">Base url</param>
        /// <param name="acceptsClientId">Accepts client Id</param>        
        /// <param name="requestConfigOverride">Request config override</param>
        /// <param name="useAuthedUrl">Use authenticated url</param>
        /// <param name="urlSuffix">Url suffix to append</param>
        /// <returns>Response body</returns>
        dynamic Get(string url, QueryParams queryParams, Func<HttpWebResponse, dynamic> extractBody = null, DateTime? firstRequestTime = default(DateTime?), int retryCounter = 0, string baseUrl = "https://maps.googleapis.com", bool acceptsClientId = true, RequestConfig requestConfigOverride = null, bool useAuthedUrl = true, string urlSuffix = null);

        /// <summary>
        /// Performs HTTP GET request with credentials, returning the body as bytes
        /// </summary>
        /// <param name="url">Url</param>
        /// <param name="queryParams">Query params</param>
        /// <param name="extractBody">Extract body</param>
        /// <param name="firstRequestTime">First request time</param>
        /// <param name="retryCounter">Retry counter</param>
        /// <param name="baseUrl">Base url</param>
        /// <param name="acceptsClientId">Accepts client Id</param>        
        /// <param name="requestConfigOverride">Request config override</param>
        /// <param name="useAuthedUrl">Use authenticated url</param>
        /// <param name="urlSuffix">Url suffix to append</param>
        /// <returns>Response body</returns>
        byte[] GetBinary(string url, QueryParams queryParams, Func<HttpWebResponse, dynamic> extractBody = null, DateTime? firstRequestTime = default(DateTime?), int retryCounter = 0, string baseUrl = "https://maps.googleapis.com", bool acceptsClientId = true, RequestConfig requestConfigOverride = null, bool useAuthedUrl = true, string urlSuffix = null);

        /// <summary>
        /// Performs HTTP GET request with credentials, returning the body as text for API
        /// </summary>
        /// <typeparam name="TResponse">Response type</typeparam>
        /// <param name="url">Url</param>
        /// <param name="queryParams">Query params</param>
        /// <param name="extractBody">Extract body handler</param>
        /// <param name="firstRequestTime">First request time</param>
        /// <param name="retryCounter">Retry counter</param>
        /// <param name="baseUrl">Base url</param>
        /// <param name="acceptsClientId">Accepts client Id</param>        
        /// <param name="requestConfigOverride">Request config override</param>
        /// <param name="useAuthedUrl">Use authenticated url</param>
        /// <param name="urlSuffix">Url suffix to append</param>
        /// <returns>Response body</returns>
        TResponse APIGet<TResponse>(string url, QueryParams queryParams,
            Func<HttpWebResponse, TResponse> extractBody = null,
            DateTime? firstRequestTime = null, int retryCounter = 0, string baseUrl = Globals.DefaultBaseUrl,
            bool acceptsClientId = true,
            RequestConfig requestConfigOverride = null, bool useAuthedUrl = true, string urlSuffix = null)
            where TResponse : APIResponse;

        /// <summary>
        /// URL encodes the parameters
        /// </summary>
        /// <param name="queryParams">Parameters</param>
        /// <returns>URL encoded result</returns>
        string UrlEncodeParams(QueryParams queryParams);

        /// <summary>
        /// Returns a base64-encoded HMAC-SHA1 signature of a given string.
        /// </summary>
        /// <param name="key">The key used for the signature, base64 encoded.</param>
        /// <param name="payload">The payload to sign.</param>
        /// <returns>Result signature</returns>
        string SignHMAC(string key, string payload);

        /// <summary>
        /// Deserialize result
        /// </summary>
        /// <typeparam name="TResponse">Response type</typeparam>
        /// <param name="responseData">Response data</param>
        /// <returns>Deserialized result</returns>
        TResponse DeserializeResponse<TResponse>(byte[] responseData)
            where TResponse : APIResponse;

        /// <summary>
        /// Deserialize result
        /// </summary>
        /// <typeparam name="TResponse">Response type</typeparam>
        /// <param name="responseContent">Result content</param>
        /// <returns>Deserialized result</returns>
        TResponse DeserializeResponse<TResponse>(string responseContent)
            where TResponse : APIResponse;

        #endregion

    }
}