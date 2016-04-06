using System.Net;

namespace GoogleMapsAPI.NET.Tests.API.Utils.MockConfig
{
    /// <summary>
    /// Config for mocking valid snapped points web response
    /// </summary>
    public class MockValidSnappedPointsWebResponseConfig : MockResultWebResponseConfig
    {

        #region Constructors

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="statusCode">Status code</param>
        public MockValidSnappedPointsWebResponseConfig(HttpStatusCode statusCode = HttpStatusCode.OK)
            : base("{\"snappedPoints\":[]}", statusCode)
        {
        }

        #endregion

    }
}