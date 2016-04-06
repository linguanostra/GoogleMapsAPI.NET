using System.IO;
using System.Net;
using GoogleMapsAPI.NET.Tests.API.Utils.MockConfig;
using GoogleMapsAPI.NET.Tests.API.Utils.MockConfig.Images;
using Rhino.Mocks;

namespace GoogleMapsAPI.NET.Tests.API.Utils
{

    /// <summary>
    /// Client API mock utils
    /// </summary>
    public class ClientAPIMockUtils
    {

        #region Static methods
        
        /// <summary>
        /// Mock result web response
        /// </summary>
        /// <param name="mockResultConfig">Mock result config</param>
        /// <returns>Mocked instance</returns>
        public static HttpWebResponse MockResultWebResponse(MockResultWebResponseConfig mockResultConfig)
        {

            // Generate mock
            var webResponse = MockRepository.GenerateMock<HttpWebResponse>();

            // Define stubs
            webResponse.Stub(x => x.StatusCode).Return(mockResultConfig.StatusCode);
            webResponse.Stub(x => x.ContentType).Return(mockResultConfig.ContentType);
            webResponse.Stub(x => x.GetResponseStream()).WhenCalled(invocation =>
            {
                invocation.ReturnValue = new MemoryStream(mockResultConfig.GetContentBytes());
            }).Return(null).Repeat.Any();

            // Return result
            return webResponse;

        }

        /// <summary>
        /// Mock image web response
        /// </summary>
        /// <param name="mockImageConfig">Mock image config</param>
        /// <returns>Mocked instance</returns>
        public static HttpWebResponse MockImageWebResponse(MockImageWebResponseConfig mockImageConfig)
        {

            // Generate mock
            var webResponse = MockRepository.GenerateMock<HttpWebResponse>();

            // Define stubs
            webResponse.Stub(x => x.StatusCode).Return(mockImageConfig.StatusCode);
            webResponse.Stub(x => x.ContentType).Return(mockImageConfig.ContentType);
            webResponse.Stub(x => x.GetResponseStream()).WhenCalled(invocation =>
            {
                invocation.ReturnValue = new MemoryStream(mockImageConfig.GetImageBytes());
            }).Return(null).Repeat.Any();

            // Return result
            return webResponse;

        }

        #endregion

    }
}