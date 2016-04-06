using System.Net;
using GoogleMapsAPI.NET.API.Client;

namespace GoogleMapsAPI.NET.Requests.Interfaces
{
    /// <summary>
    /// Web request utility interface
    /// </summary>
    public interface IWebRequestUtility
    {

        #region Properties

        /// <summary>
        /// API client
        /// </summary>
        MapsAPIClient Client { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Create web request
        /// </summary>
        /// <param name="requestUri">Request Uri</param>
        /// <returns>Result request</returns>
        HttpWebRequest CreateWebRequest(string requestUri);

        /// <summary>
        /// Execute GET web request
        /// </summary>
        /// <param name="requestUri">Request Uri</param>
        /// <param name="config">Config</param>
        /// <returns>Response result</returns>
        HttpWebResponse Get(string requestUri, RequestConfig config);

        /// <summary>
        /// Append credentials from client to given url
        /// </summary>
        /// <param name="url">Url</param>
        /// <returns>Result url</returns>
        string AppendCredentialsToUrl(string url);

        #endregion

    }
}