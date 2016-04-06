using System.Net;

namespace GoogleMapsAPI.NET.Tests.API.Utils.MockConfig
{
    /// <summary>
    /// Config for mocking valid speed limits web response
    /// </summary>
    public class MockValidSpeedLimitsWebResponseConfig : MockResultWebResponseConfig
    {

        #region Constructors

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="statusCode">Status code</param>
        public MockValidSpeedLimitsWebResponseConfig(HttpStatusCode statusCode = HttpStatusCode.OK)
            : base("{\"speedLimits\":[]}", statusCode)
        {
        }

        #endregion

    }
}