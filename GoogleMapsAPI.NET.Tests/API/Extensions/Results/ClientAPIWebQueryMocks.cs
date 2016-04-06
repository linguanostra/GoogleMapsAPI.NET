using System.Net;
using GoogleMapsAPI.NET.Requests.Interfaces;

namespace GoogleMapsAPI.NET.Tests.API.Extensions.Results
{
    /// <summary>
    /// Client API web query mocks
    /// </summary>
    public class ClientAPIWebQueryMocks
    {

        #region Properties

        /// <summary>
        /// Mocked web request util
        /// </summary>
        public IWebRequestUtility WebRequestUtil { get; set; }

        /// <summary>
        /// Mocked web request
        /// </summary>
        public HttpWebRequest Request { get; set; }

        /// <summary>
        /// Mocked web response
        /// </summary>
        public HttpWebResponse Response { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="webRequestUtil">Mocked web request util</param>
        /// <param name="request">Mocked web request</param>
        /// <param name="response">Mocked web response</param>
        public ClientAPIWebQueryMocks(IWebRequestUtility webRequestUtil, HttpWebRequest request, HttpWebResponse response)
        {
            WebRequestUtil = webRequestUtil;
            Request = request;
            Response = response;            
        }

        #endregion

    }
}