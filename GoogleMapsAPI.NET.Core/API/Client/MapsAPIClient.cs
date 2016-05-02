using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using GoogleMapsAPI.NET.API.Client.Interfaces;
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
using GoogleMapsAPI.NET.Exceptions;
using GoogleMapsAPI.NET.Requests;
using GoogleMapsAPI.NET.Requests.Helpers;
using GoogleMapsAPI.NET.Requests.Interfaces;
using GoogleMapsAPI.NET.Utils;
using GoogleMapsAPI.NET.Web.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TimeoutException = System.TimeoutException;

namespace GoogleMapsAPI.NET.API.Client
{

    /// <summary>
    /// Google Maps API web services client
    /// </summary>
    public class MapsAPIClient : IMapsAPIClient
    {

        #region Properties

        #region Data

        /// <summary>
        /// Client config
        /// </summary>
        public MapsAPIClientConfig ClientConfig { get; }

        #endregion

        #region Credentials

        /// <summary>
        /// API key
        /// </summary>
        public string APIKey { get; }

        /// <summary>
        /// Client id
        /// </summary>
        public string ClientId { get; }

        /// <summary>
        /// Client secret
        /// </summary>
        public string ClientSecret { get; }

        /// <summary>
        /// Is using API key
        /// </summary>
        public bool IsUsingAPIKey => APIKey != null;

        /// <summary>
        /// Is using enterprise credentials
        /// </summary>
        public bool IsUsingEnterpriseCredentials => ClientId != null;

        #endregion

        #region API

        /// <summary>
        /// Geocoding API
        /// </summary>
        private GeocodingAPI _geocoding;

        /// <summary>
        /// Geocoding API
        /// </summary>
        public GeocodingAPI Geocoding => _geocoding ?? (_geocoding = new GeocodingAPI(this));

        /// <summary>
        /// Directions API
        /// </summary>
        private DirectionsAPI _directions;

        /// <summary>
        /// Directions API
        /// </summary>
        public DirectionsAPI Directions => _directions ?? (_directions = new DirectionsAPI(this));

        /// <summary>
        /// Elevation API
        /// </summary>
        private ElevationAPI _elevation;

        /// <summary>
        /// Elevation API
        /// </summary>
        public ElevationAPI Elevation => _elevation ?? (_elevation = new ElevationAPI(this));

        /// <summary>
        /// Geometry API
        /// </summary>
        private GeometryAPI _geometry;

        /// <summary>
        /// Geometry API
        /// </summary>
        public GeometryAPI Geometry => _geometry ?? (_geometry = new GeometryAPI(this));

        /// <summary>
        /// Street view image API
        /// </summary>
        private StreetViewImageAPI _streetViewImage;

        /// <summary>
        /// Street view image API
        /// </summary>
        public StreetViewImageAPI StreetViewImage => _streetViewImage ?? (_streetViewImage = new StreetViewImageAPI(this));

        /// <summary>
        /// TimeZone API
        /// </summary>
        private TimeZoneAPI _timeZone;

        /// <summary>
        /// TimeZone API
        /// </summary>
        public TimeZoneAPI TimeZone => _timeZone ?? (_timeZone = new TimeZoneAPI(this));
        
        /// <summary>
        /// Roads API
        /// </summary>
        private RoadsAPI _roads;

        /// <summary>
        /// Roads API
        /// </summary>
        public RoadsAPI Roads => _roads ?? (_roads = new RoadsAPI(this));
        
        /// <summary>
        /// Distance matrix API
        /// </summary>
        private DistanceMatrixAPI _distanceMatrix;

        /// <summary>
        /// Distance matrix API
        /// </summary>
        public DistanceMatrixAPI DistanceMatrix => _distanceMatrix ?? (_distanceMatrix = new DistanceMatrixAPI(this));
        
        /// <summary>
        /// Places API
        /// </summary>
        private PlacesAPI _places;

        /// <summary>
        /// Places API
        /// </summary>
        public PlacesAPI Places => _places ?? (_places = new PlacesAPI(this));

        #endregion

        #region Utils

        /// <summary>
        /// Web request utility
        /// </summary>
        private IWebRequestUtility _webRequestUtility;

        /// <summary>
        /// Web request utility
        /// </summary>
        public virtual IWebRequestUtility WebRequestUtility => _webRequestUtility ?? (_webRequestUtility = new WebRequestUtility(this));

        #endregion

        #region Protected

        /// <summary>
        /// Sent times
        /// </summary>
        protected List<DateTime> SentTimes { get; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new instance (with default configuration)
        /// </summary>
        /// <param name="apiKey">API key</param>
        public MapsAPIClient(string apiKey) 
            : this(apiKey, MapsAPIClientConfig.Default())
        {
        }

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="apiKey">API key</param>
        /// <param name="clientConfig">Client config</param>
        public MapsAPIClient(string apiKey, MapsAPIClientConfig clientConfig)
        {

            // Check API key
            if (apiKey == null)
            {
                // Must provide API key or enterprise credentials when creating client.
                throw new APICredentialsNotSpecifiedException();
            }

            // Validate API key
            if (apiKey != null && !apiKey.StartsWith("AIza"))
            {
                // Invalid API key provided
                throw new APIKeyInvalidException();
            }

            // Assign API key to instance
            APIKey = apiKey;

            // Init sent times
            SentTimes = new List<DateTime>();

            // Assign and initialize config
            ClientConfig = clientConfig;
            ClientConfig.Init();

        }

        /// <summary>
        /// Create a new instance (with default configuration)
        /// </summary>
        /// <param name="clientId">Client Id</param>
        /// <param name="clientSecret">Client secret</param>
        public MapsAPIClient(string clientId, string clientSecret) 
            : this(clientId, clientSecret, MapsAPIClientConfig.Default())
        {
        }

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="clientId">Client Id</param>
        /// <param name="clientSecret">Client secret</param>
        /// <param name="clientConfig">Client config</param>
        public MapsAPIClient(string clientId, string clientSecret, MapsAPIClientConfig clientConfig)
        {

            // Check enterprise credentials
            if (clientId == null || clientSecret == null)
            {
                // Must provide API key or enterprise credentials when creating client.
                throw new APICredentialsNotSpecifiedException();
            }

            // Assign enterprise credentials to instance
            ClientId = clientId;
            ClientSecret = clientSecret;

            // Init sent times
            SentTimes = new List<DateTime>();

            // Assign and initialize config
            ClientConfig = clientConfig;
            ClientConfig.Init();

        }
        
        #endregion

        #region Methods

        /// <summary>
        /// Deserialize result
        /// </summary>
        /// <typeparam name="TResult">Result type</typeparam>
        /// <param name="data">Data</param>
        /// <returns>Deserialized result</returns>
        public TResult Deserialize<TResult>(byte[] data)
        {

            return Deserialize<TResult>(Encoding.UTF8.GetString(data));

        }

        /// <summary>
        /// Deserialize result
        /// </summary>
        /// <typeparam name="TResult">Result type</typeparam>
        /// <param name="data">Result content</param>
        /// <returns>Deserialized result</returns>
        public TResult Deserialize<TResult>(string data)
        {

            // Deserialize object
            return JsonConvert.DeserializeObject<TResult>(data, 
                new StringEnumConverter());

        }

        /// <summary>
        /// Deserialize result
        /// </summary>
        /// <typeparam name="TResponse">Response type</typeparam>
        /// <param name="responseData">Response data</param>
        /// <returns>Deserialized result</returns>
        public TResponse DeserializeResponse<TResponse>(byte[] responseData)
            where TResponse : APIResponse
        {

            return DeserializeResponse<TResponse>(Encoding.UTF8.GetString(responseData));

        }

        /// <summary>
        /// Deserialize result
        /// </summary>
        /// <typeparam name="TResponse">Response type</typeparam>
        /// <param name="responseContent">Result content</param>
        /// <returns>Deserialized result</returns>
        public TResponse DeserializeResponse<TResponse>(string responseContent)
            where TResponse : APIResponse
        {

            // Deserialize response object
            var response = JsonConvert.DeserializeObject<TResponse>(responseContent,
                new StringEnumConverter());

            // Assign content
            response.SetContent(responseContent);

            // Return it
            return response;

        }

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
        public byte[] GetBinary(string url, QueryParams queryParams, Func<HttpWebResponse, dynamic> extractBody = null, 
            DateTime ? firstRequestTime = null, int retryCounter = 0, string baseUrl = Globals.DefaultBaseUrl, 
            bool acceptsClientId = true, RequestConfig requestConfigOverride = null, bool useAuthedUrl = true, string urlSuffix = null)
        {

            // Get content bytes
            var contentBytes = Get(url, queryParams, extractBody ?? GetBodyBytes, firstRequestTime, retryCounter, 
                baseUrl, acceptsClientId, requestConfigOverride, useAuthedUrl);

            // Return it
            return contentBytes;

        }

        /// <summary>
        /// Performs HTTP GET request with credentials, returning the body as text for API
        /// </summary>
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
        public TResponse APIGet<TResponse>(string url, QueryParams queryParams, Func<HttpWebResponse, TResponse> extractBody = null,
            DateTime? firstRequestTime = null, int retryCounter = 0, string baseUrl = Globals.DefaultBaseUrl, bool acceptsClientId = true,
            RequestConfig requestConfigOverride = null, bool useAuthedUrl = true, string urlSuffix = null)
            where TResponse : APIResponse
        {

            // Set dynamic response extractor
            var dynamicResponseBodyExtractor = new Func<HttpWebResponse, dynamic>(resp =>
            {

                // Call body extraction handler
                var responseBody = extractBody != null ? extractBody(resp) : ExtractAPIResponse<TResponse>(resp);
                
                // Return it
                return responseBody;

            });

            // Get response
            var response = Get(url, queryParams, dynamicResponseBodyExtractor, firstRequestTime, retryCounter, baseUrl,
                acceptsClientId, requestConfigOverride, useAuthedUrl, urlSuffix);

            // Return it
            return response;

        }

        /// <summary>
        /// Performs HTTP GET request with credentials, returning the body as text
        /// </summary>
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
        public dynamic Get(string url, QueryParams queryParams, Func<HttpWebResponse, dynamic> extractBody = null, DateTime? firstRequestTime = null,
            int retryCounter = 0, string baseUrl = Globals.DefaultBaseUrl, bool acceptsClientId = true,
            RequestConfig requestConfigOverride = null, bool useAuthedUrl = true, string urlSuffix = null)
        {

            // Adjust first request time
            if (!firstRequestTime.HasValue)
            {
                firstRequestTime = DateTime.Now;
            }

            // Adjust elapsed time
            var elapsed = DateTime.Now - firstRequestTime;
            if (elapsed > new TimeSpan(0,0, ClientConfig.RetryTimeout))
            {
                throw new TimeoutException();
            }

            // Retry counter
            if (retryCounter > 0)
            {

                // 0.5 * (1.5 ^ i) is an increased sleep time of 1.5x per iteration,
                // starting at 0.5s when retry_counter=0. The first retry will occur
                // at 1, so subtract that first.
                var delay_seconds = 0.5*Math.Pow(1.5, (retryCounter - 1));

                // Jitter this value by 50% and pause.
                Thread.Sleep((int) (delay_seconds*((new Random().Next(1)) + 0.5)));

            }

            // Get authenticated url
            var authedUrl = useAuthedUrl ? 
                GenerateAuthUrl(url, queryParams, acceptsClientId) 
                : $"{url}?{UrlEncodeParams(queryParams)}";

            // Get response
            HttpWebResponse resp;
            try
            {
                resp = WebRequestUtility.Get(baseUrl + authedUrl + urlSuffix, requestConfigOverride ?? ClientConfig.RequestConfig);
            }
            catch (Exception ex)
            {
                throw new TransportErrorException(ex);
            }

            // Check if response status code is a retriable one            
            if (Globals.RetriableStatuses.Contains((int)resp.StatusCode))
            {

                // Retry request.
                return Get(url, queryParams, extractBody, firstRequestTime, retryCounter + 1,
                    baseUrl, acceptsClientId);

            }

            // If response status code is not OK at this stage, throw an exception
            if (resp.StatusCode != HttpStatusCode.OK)
            {

                // Throw a Http response exception
                throw new HttpResponseException(resp);

            }

            // Check if the time of the nth previous query (where n is queries_per_second)
            // is under a second ago - if so, sleep for the difference.
            // TODO: Fix that, seems it won't always work
            if (SentTimes.Count == ClientConfig.QueriesPerSecond)
            {
                var elapsedSinceEarliest = DateTime.Now - SentTimes.ElementAt(0);
                if (elapsedSinceEarliest.Seconds < 1)
                {
                    Thread.Sleep(1000 - elapsedSinceEarliest.Milliseconds);
                }
            }

            // Error handling
            try
            {

                // Extract body
                var result = extractBody != null ? extractBody(resp) : GetBody(resp);

                // Add sent time
                SentTimes.Add(DateTime.Now);

                // Return result
                return result;

            }
            catch (RetriableRequestException)
            {

                // Retry request.
                return Get(url, queryParams, extractBody, firstRequestTime, retryCounter + 1,
                    baseUrl, acceptsClientId);

            }

        }

        /// <summary>
        /// Get response body
        /// </summary>
        /// <param name="resp">Response</param>
        /// <returns>Body</returns>
        private string GetBody(HttpWebResponse resp)
        {

            // Get response content
            return resp.GetResponseContent();

        }

        /// <summary>
        /// Get response body bytes
        /// </summary>
        /// <param name="resp">Response</param>
        /// <returns>Body</returns>
        private byte[] GetBodyBytes(HttpWebResponse resp)
        {

            return resp.GetResponseBytes();

        }

        /// <summary>
        /// Returns the path and query string portion of the request URL, first adding any 
        /// necessary parameters.
        /// </summary>
        /// <param name="path">The path portion of the URL</param>
        /// <param name="queryParams">URL parameters</param>
        /// <param name="acceptsClientId"></param>
        /// <returns>Result URL</returns>
        private string GenerateAuthUrl(string path, QueryParams queryParams, bool acceptsClientId)
        {

            // Deterministic ordering through sorting by key.
            // Useful for tests, and in the future, any caching.
            if (acceptsClientId && ClientId != null && ClientSecret != null)
            {

                queryParams["client"] = ClientId;
                path = $"{path}?{UrlEncodeParams(queryParams)}";
                var sig = SignHMAC(ClientSecret, path);
                return path + "&signature=" + sig;

            }

            if (APIKey != null)
            {

                queryParams["key"] = APIKey;
                if (path.EndsWith("&"))
                {
                    return path + UrlEncodeParams(queryParams);
                }
                return path + "?" + UrlEncodeParams(queryParams);

            }

            throw new ArgumentException("Must provide API key for this API. It does not accept enterprise credentials.");

        }

        /// <summary>
        /// Returns a base64-encoded HMAC-SHA1 signature of a given string.
        /// </summary>
        /// <param name="key">The key used for the signature, base64 encoded.</param>
        /// <param name="payload">The payload to sign.</param>
        /// <returns>Result signature</returns>
        public string SignHMAC(string key, string payload)
        {

            var decodedKey = Base64Utils.UrlSafeBase64Decode(key);
            var hmac = new HMACSHA1(Encoding.ASCII.GetBytes(decodedKey));
            var hash = hmac.ComputeHash(Encoding.ASCII.GetBytes(payload));
            return Base64Utils.UrlSafeBase64Encode(hash);

        }

        /// <summary>
        /// URL encodes the parameters
        /// </summary>
        /// <param name="queryParams">Parameters</param>
        /// <returns>URL encoded result</returns>
        public string UrlEncodeParams(QueryParams queryParams)
        {
            var array = (from key in queryParams.AllKeys
                from value in queryParams.GetValues(key)
                where !string.IsNullOrEmpty(value)
                select $"{HttpUtility.UrlEncode(key)}={HttpUtility.UrlEncode(value)}")
                .ToArray();
            
            return UnquoteUnreserved(string.Join("&", array));

        }

        /// <summary>
        /// Extract API response entity from web response
        /// </summary>
        /// <typeparam name="TResponse">Response type</typeparam>
        /// <returns></returns>
        protected TResponse ExtractAPIResponse<TResponse>(HttpWebResponse resp)
            where TResponse : APIResponse
        {

            // Get response content
            var content = resp.GetResponseContent();

            // Parse it
            var response = ParseResponseContent<TResponse>(content);

            // Check if valid
            if (response.IsValid)
            {

                // Is valid
                return response;

            }

            // Check if over query limit
            if (response.IsOverQueryLimit)
            {

                // Retriable exception
                throw new RetriableRequestException();

            }

            // API error
            if (response.HasErrorMessage) throw new APIErrorException(response.Status, response.ErrorMessage);
            throw new APIErrorException(response.Status);

        }

        /// <summary>
        /// Parse response using given content
        /// </summary>
        /// <typeparam name="TResponse">Response type</typeparam>
        /// <param name="content">Content</param>
        /// <returns>Result response</returns>
        protected TResponse ParseResponseContent<TResponse>(string content)
            where TResponse : APIResponse
        {

            // Deserialize response object
            var responseObject = JsonConvert.DeserializeObject<TResponse>(content, 
                new StringEnumConverter());

            // Set content
            responseObject.SetContent(content);

            // Return it
            return responseObject;

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Un-escape any percent-escape sequences in a URI that are unreserved characters. This leaves all reserved, 
        /// illegal and non-ASCII bytes encoded. Required because of the following:
        /// https://github.com/googlemaps/google-maps-services-python/issues/72
        /// </summary>
        /// <param name="uri">Uri</param>
        /// <returns>Result</returns>
        private static string UnquoteUnreserved(string uri)
        {

            // Validate uri
            if (uri == null) return string.Empty;

            // Split percent-escaped sequences
            var parts = uri.Split('%');

            // Loop parts
            var regexValue = new Regex(@"^([a-fA-F\d]{2})(.*)");

            for (var i = 1; i < parts.Length; i++)
            {

                var matchResults = regexValue.Match(parts[i]);
                if (matchResults.Success)
                {
                    var charValue = (char)Convert.ToInt32(matchResults.Groups[1].Value, 16);
                    if (Globals.UnreservedSet.Contains(charValue))
                    {
                        parts[i] = charValue + matchResults.Groups[2].Value;
                    }
                    else
                    {
                        parts[i] = '%' + matchResults.Groups[1].Value.ToUpperInvariant() + matchResults.Groups[2].Value;
                    }
                }
                else
                {
                    parts[i] = '%' + parts[i];
                }
            }

            return string.Join("", parts);

        }

        #endregion

        #region IDisposable members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {            
        }

        #endregion

    }
}