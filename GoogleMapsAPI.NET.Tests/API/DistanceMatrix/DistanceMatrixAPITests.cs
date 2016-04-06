using System;
using System.Collections.Generic;
using FluentAssertions;
using GoogleMapsAPI.NET.API.Common.Components.Locations;
using GoogleMapsAPI.NET.API.Common.Components.Locations.Interfaces.Combined;
using GoogleMapsAPI.NET.API.Directions.Enums;
using GoogleMapsAPI.NET.Extensions;
using GoogleMapsAPI.NET.Tests.API.Common;
using GoogleMapsAPI.NET.Tests.API.Extensions;
using GoogleMapsAPI.NET.Tests.API.Utils.MockConfig;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleMapsAPI.NET.Tests.API.DistanceMatrix
{

    /// <summary>
    /// Distance matrix API tests
    /// </summary>
    [TestClass]
    public class DistanceMatrixAPITests : APITests
    {

        #region Test methods

        /// <summary>
        /// Test basic params
        /// </summary>
        [TestMethod]
        public void TestBasicParams()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for valid data
                var webMocks = client.ArrangeWebResponseValidRowsMocks();

                // Make client call
                client.DistanceMatrix.GetDistanceMatrix(
                    new List<IAddressOrGeoCoordinatesLocation>
                    {
                        new AddressLocation("Perth, Australia"),
                        new AddressLocation("Sydney, Australia"),
                        new AddressLocation("Melbourne, Australia"),
                        new AddressLocation("Adelaide, Australia"),
                        new AddressLocation("Brisbane, Australia"),
                        new AddressLocation("Darwin, Australia"),
                        new AddressLocation("Hobart, Australia"),
                        new AddressLocation("Canberra, Australia")
                    },
                    new List<IAddressOrGeoCoordinatesLocation>
                    {
                        new AddressLocation("Uluru, Australia"),
                        new AddressLocation("Kakadu, Australia"),
                        new AddressLocation("Blue Mountains, Australia"),
                        new AddressLocation("Bungle Bungles, Australia"),
                        new AddressLocation("The Pinnacles, Australia")
                    });
                
                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/distancematrix/json?" +
                    "origins=Perth%2C+Australia%7CSydney%2C+" +
                    "Australia%7CMelbourne%2C+Australia%7CAdelaide%2C+" +
                    "Australia%7CBrisbane%2C+Australia%7CDarwin%2C+" +
                    "Australia%7CHobart%2C+Australia%7CCanberra%2C+Australia&" +
                    "destinations=Uluru%2C+Australia%7CKakadu%2C+Australia%7C" +
                    "Blue+Mountains%2C+Australia%7CBungle+Bungles%2C+Australia" +
                    "%7CThe+Pinnacles%2C+Australia");

            }

        }

        /// <summary>
        /// Test mixed params
        /// </summary>
        [TestMethod]
        public void TestMixedParams()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for valid data
                var webMocks = client.ArrangeWebResponseValidRowsMocks();

                // Make client call
                client.DistanceMatrix.GetDistanceMatrix(
                    new List<IAddressOrGeoCoordinatesLocation>
                    {
                        new AddressLocation("Bobcaygeon ON"),
                        new GeoCoordinatesLocation(41.43206, -81.38992)
                    },
                    new List<IAddressOrGeoCoordinatesLocation>
                    {
                        new GeoCoordinatesLocation(43.012486, -83.6964149),
                        new GeoCoordinatesLocation(42.8863855, -78.8781627)                        
                    });

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/distancematrix/json?" +
                    "origins=Bobcaygeon+ON%7C41.43206%2C-81.38992&" +
                    "destinations=43.012486%2C-83.6964149%7C42.8863855%2C" +
                    "-78.8781627");

            }

        }

        /// <summary>
        /// Test all params
        /// </summary>
        [TestMethod]
        public void TestAllParams()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for valid data
                var webMocks = client.ArrangeWebResponseValidRowsMocks();

                // Get current date/time
                var now = DateTime.Now;

                // Make client call
                client.DistanceMatrix.GetDistanceMatrix(
                    new List<IAddressOrGeoCoordinatesLocation>
                    {
                        new AddressLocation("Perth, Australia"),
                        new AddressLocation("Sydney, Australia"),
                        new AddressLocation("Melbourne, Australia"),
                        new AddressLocation("Adelaide, Australia"),
                        new AddressLocation("Brisbane, Australia"),
                        new AddressLocation("Darwin, Australia"),
                        new AddressLocation("Hobart, Australia"),
                        new AddressLocation("Canberra, Australia")
                    },
                    new List<IAddressOrGeoCoordinatesLocation>
                    {
                        new AddressLocation("Uluru, Australia"),
                        new AddressLocation("Kakadu, Australia"),
                        new AddressLocation("Blue Mountains, Australia"),
                        new AddressLocation("Bungle Bungles, Australia"),
                        new AddressLocation("The Pinnacles, Australia")
                    },
                    language: "en-AU",
                    mode: TransportationModeEnum.Driving,                     
                    avoid: AvoidFeaturesEnum.Tolls,
                    units: UnitSystemEnum.Imperial,
                    departureTime: now,
                    trafficModel: TrafficModelEnum.Optimistic);

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/distancematrix/json?" +
                    "origins=Perth%2C+Australia%7CSydney%2C+Australia%7C" +
                    "Melbourne%2C+Australia%7CAdelaide%2C+Australia%7C" +
                    "Brisbane%2C+Australia%7CDarwin%2C+Australia%7CHobart%2C+" +
                    "Australia%7CCanberra%2C+Australia&destinations=Uluru%2C+" +
                    "Australia%7CKakadu%2C+Australia%7CBlue+Mountains%2C+Australia" + 
                    "%7CBungle+Bungles%2C+Australia%7CThe+Pinnacles%2C+Australia" + 
                    "&mode=driving&language=en-AU&avoid=tolls&units=imperial" + 
                    "&departure_time=" + now.SecondsSinceEpoch() + "&traffic_model=optimistic");

            }

        }

        /// <summary>
        /// Test language param
        /// </summary>
        [TestMethod]
        public void TestLangParam()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for valid data
                var webMocks = client.ArrangeWebResponseValidRowsMocks();

                // Make client call
                client.DistanceMatrix.GetDistanceMatrix(
                    new List<IAddressOrGeoCoordinatesLocation>
                    {
                        new AddressLocation("Vancouver BC"),
                        new AddressLocation("Seattle")
                    },
                    new List<IAddressOrGeoCoordinatesLocation>
                    {
                        new AddressLocation("San Francisco"),
                        new AddressLocation("Victoria BC")
                    },
                    TransportationModeEnum.Bicycling,
                    language: "fr-FR");

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/distancematrix/json?" +
                    "origins=Vancouver+BC%7CSeattle&destinations=San+Francisco%7CVictoria" +
                    "+BC&mode=bicycling&language=fr-FR");

            }

        }

        /// <summary>
        /// Test multiple avoid features
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestMultipleAvoidFeatures()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for valid data
                client.ArrangeWebResponseValidRowsMocks();

                // Make client call
                client.DistanceMatrix.GetDistanceMatrix(
                    new AddressLocation("Perth, Australia"),
                    new AddressLocation("Uluru, Australia"),
                    avoid: AvoidFeaturesEnum.Ferries | AvoidFeaturesEnum.Highways);

            }

        }

        /// <summary>
        /// Test departure and arrival time
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDepartureAndArrivalTime()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for valid data
                client.ArrangeWebResponseValidRowsMocks();

                // Make client call
                client.DistanceMatrix.GetDistanceMatrix(
                    new AddressLocation("Perth, Australia"),
                    new AddressLocation("Uluru, Australia"),
                    departureTime: DateTime.Now,
                    arrivalTime: DateTime.Now);

            }

        }

        /// <summary>
        /// Test distance matrix response data
        /// </summary>
        [TestMethod]
        public void TestDistanceMatrixResponseData()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Set response data
                var responseData = @"{
                      ""status"": ""OK"",
                      ""origin_addresses"": [ ""Vancouver, BC, Canada"", ""Seattle, État de Washington, États-Unis"" ],
                      ""destination_addresses"": [ ""San Francisco, Californie, États-Unis"", ""Victoria, BC, Canada"" ],
                      ""rows"": [ {
                        ""elements"": [ {
                          ""status"": ""OK"",
                          ""duration"": {
                            ""value"": 340110,
                            ""text"": ""3 jours 22 heures""
                          },
                          ""distance"": {
                            ""value"": 1734542,
                            ""text"": ""1 735 km""
                          }
                        }, {
                          ""status"": ""OK"",
                          ""duration"": {
                            ""value"": 24487,
                            ""text"": ""6 heures 48 minutes""
                          },
                          ""distance"": {
                            ""value"": 129324,
                            ""text"": ""129 km""
                          }
                        } ]
                      }, {
                        ""elements"": [ {
                          ""status"": ""OK"",
                          ""duration"": {
                            ""value"": 288834,
                            ""text"": ""3 jours 8 heures""
                          },
                          ""distance"": {
                            ""value"": 1489604,
                            ""text"": ""1 490 km""
                          }
                        }, {
                          ""status"": ""OK"",
                          ""duration"": {
                            ""value"": 14388,
                            ""text"": ""4 heures 0 minutes""
                          },
                          ""distance"": {
                            ""value"": 135822,
                            ""text"": ""136 km""
                          }
                        } ]
                      } ]
                    }";

                // Arrange mocks for response data
                var webMocks = client.ArrangeWebResponseResultMocks(
                    new MockResultWebResponseConfig(responseData));

                // Make client call
                var matrix = client.DistanceMatrix.GetDistanceMatrix(
                    new List<IAddressOrGeoCoordinatesLocation>
                    {
                        new AddressLocation("Vancouver BC"),
                        new AddressLocation("Seattle")
                    },
                    new List<IAddressOrGeoCoordinatesLocation>
                    {
                        new AddressLocation("San Francisco"),
                        new AddressLocation("Victoria BC")
                    },
                    TransportationModeEnum.Bicycling,
                    language: "fr-FR");

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/distancematrix/json?" +
                    "origins=Vancouver+BC%7CSeattle&destinations=San+Francisco%7CVictoria" + 
                    "+BC&mode=bicycling&language=fr-FR");

                // Data
                matrix.IsValid.Should().BeTrue();
                matrix.HasErrorMessage.Should().BeFalse();

                // Origin addresses
                matrix.OriginAddresses.Should().NotBeNullOrEmpty();
                matrix.OriginAddresses.Count.Should().Be(2);
                matrix.OriginAddresses[1].Should().Be("Seattle, État de Washington, États-Unis");

                // Destination addresses
                matrix.DestinationAddresses.Should().NotBeNullOrEmpty();
                matrix.DestinationAddresses.Count.Should().Be(2);
                matrix.DestinationAddresses[0].Should().Be("San Francisco, Californie, États-Unis");

                // Rows
                matrix.Rows.Should().NotBeNullOrEmpty();
                matrix.Rows.Count.Should().Be(2);

                // Elements
                matrix.Rows[0].Elements.Should().NotBeNullOrEmpty();
                matrix.Rows[0].Elements.Count.Should().Be(2);
                matrix.Rows[0].Elements[0].Status.Should().Be("OK");
                matrix.Rows[0].Elements[0].Distance.Should().NotBeNull();
                matrix.Rows[0].Elements[0].Distance.Value.Should().Be(1734542);
                matrix.Rows[0].Elements[0].Distance.Text.Should().Be("1 735 km");
                matrix.Rows[0].Elements[1].Duration.Should().NotBeNull();
                matrix.Rows[0].Elements[1].Duration.Value.Should().Be(24487);
                matrix.Rows[0].Elements[1].Duration.Text.Should().Be("6 heures 48 minutes");

            }

        }

        #endregion

    }
}