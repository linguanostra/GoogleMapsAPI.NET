using System.Net;

namespace GoogleMapsAPI.NET.Tests.API.Utils.MockConfig
{
    /// <summary>
    /// Config for mocking internal server error result web response
    /// </summary>
    public class MockInternalServerErrorResultWebResponseConfig : MockResultWebResponseConfig
    {

        #region Constructors

        /// <summary>
        /// Create a new instance
        /// </summary>
        public MockInternalServerErrorResultWebResponseConfig() : base(null, HttpStatusCode.InternalServerError, null)
        {
        }

        #endregion
        
    }
}