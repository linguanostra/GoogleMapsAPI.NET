using System.Collections.Generic;
using FluentAssertions;
using GoogleMapsAPI.NET.API.Common.Components.Locations;
using GoogleMapsAPI.NET.API.Common.Components.Locations.Interfaces;
using GoogleMapsAPI.NET.API.Roads.Enums;
using GoogleMapsAPI.NET.Tests.API.Common;
using GoogleMapsAPI.NET.Tests.API.Extensions;
using GoogleMapsAPI.NET.Tests.API.Utils.MockConfig;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleMapsAPI.NET.Tests.API.Roads
{

    /// <summary>
    /// Roads API tests
    /// </summary>
    [TestClass]
    public class RoadsAPITests : APITests
    {

        #region Test methods

        /// <summary>
        /// Test snap points to road
        /// </summary>
        [TestMethod]
        public void TestSnap()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for snapped points
                var webMocks = client.ArrangeWebResponseValidSnappedPointsMocks();

                // Make client call
                client.Roads.SnapToRoads(new GeoCoordinatesLocation(40.714728, -73.998672));

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://roads.googleapis.com/v1/snapToRoads?" +
                    "path=40.714728%2C-73.998672");

            }

        }

        /// <summary>
        /// Test speed limits for path
        /// </summary>
        [TestMethod]
        public void TestSpeedLimitsPath()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for speed limits
                var webMocks = client.ArrangeWebResponseValidSpeedLimitsMocks();

                // Make client call
                client.Roads.SpeedLimits(new List<IGeoCoordinatesLocation>
                {
                    new GeoCoordinatesLocation(1,2),
                    new GeoCoordinatesLocation(3,4)
                });

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://roads.googleapis.com/v1/speedLimits?" +
                    "path=1%2C2%7C3%2C4");

            }

        }

        /// <summary>
        /// Test speed limits for places
        /// </summary>
        [TestMethod]
        public void TestSpeedLimitsPlaces()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for speed limits
                var webMocks = client.ArrangeWebResponseValidSpeedLimitsMocks();

                // Make client call
                client.Roads.SpeedLimits(new PlaceLocation("id1"));

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://roads.googleapis.com/v1/speedLimits?" +
                    "placeId=id1");

            }

        }

        /// <summary>
        /// Test speed limits for multiple places
        /// </summary>
        [TestMethod]
        public void TestSpeedLimitsMultiplePlaces()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for speed limits
                var webMocks = client.ArrangeWebResponseValidSpeedLimitsMocks();

                // Make client call
                client.Roads.SpeedLimits(new List<IPlaceLocation>
                {
                    new PlaceLocation("id1"),
                    new PlaceLocation("id2"),
                    new PlaceLocation("id3")
                });

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://roads.googleapis.com/v1/speedLimits?" +
                    "placeId=id1&placeId=id2&placeId=id3");

            }

        }

        /// <summary>
        /// Test snap to roads response data
        /// </summary>
        [TestMethod]
        public void TestSnapToRoadsResponseData()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Set response data
                var responseData = @"{
                  ""snappedPoints"": [
                    {
                      ""location"": {
                        ""latitude"": -35.2784167,
                        ""longitude"": 149.1294692
                      },
                      ""originalIndex"": 0,
                      ""placeId"": ""ChIJoR7CemhNFmsRQB9QbW7qABM""
                    },
                    {
                      ""location"": {
                        ""latitude"": -35.280321693840129,
                        ""longitude"": 149.12908274880189
                      },
                      ""originalIndex"": 1,
                      ""placeId"": ""ChIJiy6YT2hNFmsRkHZAbW7qABM""
                    },
                    {
                      ""location"": {
                        ""latitude"": -35.2803415,
                        ""longitude"": 149.1290788
                      },
                      ""placeId"": ""ChIJiy6YT2hNFmsRkHZAbW7qABM""
                    }
                  ]
                }";

                // Arrange mocks for response data
                var webMocks = client.ArrangeWebResponseResultMocks(
                    new MockResultWebResponseConfig(responseData));

                // Make client call
                var roads = client.Roads.SnapToRoads(
                    new List<IGeoCoordinatesLocation>
                    {
                        new GeoCoordinatesLocation(-35.27801,149.12958),
                        new GeoCoordinatesLocation(-35.28032,149.12907),
                        new GeoCoordinatesLocation(-35.28099,149.12929),
                        new GeoCoordinatesLocation(-35.28144,149.12984)
                    }, interpolate: true);

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://roads.googleapis.com/v1/snapToRoads?" +
                    "path=-35.27801%2C149.12958%7C-35.28032%2C149.12907" +
                    "%7C-35.28099%2C149.12929%7C-35.28144%2C149.12984" + 
                    "&interpolate=true");

                // Data
                roads.IsValid.Should().BeTrue();
                roads.HasErrorMessage.Should().BeFalse();

                roads.SnappedPoints.Should().NotBeNullOrEmpty();
                roads.SnappedPoints.Count.Should().Be(3);
                roads.SnappedPoints[2].Location.Should().NotBeNull();
                roads.SnappedPoints[2].Location.Latitude.Should().Be(-35.2803415);
                roads.SnappedPoints[2].Location.Longitude.Should().Be(149.1290788);                
                roads.SnappedPoints[2].PlaceId.Should().Be("ChIJiy6YT2hNFmsRkHZAbW7qABM");

                roads.SnappedPoints[1].OriginalIndex.Should().Be(1);
                roads.SnappedPoints[2].OriginalIndex.Should().NotHaveValue();                


            }

        }

        /// <summary>
        /// Test speed limits response data
        /// </summary>
        [TestMethod]
        public void TestSpeedLimitsResponseData()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Set response data
                var responseData = @"{
                  ""speedLimits"": [
                    {
                      ""placeId"": ""ChIJ1Wi6I2pNFmsRQL9GbW7qABM"",
                      ""speedLimit"": 60,
                      ""units"": ""KPH""
                    },
                    {
                      ""placeId"": ""ChIJ58xCoGlNFmsRUEZUbW7qABM"",
                      ""speedLimit"": 50,
                      ""units"": ""MPH""
                    },
                    {
                      ""placeId"": ""ChIJ9RhaiGlNFmsR0IxAbW7qABM"",
                      ""speedLimit"": 100,
                      ""units"": ""KPH""
                    }
                  ]
                }";

                // Arrange mocks for response data
                var webMocks = client.ArrangeWebResponseResultMocks(
                    new MockResultWebResponseConfig(responseData));

                // Make client call
                var limits = client.Roads.SpeedLimits(
                    new List<IPlaceLocation>()
                    {
                        new PlaceLocation("ChIJ1Wi6I2pNFmsRQL9GbW7qABM"),
                        new PlaceLocation("ChIJ58xCoGlNFmsRUEZUbW7qABM"),
                        new PlaceLocation("ChIJ9RhaiGlNFmsR0IxAbW7qABM")
                    });

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://roads.googleapis.com/v1/speedLimits?" +
                    "placeId=ChIJ1Wi6I2pNFmsRQL9GbW7qABM" +
                    "&placeId=ChIJ58xCoGlNFmsRUEZUbW7qABM" +
                    "&placeId=ChIJ9RhaiGlNFmsR0IxAbW7qABM");

                // Data
                limits.IsValid.Should().BeTrue();
                limits.HasErrorMessage.Should().BeFalse();

                limits.SpeedLimits.Should().NotBeNullOrEmpty();
                limits.SpeedLimits.Count.Should().Be(3);
                limits.SpeedLimits[0].PlaceId.Should().Be("ChIJ1Wi6I2pNFmsRQL9GbW7qABM");
                limits.SpeedLimits[1].Limit.Should().Be(50);
                limits.SpeedLimits[1].Units.Should().Be(SpeedUnitEnum.MPH);
                limits.SpeedLimits[2].Limit.Should().Be(100);
                limits.SpeedLimits[2].Units.Should().Be(SpeedUnitEnum.KPH);

            }

        }

        #endregion

    }
}