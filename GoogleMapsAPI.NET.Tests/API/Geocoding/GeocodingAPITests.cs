using FluentAssertions;
using GoogleMapsAPI.NET.API.Common.Components;
using GoogleMapsAPI.NET.API.Common.Components.Locations;
using GoogleMapsAPI.NET.API.Geocoding.Enums;
using GoogleMapsAPI.NET.API.Places.Enums;
using GoogleMapsAPI.NET.Requests;
using GoogleMapsAPI.NET.Tests.API.Common;
using GoogleMapsAPI.NET.Tests.API.Extensions;
using GoogleMapsAPI.NET.Tests.API.Utils.MockConfig;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleMapsAPI.NET.Tests.API.Geocoding
{

    /// <summary>
    /// Geocoding API tests
    /// </summary>
    [TestClass]
    public class GeocodingAPITests : APITests
    {

        #region Test methods

        /// <summary>
        /// Test simple geocode
        /// </summary>
        [TestMethod]
        public void TestSimpleGeocode()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for result
                var webMocks = client.ArrangeWebResponseValidResultsMocks();

                // Make client call
                client.Geocoding.Geocode("Sydney");

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/geocode/json?" +
                    "address=Sydney");

            }

        }
        
        /// <summary>
        /// Test reverse geocode
        /// </summary>
        [TestMethod]
        public void TestReverseGeocode()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for result
                var webMocks = client.ArrangeWebResponseValidResultsMocks();

                // Make client call
                client.Geocoding.ReverseGeocode(
                    new GeoCoordinatesLocation(-33.867486, 151.206990));

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/geocode/json?" +
                    "latlng=-33.867486%2C151.20699");

            }

        }

        /// <summary>
        /// Test geocoding the GooglePlex
        /// </summary>
        [TestMethod]
        public void TestGeocodingTheGoogleplex()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for result
                var webMocks = client.ArrangeWebResponseValidResultsMocks();

                // Make client call
                client.Geocoding.Geocode("1600 Amphitheatre Parkway, Mountain View, CA");

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/geocode/json?" +
                    "address=1600+Amphitheatre+Parkway%2C+Mountain+View%2C+CA");

            }

        }

        /// <summary>
        /// Test geocode with bounds
        /// </summary>
        [TestMethod]
        public void TestGeocodeWithBounds()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for result
                var webMocks = client.ArrangeWebResponseValidResultsMocks();

                // Make client call
                client.Geocoding.Geocode("Winnetka", 
                    bounds: new ViewportBoundingBox(
                        new GeoCoordinatesLocation(34.172684, -118.604794), 
                        new GeoCoordinatesLocation(34.236144, -118.500938)
                        ));

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/geocode/json?" +
                    "address=Winnetka&bounds=34.172684%2C-118.604794%7C" +
                    "34.236144%2C-118.500938");
    
            }

        }

        /// <summary>
        /// Test geocode with region biasing
        /// </summary>
        [TestMethod]
        public void TestGeocodeWithRegionBiasing()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for result
                var webMocks = client.ArrangeWebResponseValidResultsMocks();

                // Make client call
                client.Geocoding.Geocode("Toledo", region: "es");

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/geocode/json?" +
                    "address=Toledo&region=es");
    
            }

        }

        /// <summary>
        /// Test geocode with component filter
        /// </summary>
        [TestMethod]
        public void TestGeocodeWithComponentFilter()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for result
                var webMocks = client.ArrangeWebResponseValidResultsMocks();

                // Make client call
                client.Geocoding.Geocode("santa cruz", new ComponentsFilter()
                {
                    ["country"] = "ES"
                });

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/geocode/json?" +
                    "address=santa+cruz&components=country%3AES");
    
            }

        }

        /// <summary>
        /// Test geocode with multiple component filters
        /// </summary>
        [TestMethod]
        public void TestGeocodeWithMultipleComponentFilters()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for result
                var webMocks = client.ArrangeWebResponseValidResultsMocks();

                // Make client call
                client.Geocoding.Geocode("Torun", new ComponentsFilter()
                {
                    ["administrative_area"] = "TX",
                    ["country"] = "US"
                });

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/geocode/json?" +
                    "address=Torun&components=administrative_area%3ATX%7C" +
                    "country%3AUS");
    
            }

        }

        /// <summary>
        /// Test geocode with only components
        /// </summary>
        [TestMethod]
        public void TestGeocodeWithJustComponents()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for result
                var webMocks = client.ArrangeWebResponseValidResultsMocks();

                // Make client call
                client.Geocoding.Geocode(components: new ComponentsFilter()
                {
                    ["route"] = "Annegatan",
                    ["administrative_area"] = "Helsinki",
                    ["country"] = "Finland"
                });

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/geocode/json?" +
                    "components=administrative_area%3AHelsinki%7Ccountry" + 
                    "%3AFinland%7Croute%3AAnnegatan");

            }
            
        }

        /// <summary>
        /// Test simple reverse geocode
        /// </summary>
        [TestMethod]
        public void TestSimpleReverseGeocode()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for result
                var webMocks = client.ArrangeWebResponseValidResultsMocks();

                // Make client call
                client.Geocoding.ReverseGeocode(
                    new GeoCoordinatesLocation(40.714224, -73.961452));

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/geocode/json?" +
                    "latlng=40.714224%2C-73.961452");

            }

        }

        /// <summary>
        /// Test reverse geocode restricted by type
        /// </summary>
        [TestMethod]
        public void TestReverseGeocodeRestrictedByType()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for result
                var webMocks = client.ArrangeWebResponseValidResultsMocks();

                // Make client call
                client.Geocoding.ReverseGeocode(
                    new GeoCoordinatesLocation(40.714224, -73.961452),
                    locationType: GeometryLocationType.Rooftop,
                    addressType: AddressTypeEnum.StreetAddress);

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/geocode/json?" +
                    "latlng=40.714224%2C-73.961452&result_type=street_address" + 
                    "&location_type=ROOFTOP");

            }

        }

        /// <summary>
        /// Test reverse geocode with multiple location types
        /// </summary>
        [TestMethod]
        public void TestReverseGeocodeMultipleLocationTypes()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for result
                var webMocks = client.ArrangeWebResponseValidResultsMocks();

                // Make client call
                client.Geocoding.ReverseGeocode(
                    new GeoCoordinatesLocation(40.714224, -73.961452),
                    locationType: GeometryLocationType.Rooftop | GeometryLocationType.RangeInterpolated,
                    addressType: AddressTypeEnum.StreetAddress);

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/geocode/json?" +
                    "latlng=40.714224%2C-73.961452&result_type=street_address" +
                    "&location_type=RANGE_INTERPOLATED%7CROOFTOP");

            }
            
        }

        /// <summary>
        /// Test reverse geocode multiple result types
        /// </summary>
        [TestMethod]
        public void TestReverseGeocodeMultipleResultTypes()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for result
                var webMocks = client.ArrangeWebResponseValidResultsMocks();

                // Make client call
                client.Geocoding.ReverseGeocode(
                    new GeoCoordinatesLocation(40.714224, -73.961452),
                    locationType: GeometryLocationType.Rooftop,
                    addressType: AddressTypeEnum.StreetAddress | AddressTypeEnum.Route);

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/geocode/json?" +
                    "latlng=40.714224%2C-73.961452&result_type=route" +
                    "%7Cstreet_address&location_type=ROOFTOP");

            }

        }

        /// <summary>
        /// Test partial match
        /// </summary>
        [TestMethod]
        public void TestPartialMatch()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for result
                var webMocks = client.ArrangeWebResponseValidResultsMocks();

                // Make client call
                client.Geocoding.Geocode("Pirrama Pyrmont");

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/geocode/json?" +
                    "address=Pirrama+Pyrmont");

            }
            
        }

        /// <summary>
        /// Test UTF result
        /// </summary>
        [TestMethod]
        public void TestUtfResults()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for result
                var webMocks = client.ArrangeWebResponseValidResultsMocks();

                // Make client call
                client.Geocoding.Geocode(components: new ComponentsFilter()
                {
                    ["postal_code"] = "96766"
                });

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/geocode/json?" +
                    "components=postal_code%3A96766");

            }            

        }

        /// <summary>
        /// Test UTF8 request
        /// </summary>
        [TestMethod]
        public void TestUtf8Request()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for result
                var webMocks = client.ArrangeWebResponseValidResultsMocks();

                // Make client call
                client.Geocoding.Geocode("中国"); // China

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/geocode/json?" +
                    "address=%E4%B8%AD%E5%9B%BD");

            }            

        }

        /// <summary>
        /// Parse geocode response
        /// </summary>
        [TestMethod]
        public void TestParseGeocodeResponse()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Set response data
                var responseData = @"{
                   ""results"" : [
                      {
                         ""address_components"" : [
                            {
                               ""long_name"" : ""1600"",
                               ""short_name"" : ""1600"",
                               ""types"" : [ ""street_number"" ]
                            },
                            {
                               ""long_name"" : ""Amphitheatre Parkway"",
                               ""short_name"" : ""Amphitheatre Pkwy"",
                               ""types"" : [ ""route"" ]
                            },
                            {
                               ""long_name"" : ""Mountain View"",
                               ""short_name"" : ""Mountain View"",
                               ""types"" : [ ""locality"", ""political"" ]
                            },
                            {
                               ""long_name"" : ""Santa Clara County"",
                               ""short_name"" : ""Santa Clara County"",
                               ""types"" : [ ""administrative_area_level_2"", ""political"" ]
                            },
                            {
                               ""long_name"" : ""California"",
                               ""short_name"" : ""CA"",
                               ""types"" : [ ""administrative_area_level_1"", ""political"" ]
                            },
                            {
                               ""long_name"" : ""United States"",
                               ""short_name"" : ""US"",
                               ""types"" : [ ""country"", ""political"" ]
                            },
                            {
                               ""long_name"" : ""94043"",
                               ""short_name"" : ""94043"",
                               ""types"" : [ ""postal_code"" ]
                            }
                         ],
                         ""formatted_address"" : ""1600 Amphitheatre Pkwy, Mountain View, CA 94043, USA"",
                         ""geometry"" : {
                            ""location"" : {
                               ""lat"" : 37.4224504,
                               ""lng"" : -122.0840859
                            },
                            ""location_type"" : ""ROOFTOP"",
                            ""viewport"" : {
                               ""northeast"" : {
                                  ""lat"" : 37.4237993802915,
                                  ""lng"" : -122.0827369197085
                               },
                               ""southwest"" : {
                                  ""lat"" : 37.4211014197085,
                                  ""lng"" : -122.0854348802915
                               }
                            }
                         },
                         ""place_id"" : ""ChIJ2eUgeAK6j4ARbn5u_wAGqWA"",
                         ""types"" : [ ""street_address"" ]
                      }
                   ],
                   ""status"" : ""OK""
                }";

                // Arrange mocks for response data
                var webMocks = client.ArrangeWebResponseResultMocks(
                    new MockResultWebResponseConfig(responseData));

                // Make client call
                var data = client.Geocoding.Geocode("1600 Amphitheatre Parkway, Mountain View, CA");

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/geocode/json?" +
                    "address=1600+Amphitheatre+Parkway%2C+Mountain+View%2C+CA");

                // Data
                data.IsValid.Should().BeTrue();
                data.HasErrorMessage.Should().BeFalse();

                // Results
                data.Results.Should().NotBeNullOrEmpty();
                data.Results.Count.Should().Be(1);

                data.Results[0].AddressComponents.Should().NotBeNullOrEmpty();
                data.Results[0].AddressComponents.Count.Should().Be(7);
                data.Results[0].AddressComponents[5].LongName.Should().Be("United States");
                data.Results[0].AddressComponents[5].ShortName.Should().Be("US");
                data.Results[0].AddressComponents[5].Types.Should().NotBeNullOrEmpty();
                data.Results[0].AddressComponents[5].Types.Should().Contain(
                    new[] { PlaceResultTypeEnum.Country, PlaceResultTypeEnum.Political});

                data.Results[0].FormattedAddress.Should().StartWith("1600 Amphitheatre Pkwy");
                data.Results[0].PlaceId.Should().Be("ChIJ2eUgeAK6j4ARbn5u_wAGqWA");

                data.Results[0].Types.Should().NotBeNullOrEmpty();
                data.Results[0].Types.Count.Should().Be(1);
                data.Results[0].Types.Should().Contain("street_address");

                data.Results[0].Geometry.Should().NotBeNull();
                data.Results[0].Geometry.Location.Should().NotBeNull();
                data.Results[0].Geometry.Location.Latitude.Should().Be(37.4224504);
                data.Results[0].Geometry.Location.Longitude.Should().Be(-122.0840859);
                data.Results[0].Geometry.LocationType.Should().Be(GeometryLocationType.Rooftop);
                data.Results[0].Geometry.Viewport.Should().NotBeNull();
                data.Results[0].Geometry.Viewport.NorthEast.Should().NotBeNull();
                data.Results[0].Geometry.Viewport.NorthEast.Latitude.Should().Be(37.4237993802915);
                data.Results[0].Geometry.Viewport.NorthEast.Longitude.Should().Be(-122.0827369197085);
                data.Results[0].Geometry.Viewport.Southwest.Should().NotBeNull();
                data.Results[0].Geometry.Viewport.Southwest.Latitude.Should().Be(37.4211014197085);
                data.Results[0].Geometry.Viewport.Southwest.Longitude.Should().Be(-122.0854348802915);

            }

        }

        #endregion

    }
}