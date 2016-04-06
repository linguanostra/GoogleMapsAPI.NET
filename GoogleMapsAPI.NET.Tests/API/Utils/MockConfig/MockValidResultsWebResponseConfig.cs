using System.Net;

namespace GoogleMapsAPI.NET.Tests.API.Utils.MockConfig
{
    /// <summary>
    /// Config for mocking valid results web response
    /// </summary>
    public class MockValidResultsWebResponseConfig : MockResultWebResponseConfig
    {

        #region Constructors

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="statusCode">Status code</param>
        public MockValidResultsWebResponseConfig(HttpStatusCode statusCode = HttpStatusCode.OK)
            : base("{\"status\":\"OK\",\"results\":[]}", statusCode)
        {
        }

        #endregion

    }
}