using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using FluentAssertions;
using GoogleMapsAPI.NET.API.Client;
using GoogleMapsAPI.NET.API.Common.Components.Locations;
using GoogleMapsAPI.NET.Exceptions;
using GoogleMapsAPI.NET.Requests;
using GoogleMapsAPI.NET.Tests.API.Common;
using GoogleMapsAPI.NET.Tests.API.Extensions;
using GoogleMapsAPI.NET.Tests.API.Utils.MockConfig;
using GoogleMapsAPI.NET.Web.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Rhino.Mocks.Interfaces;

namespace GoogleMapsAPI.NET.Tests.API.Client
{

    /// <summary>
    /// Client API tests
    /// </summary>
    [TestClass]
    public class ClientAPITests : APITests
    {

        #region Test methods

        /// <summary>
        /// Test no API key
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(APICredentialsNotSpecifiedException))]
        public void TestNoAPIKey()
        {

            // Get API client
            using (var client = GetAPIClient(null))
            {
                
                // Get directions
                client.Directions.GetDirections(
                    new AddressLocation("Sydney"),
                    new AddressLocation("Melbourne"));

            }

        }         

        /// <summary>
        /// Test no enterprise credentials
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(APICredentialsNotSpecifiedException))]
        public void TestNoEnterpriseCredentials()
        {

            // Get API client
            using (var client = GetAPIClient(null))
            {
                
                // Get directions
                client.Directions.GetDirections(
                    new AddressLocation("Sydney"),
                    new AddressLocation("Melbourne"));

            }

        }         

        /// <summary>
        /// Test invalid API key
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(APIKeyInvalidException))]
        public void TestInvalidAPIKey()
        {

            // Get API client
            using (var client = GetAPIClient("Invalid key"))
            {

                // Get directions
                client.Directions.GetDirections(
                    new AddressLocation("Sydney"),
                    new AddressLocation("Melbourne"));

            }

        }

        /// <summary>
        /// Test Url encode
        /// See: https://github.com/googlemaps/google-maps-services-python/issues/72
        /// </summary>
        [TestMethod]
        public void TestUrlEncode()
        {

            // Get API client
            using (var client = GetAPIClient())
            {

                // Encode params
                var encodedParams = client.UrlEncodeParams(new QueryParams {["address"] = "=Sydney ~" });

                // Assertions
                encodedParams.Should().Be("address=%3DSydney+~");

            }

        } 

        /// <summary>
        /// Test queries per second
        /// </summary>
        [TestMethod]
        public void TestQueriesPerSecond()
        {

            // This test assumes that the time to run a mocked query is
            // relatively small, eg a few milliseconds. We define a rate of
            // 3 queries per second, and run double that, which should take at
            // least 1 second but no more than 2.

            // Init
            var queriesPerSecond = 3;
            var queryRange = queriesPerSecond*2;

            // Set API client config
            var clientConfig = new MapsAPIClientConfig
            {
                QueriesPerSecond = queriesPerSecond
            };

            // Use mocked API client
            using (var client = GetMockedAPIClient(clientConfig: clientConfig))
            {

                // Arrange mocks for empty result
                client.ArrangeWebResponseValidResultsMocks();

                // Make client calls
                var startTime = DateTime.Now;
                for (var i = 0; i < queryRange; i++)
                {
                    client.Geocoding.Geocode("Sesame St.");
                }

                // Get elapsed time
                var elapsedTime = DateTime.Now - startTime;

                // Assertions
                elapsedTime.Seconds.Should().BeInRange(1, 2);

            }            

        }

        /// <summary>
        /// Test key sent
        /// </summary>
        [TestMethod]
        public void TestKeySent()
        {

            // Use mocked API client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for empty result
                var webMocks = client.ArrangeWebResponseValidResultsMocks();
                
                // Make client call
                client.Geocoding.Geocode("Sesame St.");

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/geocode/json?" +
                    "address=Sesame+St.&key=" + client.APIKey, false);

            }

        } 

        /// <summary>
        /// Test HMAC
        /// </summary>
        [TestMethod]
        public void TestHMAC()
        {

            /*
            From http://en.wikipedia.org/wiki/Hash-based_message_authentication_code

            HMAC_SHA1("key", "The quick brown fox jumps over the lazy dog")
                = 0xde7c9b85b8b78aa6bc8a7a36f70a90701c9db4d9
            */

            // Get API client
            using (var client = GetAPIClient())
            {

                // Config
                const string message = "The quick brown fox jumps over the lazy dog";                               
                const string key = "a2V5"; // "key" -> base64
                const string signature = "3nybhbi3iqa8ino29wqQcBydtNk=";

                // Assertions
                client.SignHMAC(key, message).Should().Be(signature);

            }

        } 

        /// <summary>
        /// Test Url signed
        /// </summary>
        [TestMethod]
        public void TestUrlSigned()
        {

            // Use mocked API client
            using (var client = GetMockedAPIClient("foo", "a2V5"))
            {

                // Arrange mocks for empty result
                var webMocks = client.ArrangeWebResponseValidResultsMocks();

                // Make client call
                client.Geocoding.Geocode("Sesame St.");

                // Assertions

                // Check ordering of parameters.
                webMocks.WebRequestUtil.AssertWasCalled(utility =>
                    utility.Get(
                            Arg<string>.Matches(x => x.Contains("address=Sesame+St.&client=foo&signature")),
                            Arg<RequestConfig>.Is.Anything),
                        options => options.Repeat.Once());

                // Check url
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/geocode/json?" +
                    "address=Sesame+St.&client=foo&" +
                    "signature=fxbWUIcNPZSekVOhp2ul9LW5TpY=", false);

            }            

        }

        /// <summary>
        /// Test user agent sent
        /// </summary>
        [TestMethod]
        public void TestUASent()
        {

            // Use mocked API client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for empty result
                var webMocks = client.ArrangeWebResponseValidResultsMocks();

                // Add expectations
                webMocks.Request.Expect(
                    x => x.UserAgent = Arg<string>.Matches(value => value.StartsWith("GoogleGeoApiClientPython")));

                // Make client call
                client.Geocoding.Geocode("Sesame St.");

                // Assertions
                webMocks.Request.VerifyAllExpectations();

            }
            
        }

        /// <summary>
        /// Test retry
        /// </summary>
        [TestMethod]
        public void TestRetry()
        {

            // Use mocked API client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for custom results
                var webMocks = client.ArrangeWebResponseResultMocks(
                    new List<MockResultWebResponseConfig>
                    {
                        new MockResultWebResponseConfig("{\"status\":\"OVER_QUERY_LIMIT\"}"),
                        new MockValidResultsWebResponseConfig()
                    });

                // Make client calls
                client.Geocoding.Geocode("Sesame St.");

                // Assertions 

                // Ensure expected requests were made 
                webMocks.WebRequestUtil.AssertWasCalled(
                    x => x.Get(Arg<string>.Is.Anything, Arg<RequestConfig>.Is.Anything),
                    options => options.Repeat.Twice());

                // Get requests arguments
                var queryUtilsArgs =
                    webMocks.WebRequestUtil.GetArgumentsForCallsMadeOn(
                        x => x.Get(Arg<string>.Is.Anything, Arg<RequestConfig>.Is.Anything));

                // Ensure they are available
                queryUtilsArgs.Should().NotBeNullOrEmpty();

                // Ensure all calls with same url
                var firstUrl = (string)queryUtilsArgs.First()[0];
                queryUtilsArgs.All(x => (string) (x[0]) == firstUrl).Should().BeTrue();

            }

        }

        /// <summary>
        /// Test transport error
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(HttpResponseException))]        
        public void TestTransportError()
        {

            // Use mocked API client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for custom result
                client.ArrangeWebResponseResultMocks(new MockNotFoundResultWebResponseConfig());

                // Make client call
                client.Geocoding.Geocode("Foo");

            }

        }

        /// <summary>
        /// Test host override
        /// </summary>
        [TestMethod]
        public void TestHostOverride()
        {

            // Use mocked API client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for custom result
                var webMocks = client.ArrangeWebResponseValidResultsMocks();

                // Set expectations
                webMocks.WebRequestUtil.Expect(
                    x =>
                        x.Get(Arg<string>.Matches(value => value.StartsWith("https://foo.com")),
                            Arg<RequestConfig>.Is.Anything)).CallOriginalMethod(OriginalCallOptions.CreateExpectation);

                // Make client call
                client.Get("/bar", QueryParams.Empty(), baseUrl: "https://foo.com");

                // Assertions  
                webMocks.WebRequestUtil.VerifyAllExpectations();

            }

        }

        /// <summary>
        /// Test custom extraction
        /// </summary>
        [TestMethod]
        public void TestCustomExtract()
        {

            // Use mocked API client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for custom result
                client.ArrangeWebResponseResultMocks(new MockErrorResultWebResponseConfig());

                // Extract body handler
                var extractBodyFn = new Func<HttpWebResponse, dynamic>(response => response.GetResponseContent());

                // Make client call
                string result = client.Get("/bar", QueryParams.Empty(), extractBodyFn);

                // Assertions  
                result.Should().Be("{\"error\":\"errormessage\"}");

            }

        }

        /// <summary>
        /// Test retry intermittent
        /// </summary>
        [TestMethod]
        public void TestRetryIntermittent()
        {

            // Use mocked API client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for custom results
                var webMocks = client.ArrangeWebResponseResultMocks(
                    new List<MockResultWebResponseConfig>
                    {
                        new MockInternalServerErrorResultWebResponseConfig(),
                        new MockValidResultsWebResponseConfig()
                    });

                // Make client calls
                client.Geocoding.Geocode("Sesame St.");

                // Assertions 
                
                // Ensure 2 requests were made 
                webMocks.Request.AssertWasCalled(x => x.GetResponse(), options => options.Repeat.Twice());

            }

        }

        #endregion

    }
}