using System.Collections.Generic;
using FluentAssertions;
using GoogleMapsAPI.NET.API.Common.Components.Locations;
using GoogleMapsAPI.NET.Exceptions;
using GoogleMapsAPI.NET.Tests.API.Common;
using GoogleMapsAPI.NET.Tests.API.Extensions;
using GoogleMapsAPI.NET.Tests.API.Utils.MockConfig;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleMapsAPI.NET.Tests.API.Elevation
{

    /// <summary>
    /// Elevation API tests
    /// </summary>
    [TestClass]
    public class ElevationAPITests : APITests
    {

        #region Test methods

        /// <summary>
        /// Test single elevation
        /// </summary>
        [TestMethod]
        public void TestElevationSingle()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for result
                var webMocks = client.ArrangeWebResponseValidResultsMocks();

                // Make client call
                client.Elevation.GetElevations(
                    new GeoCoordinatesLocation(40.714728, -73.998672));

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/elevation/json?" +
                    "locations=enc%3AabowFtzsbM");

            }

        }

        /// <summary>
        /// Test single elevation list
        /// </summary>
        [TestMethod]
        public void TestElevationSingleList()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for result
                var webMocks = client.ArrangeWebResponseValidResultsMocks();

                // Make client call
                client.Elevation.GetElevations(
                    new List<GeoCoordinatesLocation>
                    {
                        new GeoCoordinatesLocation(40.714728, -73.998672)
                    });

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/elevation/json?" +
                    "locations=enc%3AabowFtzsbM");

            }

        }

        /// <summary>
        /// Test multiple elevations
        /// </summary>
        [TestMethod]
        public void TestElevationMultiple()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for result
                var webMocks = client.ArrangeWebResponseValidResultsMocks();

                // Make client call
                client.Elevation.GetElevations(
                    new List<GeoCoordinatesLocation>
                    {
                        new GeoCoordinatesLocation(40.714728, -73.998672),
                        new GeoCoordinatesLocation(-34.397, 150.644)
                    });

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/elevation/json?" +
                    "locations=enc%3AabowFtzsbMhgmiMuobzi%40");
                                
            }

        }

        /// <summary>
        /// Test elevation along single path
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(APIErrorException))]
        public void TestElevationAlongPathSingle()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for invalid request result
                client.ArrangeWebResponseInvalidRequestResultMocks();

                // Make client call
                client.Elevation.ElevationAlongPath(
                    new List<GeoCoordinatesLocation>
                    {
                        new GeoCoordinatesLocation(40.714728, -73.998672)
                    }, 5);

            }

        }

        /// <summary>
        /// Test elevation along path
        /// </summary>
        [TestMethod]
        public void TestElevationAlongPath()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for result
                var webMocks = client.ArrangeWebResponseValidResultsMocks();

                // Make client call
                client.Elevation.ElevationAlongPath(
                    new List<GeoCoordinatesLocation>
                    {
                        new GeoCoordinatesLocation(40.714728, -73.998672),
                        new GeoCoordinatesLocation(-34.397, 150.644)
                    }, 5);

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/elevation/json?" +
                    "path=enc%3AabowFtzsbMhgmiMuobzi%40&samples=5");

            }
            
        }

        /// <summary>
        /// Test short latitude/longitude
        /// </summary>
        [TestMethod]
        public void TestShortLatlng()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for result
                var webMocks = client.ArrangeWebResponseValidResultsMocks();

                // Make client call
                client.Elevation.GetElevations(
                    new GeoCoordinatesLocation(40, -73));

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/elevation/json?" +
                    "locations=40%2C-73");

            }
            
        }

        /// <summary>
        /// Test elevation response data
        /// </summary>
        [TestMethod]
        public void TestElevationResponseData()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Set response data
                var responseData = @"{
                   ""results"" : [
                      {
                         ""elevation"" : 1608.637939453125,
                         ""location"" : {
                            ""lat"" : 39.73915360,
                            ""lng"" : -104.98470340
                         },
                         ""resolution"" : 4.771975994110107
                      },
                      {
                         ""elevation"" : -50.78903579711914,
                         ""location"" : {
                            ""lat"" : 36.4555560,
                            ""lng"" : -116.8666670
                         },
                         ""resolution"" : 19.08790397644043
                      }
                   ],
                   ""status"" : ""OK""
                }";

                // Arrange mocks for response data
                var webMocks = client.ArrangeWebResponseResultMocks(
                    new MockResultWebResponseConfig(responseData));

                // Make client call
                var elevation = client.Elevation.GetElevations(
                    new List<GeoCoordinatesLocation>
                    {
                        new GeoCoordinatesLocation(39.7391536,-104.9847034),
                        new GeoCoordinatesLocation(36.455556,-116.866667)
                    });

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/elevation/json?" +
                    "locations=enc%3AuppqFjyw_Sli%60ShuogA");

                // Data
                elevation.IsValid.Should().BeTrue();
                elevation.HasErrorMessage.Should().BeFalse();

                elevation.Results.Should().NotBeNullOrEmpty();
                elevation.Results.Count.Should().Be(2);

                elevation.Results[1].Elevation.Should().Be(-50.78903579711914);
                elevation.Results[1].Resolution.Should().Be(19.08790397644043);
                elevation.Results[1].Location.Should().NotBeNull();
                elevation.Results[1].Location.Latitude.Should().Be(36.4555560);
                elevation.Results[1].Location.Longitude.Should().Be(-116.8666670);

            }

        }

        #endregion

    }
}