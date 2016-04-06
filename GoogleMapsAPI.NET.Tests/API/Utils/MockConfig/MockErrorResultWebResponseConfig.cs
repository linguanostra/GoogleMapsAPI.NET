using System.Net;

namespace GoogleMapsAPI.NET.Tests.API.Utils.MockConfig
{
    /// <summary>
    /// Config for mocking error result web response
    /// </summary>
    public class MockErrorResultWebResponseConfig : MockResultWebResponseConfig
    {

        #region Constructors

        /// <summary>
        /// Create a new instance
        /// </summary>
        public MockErrorResultWebResponseConfig() : base("{\"error\":\"errormessage\"}", HttpStatusCode.OK)
        {
        }

        #endregion
        
    }
}