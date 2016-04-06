using System.Net;

namespace GoogleMapsAPI.NET.Tests.API.Utils.MockConfig
{
    /// <summary>
    /// Config for mocking valid routes web response
    /// </summary>
    public class MockValidRoutesWebResponseConfig : MockResultWebResponseConfig
    {

        #region Constructors

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="statusCode">Status code</param>
        public MockValidRoutesWebResponseConfig(HttpStatusCode statusCode = HttpStatusCode.OK)
            : base("{\"status\":\"OK\",\"routes\":[]}", statusCode)
        {
        }

        #endregion

    }
}