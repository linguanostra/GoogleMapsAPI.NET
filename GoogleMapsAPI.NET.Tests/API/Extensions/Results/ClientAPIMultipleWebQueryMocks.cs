using System.Collections.Generic;
using System.Net;
using GoogleMapsAPI.NET.Requests.Interfaces;

namespace GoogleMapsAPI.NET.Tests.API.Extensions.Results
{
    /// <summary>
    /// Client API multiple web query mocks
    /// </summary>
    public class ClientAPIMultipleWebQueryMocks
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
        /// Mocked web responses
        /// </summary>
        public IList<HttpWebResponse> Responses { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="webRequestUtil">Mocked web request util</param>
        /// <param name="request">Mocked web request</param>
        /// <param name="responses">Mocked web response</param>
        public ClientAPIMultipleWebQueryMocks(IWebRequestUtility webRequestUtil, HttpWebRequest request, IList<HttpWebResponse> responses)
        {
            WebRequestUtil = webRequestUtil;
            Request = request;
            Responses = responses;
        }

        #endregion

    }
}