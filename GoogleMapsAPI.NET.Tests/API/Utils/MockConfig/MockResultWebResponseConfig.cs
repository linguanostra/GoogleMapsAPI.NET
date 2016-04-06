using System.Net;
using System.Text;

namespace GoogleMapsAPI.NET.Tests.API.Utils.MockConfig
{
    /// <summary>
    /// Config for mocking result web response
    /// </summary>
    public class MockResultWebResponseConfig : MockWebResponseConfig
    {

        #region Properties

        /// <summary>
        /// Content
        /// </summary>
        public string Content { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="content">Content</param>
        /// <param name="statusCode">Status code</param>
        /// <param name="contentType">Content type</param>
        public MockResultWebResponseConfig(string content, HttpStatusCode statusCode = HttpStatusCode.OK,
            string contentType = "application/json") : base(statusCode, contentType)
        {
            Content = content;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get content bytes
        /// </summary>
        /// <returns>Result bytes</returns>
        public byte[] GetContentBytes()
        {

            return Content != null ? Encoding.UTF8.GetBytes(Content) : new byte[0];

        } 

        #endregion

    }

}