using System;
using System.Net;
using GoogleMapsAPI.NET.API.Client;
using GoogleMapsAPI.NET.Requests.Interfaces;

namespace GoogleMapsAPI.NET.Requests
{
    /// <summary>
    /// Web request utility
    /// </summary>
    public class WebRequestUtility : IWebRequestUtility
    {

        #region Properties

        /// <summary>
        /// API client
        /// </summary>
        public MapsAPIClient Client { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="client">API client</param>
        public WebRequestUtility(MapsAPIClient client)
        {
            Client = client;
        }

        #endregion

        #region Virtual methods

        /// <summary>
        /// Create web request
        /// </summary>
        /// <param name="requestUri">Request Uri</param>
        /// <returns>Result request</returns>
        public virtual HttpWebRequest CreateWebRequest(string requestUri)
        {
            
            return (HttpWebRequest)WebRequest.Create(requestUri);

        }

        /// <summary>
        /// Execute GET web request
        /// </summary>
        /// <param name="requestUri">Request Uri</param>
        /// <param name="config">Config</param>
        /// <returns>Response result</returns>
        public virtual HttpWebResponse Get(string requestUri, RequestConfig config)
        {

            // Create web request
            var webRequest = CreateWebRequest(requestUri);

            // Set method
            webRequest.Method = "GET";
            
            // Set (non restricted) headers
            webRequest.Headers = config.Headers.ToWebHeaderCollection(true);

            // Set User-Agent
            webRequest.UserAgent = config.Headers.UserAgent;

            // Set timeout, if required
            if (config.Timeout > 0)
            {
                webRequest.Timeout = config.Timeout;
            }

            // Get response
            var response = (HttpWebResponse)webRequest.GetResponse();

            // Return response
            return response;

        }

        /// <summary>
        /// Append credentials from client to given url
        /// </summary>
        /// <param name="url">Url</param>
        /// <returns>Result url</returns>
        public string AppendCredentialsToUrl(string url)
        {

            // Check credentials

            // API key
            if (Client.IsUsingAPIKey)
            {
                return $"{url}&key={Client.APIKey}";
            }

            // Enterprise credentials
            if (Client.IsUsingEnterpriseCredentials)
            {
                throw new NotImplementedException();
            }

            // Nothing to do
            return url;

        }

        #endregion

    }
}