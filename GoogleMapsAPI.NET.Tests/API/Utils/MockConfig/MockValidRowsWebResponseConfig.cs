using System.Net;

namespace GoogleMapsAPI.NET.Tests.API.Utils.MockConfig
{
    /// <summary>
    /// Config for mocking valid rows web response
    /// </summary>
    public class MockValidRowsWebResponseConfig : MockResultWebResponseConfig
    {

        #region Constructors

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="statusCode">Status code</param>
        public MockValidRowsWebResponseConfig(HttpStatusCode statusCode = HttpStatusCode.OK)
            : base("{\"status\":\"OK\",\"rows\":[]}", statusCode)
        {
        }

        #endregion

    }
}