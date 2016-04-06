using System.Net;

namespace GoogleMapsAPI.NET.Tests.API.Utils.MockConfig
{
    /// <summary>
    /// Config for mocking valid places search result web response
    /// </summary>
    public class MockValidPlacesSearchResultWebResponseConfig : MockResultWebResponseConfig
    {

        #region Constructors

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="statusCode">Status code</param>
        public MockValidPlacesSearchResultWebResponseConfig(HttpStatusCode statusCode = HttpStatusCode.OK)
            : base("{\"status\": \"OK\", \"results\": [], \"html_attributions\": []}", statusCode)
        {
        }

        #endregion

    }
}