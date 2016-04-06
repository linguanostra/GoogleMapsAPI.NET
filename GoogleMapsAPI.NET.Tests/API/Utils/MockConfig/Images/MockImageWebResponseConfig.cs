using System.Net;

namespace GoogleMapsAPI.NET.Tests.API.Utils.MockConfig.Images
{
    /// <summary>
    /// Config for mocking image web response
    /// </summary>
    public abstract class MockImageWebResponseConfig : MockWebResponseConfig
    {

        #region Constructors

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="statusCode">Status code</param>
        /// <param name="contentType">Content type</param>
        protected MockImageWebResponseConfig(HttpStatusCode statusCode = HttpStatusCode.OK, string contentType = "image/jpeg") 
            : base(statusCode, contentType)
        {
        }

        #endregion

        #region Abstract methods

        /// <summary>
        /// Get image bytes
        /// </summary>
        /// <returns>Result image bytes</returns>
        public abstract byte[] GetImageBytes();

        #endregion

    }

}