using System.Collections.Generic;
using System.Net;
using GoogleMapsAPI.NET.API.Client.Interfaces;
using GoogleMapsAPI.NET.Requests;
using GoogleMapsAPI.NET.Tests.API.Extensions.Results;
using GoogleMapsAPI.NET.Tests.API.Utils;
using GoogleMapsAPI.NET.Tests.API.Utils.MockConfig;
using GoogleMapsAPI.NET.Tests.API.Utils.MockConfig.Images;
using Rhino.Mocks;

namespace GoogleMapsAPI.NET.Tests.API.Extensions
{

    /// <summary>
    /// Client API tests extensions
    /// </summary>
    public static class ClientAPITestsExtensions
    {

        #region Static methods

        /// <summary>
        /// Arrange web response result mocks on client
        /// </summary>
        /// <param name="client">Client</param>
        /// <param name="mockResultConfig">Mock result config</param>
        /// <returns>Result mocks</returns>
        public static ClientAPIWebQueryMocks ArrangeWebResponseResultMocks(this IMapsAPIClient client,
            MockResultWebResponseConfig mockResultConfig)
        {

            // Web response
            var webResponse = ClientAPIMockUtils.MockResultWebResponse(mockResultConfig);

            // Web request
            var webRequest = MockRepository.GenerateMock<HttpWebRequest>();
            webRequest.Stub(x => x.GetResponse()).Return(webResponse);

            // Web request util
            var webRequestUtil = MockRepository.GeneratePartialMock<WebRequestUtility>(client);
            webRequestUtil.Stub(x => x.CreateWebRequest(null)).IgnoreArguments().Return(webRequest);

            // Client
            client.Stub(x => x.WebRequestUtility).Return(webRequestUtil);

            // Return result
            return new ClientAPIWebQueryMocks(webRequestUtil, webRequest, webResponse);

        }

        /// <summary>
        /// Arrange web response result mocks on client
        /// </summary>
        /// <param name="client">Client</param>
        /// <param name="mockResultsConfig">Mock results config</param>
        /// <returns>Result mocks</returns>
        public static ClientAPIMultipleWebQueryMocks ArrangeWebResponseResultMocks(this IMapsAPIClient client,
            IEnumerable<MockResultWebResponseConfig> mockResultsConfig)
        {

            // Web request
            var webRequest = MockRepository.GenerateMock<HttpWebRequest>();

            // Web responses
            var webResponses = new List<HttpWebResponse>();

            // Loop results config
            foreach (var mockConfig in mockResultsConfig)
            {

                // Web response provided only once
                var webResponse = ClientAPIMockUtils.MockResultWebResponse(mockConfig);
                webRequest.Expect(x => x.GetResponse()).Return(webResponse).Repeat.Once();

                // Add it to responses list
                webResponses.Add(webResponse);

            }

            // Web request util
            var webRequestUtil = MockRepository.GeneratePartialMock<WebRequestUtility>(client);
            webRequestUtil.Stub(x => x.CreateWebRequest(null)).IgnoreArguments().Return(webRequest);

            // Client
            client.Stub(x => x.WebRequestUtility).Return(webRequestUtil);

            // Return result
            return new ClientAPIMultipleWebQueryMocks(webRequestUtil, webRequest, webResponses);

        }

        /// <summary>
        /// Arrange web response with valid routes mocks on client
        /// </summary>
        /// <param name="client">Client</param>
        /// <returns>Result mocks</returns>
        public static ClientAPIWebQueryMocks ArrangeWebResponseValidRoutesMocks(this IMapsAPIClient client)
        {

            return client.ArrangeWebResponseResultMocks(new MockValidRoutesWebResponseConfig());

        }

        /// <summary>
        /// Arrange web response with valid rows mocks on client
        /// </summary>
        /// <param name="client">Client</param>
        /// <returns>Result mocks</returns>
        public static ClientAPIWebQueryMocks ArrangeWebResponseValidRowsMocks(this IMapsAPIClient client)
        {

            return client.ArrangeWebResponseResultMocks(new MockValidRowsWebResponseConfig());

        }

        /// <summary>
        /// Arrange web response with valid snapped points mocks on client
        /// </summary>
        /// <param name="client">Client</param>
        /// <returns>Result mocks</returns>
        public static ClientAPIWebQueryMocks ArrangeWebResponseValidSnappedPointsMocks(this IMapsAPIClient client)
        {

            return client.ArrangeWebResponseResultMocks(new MockValidSnappedPointsWebResponseConfig());

        }

        /// <summary>
        /// Arrange web response with valid places search result mocks on client
        /// </summary>
        /// <param name="client">Client</param>
        /// <returns>Result mocks</returns>
        public static ClientAPIWebQueryMocks ArrangeWebResponseValidPlacesSearchResultMocks(this IMapsAPIClient client)
        {

            return client.ArrangeWebResponseResultMocks(new MockValidPlacesSearchResultWebResponseConfig());

        }

        /// <summary>
        /// Arrange web response with valid speed limits mocks on client
        /// </summary>
        /// <param name="client">Client</param>
        /// <returns>Result mocks</returns>
        public static ClientAPIWebQueryMocks ArrangeWebResponseValidSpeedLimitsMocks(this IMapsAPIClient client)
        {

            return client.ArrangeWebResponseResultMocks(new MockValidSpeedLimitsWebResponseConfig());

        }

        /// <summary>
        /// Arrange web response with valid results mocks on client
        /// </summary>
        /// <param name="client">Client</param>
        /// <returns>Result mocks</returns>
        public static ClientAPIWebQueryMocks ArrangeWebResponseValidResultsMocks(this IMapsAPIClient client)
        {

            return client.ArrangeWebResponseResultMocks(new MockValidResultsWebResponseConfig());

        }

        /// <summary>
        /// Arrange web response with invalid request result mocks on client
        /// </summary>
        /// <param name="client">Client</param>
        /// <returns>Result mocks</returns>
        public static ClientAPIWebQueryMocks ArrangeWebResponseInvalidRequestResultMocks(this IMapsAPIClient client)
        {

            return client.ArrangeWebResponseResultMocks(new MockInvalidRequestResultWebResponseConfig());

        }

        /// <summary>
        /// Arrange street view image web response mocks on client
        /// </summary>
        /// <param name="client">Client</param>
        /// <returns>Result mocks</returns>
        public static ClientAPIWebQueryMocks ArrangeStreetViewImageWebResponseMocks(this IMapsAPIClient client)
        {

            return client.ArrangeImageWebResponseMocks(new MockStreetViewImageWebResponseConfig());

        }

        /// <summary>
        /// Arrange place view image web response mocks on client
        /// </summary>
        /// <param name="client">Client</param>
        /// <returns>Result mocks</returns>
        public static ClientAPIWebQueryMocks ArrangePlaceViewImageWebResponseMocks(this IMapsAPIClient client)
        {

            return client.ArrangeImageWebResponseMocks(new MockPlaceImageWebResponseConfig());

        }

        /// <summary>
        /// Arrange image web response mocks on client
        /// </summary>
        /// <param name="client">Client</param>
        /// <param name="mockImageConfig">Mock image config</param>
        /// <returns>Result mocks</returns>
        public static ClientAPIWebQueryMocks ArrangeImageWebResponseMocks(this IMapsAPIClient client,
            MockImageWebResponseConfig mockImageConfig)
        {

            // Web response
            var webResponse = ClientAPIMockUtils.MockImageWebResponse(mockImageConfig);

            // Web request
            var webRequest = MockRepository.GenerateMock<HttpWebRequest>();
            webRequest.Stub(x => x.GetResponse()).Return(webResponse);

            // Web request util
            var webRequestUtil = MockRepository.GeneratePartialMock<WebRequestUtility>(client);
            webRequestUtil.Stub(x => x.CreateWebRequest(null)).IgnoreArguments().Return(webRequest);

            // Client
            client.Stub(x => x.WebRequestUtility).Return(webRequestUtil);

            // Return result
            return new ClientAPIWebQueryMocks(webRequestUtil, webRequest, webResponse);

        }

        #endregion

    }

}