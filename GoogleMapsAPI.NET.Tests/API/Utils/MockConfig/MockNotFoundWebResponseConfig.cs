using System.Net;

namespace GoogleMapsAPI.NET.Tests.API.Utils.MockConfig
{
    /// <summary>
    /// Config for mocking not found result web response
    /// </summary>
    public class MockNotFoundResultWebResponseConfig : MockResultWebResponseConfig
    {

        #region Constructors

        /// <summary>
        /// Create a new instance
        /// </summary>
        public MockNotFoundResultWebResponseConfig() : base(null, HttpStatusCode.NotFound, null)
        {
        }

        #endregion

    }
}