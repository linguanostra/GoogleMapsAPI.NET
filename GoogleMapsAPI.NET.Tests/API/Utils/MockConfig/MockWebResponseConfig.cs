using System.Net;

namespace GoogleMapsAPI.NET.Tests.API.Utils.MockConfig
{
    /// <summary>
    /// Config for mocking web response
    /// </summary>
    public class MockWebResponseConfig
    {

        #region Properties

        /// <summary>
        /// Status code
        /// </summary>
        public HttpStatusCode StatusCode { get; }

        /// <summary>
        /// Content type
        /// </summary>
        public string ContentType { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="statusCode">Status code</param>
        /// <param name="contentType">Content type</param>
        public MockWebResponseConfig(HttpStatusCode statusCode, string contentType)
        {
            StatusCode = statusCode;
            ContentType = contentType;
        }

        #endregion

    }
}