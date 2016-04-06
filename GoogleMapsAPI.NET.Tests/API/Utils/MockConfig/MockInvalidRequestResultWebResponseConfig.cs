using System.Net;

namespace GoogleMapsAPI.NET.Tests.API.Utils.MockConfig
{
    /// <summary>
    /// Config for mocking invalid request result web response
    /// </summary>
    public class MockInvalidRequestResultWebResponseConfig : MockResultWebResponseConfig
    {

        #region Constructors

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="statusCode">Status code</param>
        public MockInvalidRequestResultWebResponseConfig(HttpStatusCode statusCode = HttpStatusCode.OK)
            : base("{\"status\":\"INVALID_REQUEST\",\"results\":[]}", statusCode)
        {
        }

        #endregion

    }
}