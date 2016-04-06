using System;
using System.Collections.Generic;
using FluentAssertions;
using GoogleMapsAPI.NET.API.Common.Components.Locations;
using GoogleMapsAPI.NET.API.Common.Components.Locations.Common;
using GoogleMapsAPI.NET.API.Directions.Enums;
using GoogleMapsAPI.NET.Extensions;
using GoogleMapsAPI.NET.Tests.API.Common;
using GoogleMapsAPI.NET.Tests.API.Extensions;
using GoogleMapsAPI.NET.Tests.API.Utils.MockConfig;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleMapsAPI.NET.Tests.API.Directions
{

    /// <summary>
    /// Directions API tests
    /// </summary>
    [TestClass]
    public class DirectionsAPITests : APITests
    {

        #region Test methods

        /// <summary>
        /// Test simple driving directions
        /// </summary>
        [TestMethod]
        public void TestSimpleDirections()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for routes
                var webMocks = client.ArrangeWebResponseValidRoutesMocks();

                // Make client call
                client.Directions.GetDirections(
                    new AddressLocation("Sydney"),
                    new AddressLocation("Melbourne"));

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/directions/json?" +
                    "origin=Sydney&destination=Melbourne");

            }

        }

        /// <summary>
        /// Test complex request
        /// </summary>
        [TestMethod]
        public void TestComplexRequest()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for routes
                var webMocks = client.ArrangeWebResponseValidRoutesMocks();

                // Make client call
                client.Directions.GetDirections(
                    new AddressLocation("Sydney"),
                    new AddressLocation("Melbourne"),
                    TransportationModeEnum.Bicycling,
                    avoid: AvoidFeaturesEnum.Highways | AvoidFeaturesEnum.Tolls | AvoidFeaturesEnum.Ferries,
                    units: UnitSystemEnum.Metric,
                    region: "us");

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/directions/json?" +
                    "origin=Sydney&destination=Melbourne&mode=bicycling" +
                    "&avoid=ferries%7Chighways%7Ctolls&units=metric&region=us");

            }

        }

        /// <summary>
        /// Test transit without time
        /// </summary>
        [TestMethod]
        public void TestTransitWithoutTime()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for routes
                var webMocks = client.ArrangeWebResponseValidRoutesMocks();

                // Make client call
                client.Directions.GetDirections(
                    new AddressLocation("Sydney Town Hall"),
                    new AddressLocation("Parramatta, NSW"),
                    TransportationModeEnum.Transit,
                    transitMode: TransitModeEnum.Bus);

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/directions/json?" +
                    "origin=Sydney+Town+Hall&destination=Parramatta%2C+NSW" + 
                    "&mode=transit&transit_mode=bus");

            }

        }

        /// <summary>
        /// Test transit with departure time
        /// </summary>
        [TestMethod]
        public void TestTransitWithDepartureTime()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for routes
                var webMocks = client.ArrangeWebResponseValidRoutesMocks();

                // Make client call
                client.Directions.GetDirections(
                    new AddressLocation("Sydney Town Hall"),
                    new AddressLocation("Parramatta, NSW"),
                    TransportationModeEnum.Transit,
                    trafficModel: TrafficModelEnum.Optimistic,
                    departureTime: new DateTime(2016,1,2, 16, 43, 00));
                
                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/directions/json?" +
                    "origin=Sydney+Town+Hall&destination=Parramatta%2C+NSW&mode=transit" +
                    "&departure_time=1451770980&traffic_model=optimistic");

            }

        }

        /// <summary>
        /// Test transit with arrival time
        /// </summary>
        [TestMethod]
        public void TestTransitWithArrivalTime()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for routes
                var webMocks = client.ArrangeWebResponseValidRoutesMocks();

                // Make client call
                client.Directions.GetDirections(
                    new AddressLocation("Sydney Town Hall"),
                    new AddressLocation("Parramatta, NSW"),
                    TransportationModeEnum.Transit,
                    trafficModel: TrafficModelEnum.Optimistic,
                    arrivalTime: new DateTime(2016, 1, 2, 16, 43, 00));

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/directions/json?" +
                    "origin=Sydney+Town+Hall&destination=Parramatta%2C+NSW&mode=transit" +
                    "&arrival_time=1451770980&traffic_model=optimistic");

            }
            
        }

        /// <summary>
        /// Test transit with departure and arrival time
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestTransitWithDepartureAndArrivalTime()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for routes
                client.ArrangeWebResponseValidRoutesMocks();

                // Make client call
                // Should not specify both departure and arrival time, exception will be thrown
                client.Directions.GetDirections(
                    new AddressLocation("Sydney Town Hall"),
                    new AddressLocation("Parramatta, NSW"),
                    TransportationModeEnum.Transit,
                    trafficModel: TrafficModelEnum.Optimistic,
                    departureTime: new DateTime(2016, 1, 2, 15, 43, 00),
                    arrivalTime: new DateTime(2016, 1, 2, 16, 43, 00));

            }

        }

        /// <summary>
        /// Test invalid travel mode
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestInvalidTravelMode()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for routes
                client.ArrangeWebResponseValidRoutesMocks();

                // Make client call with forced invalid integer value
                client.Directions.GetDirections(
                    new AddressLocation("48 Pirrama Road, Pyrmont, NSW"),
                    new AddressLocation("Sydney Town Hall"),
                    (TransportationModeEnum?) 23);

            }            

        }

        /// <summary>
        /// Test round trip travel mode
        /// </summary>
        [TestMethod]
        public void TestTravelModeRoundTrip()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for routes
                var webMocks = client.ArrangeWebResponseValidRoutesMocks();

                // Make client call
                client.Directions.GetDirections(
                    new AddressLocation("Town Hall, Sydney"),
                    new AddressLocation("Parramatta, NSW"),
                    TransportationModeEnum.Bicycling);

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/directions/json?" +
                    "origin=Town+Hall%2C+Sydney&destination=Parramatta%2C+NSW" +
                    "&mode=bicycling");

            }

        }

        /// <summary>
        /// Test Brooklyn to Queens by transit
        /// </summary>
        [TestMethod]
        public void TestBrooklynToQueensByTransit()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for routes
                var webMocks = client.ArrangeWebResponseValidRoutesMocks();

                // Get current date/time
                var now = DateTime.Now;

                // Make client call
                client.Directions.GetDirections(
                    new AddressLocation("Brooklyn"),
                    new AddressLocation("Queens"),
                    TransportationModeEnum.Transit,
                    departureTime: now);

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/directions/json?" +
                    "origin=Brooklyn&destination=Queens&mode=transit" +
                    "&departure_time=" + now.SecondsSinceEpoch());

            }

        }

        /// <summary>
        /// Test Boston to Concord via Charlestown and Lexington
        /// </summary>
        [TestMethod]
        public void test_boston_to_concord_via_charlestown_and_lexington()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for routes
                var webMocks = client.ArrangeWebResponseValidRoutesMocks();

                // Make client call
                client.Directions.GetDirections(
                    new AddressLocation("Boston, MA"),
                    new AddressLocation("Concord, MA"),
                    waypoints: new List<Location>
                    {
                        new AddressLocation("Charlestown, MA"),
                        new AddressLocation("Lexington, MA")
                    });

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/directions/json?" +
                    "origin=Boston%2C+MA&destination=Concord%2C+MA" +
                    "&waypoints=Charlestown%2C+MA%7CLexington%2C+MA");

            }

        }

        /// <summary>
        /// Test Adelaide wine tour
        /// </summary>
        [TestMethod]
        public void TestAdelaideWineTour()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for routes
                var webMocks = client.ArrangeWebResponseValidRoutesMocks();

                // Make client call
                client.Directions.GetDirections(
                    new AddressLocation("Adelaide, SA"),
                    new AddressLocation("Adelaide, SA"),
                    waypoints: new List<Location>
                    {
                        new AddressLocation("Barossa Valley, SA"),
                        new AddressLocation("Clare, SA"),
                        new AddressLocation("Connawarra, SA"),
                        new AddressLocation("McLaren Vale, SA")
                    },
                    optimizeWaypoints: true);

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/directions/json?" +
                    "origin=Adelaide%2C+SA&destination=Adelaide%2C+SA" +
                    "&waypoints=optimize%3Atrue%7CBarossa+Valley%2C+" +
                    "SA%7CClare%2C+SA%7CConnawarra%2C+SA%7CMcLaren+" +
                    "Vale%2C+SA");

            }
            
        }

        /// <summary>
        /// Test Toledo to Madrid in Spain
        /// </summary>
        [TestMethod]
        public void TestToledoToMadridInSpain()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for routes
                var webMocks = client.ArrangeWebResponseValidRoutesMocks();

                // Make client call
                client.Directions.GetDirections(
                    new AddressLocation("Toledo"),
                    new AddressLocation("Madrid"),
                    region: "es");

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/directions/json?" +
                    "origin=Toledo&destination=Madrid&region=es");

            }

        }

        /// <summary>
        /// Test response returning no results
        /// </summary>
        [TestMethod]
        public void TestZeroResultsReturnsResponse()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for routes
                client.ArrangeWebResponseResultMocks(
                    new MockResultWebResponseConfig("{\"status\":\"ZERO_RESULTS\",\"routes\":[]}"));

                // Make client call
                var result = client.Directions.GetDirections(
                    new AddressLocation("Toledo"),
                    new AddressLocation("Madrid"));

                // Assertions
                result.Status.Should().Be("ZERO_RESULTS");
                result.Routes.Should().BeEmpty();

            }            

        }

        /// <summary>
        /// Test language parameter
        /// </summary>
        [TestMethod]
        public void TestLanguageParameter()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for routes
                var webMocks = client.ArrangeWebResponseValidRoutesMocks();

                // Make client call
                client.Directions.GetDirections(
                    new AddressLocation("Toledo"),
                    new AddressLocation("Madrid"),
                    region: "es",
                    language: "es");

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/directions/json?" +
                    "origin=Toledo&destination=Madrid&language=es&region=es");

            }
            
        }

        /// <summary>
        /// Test alternatives
        /// </summary>
        [TestMethod]
        public void TestAlternatives()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for routes
                var webMocks = client.ArrangeWebResponseValidRoutesMocks();

                // Make client call
                client.Directions.GetDirections(
                    new AddressLocation("Sydney Town Hall"),
                    new AddressLocation("Parramatta Town Hall"),
                    alternatives: true);

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/directions/json?" +
                    "origin=Sydney+Town+Hall&destination=Parramatta+Town+Hall" +
                    "&alternatives=true");

            }

        }

        /// <summary>
        /// Test parsing directions response
        /// </summary>
        [TestMethod]
        public void TestParseDirectionsResponse()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Set response data
                var responseData = @"{
                   ""geocoded_waypoints"" : [
                      {
                         ""geocoder_status"" : ""OK"",
                         ""place_id"" : ""ChIJ7cv00DwsDogRAMDACa2m4K8"",
                         ""types"" : [ ""locality"", ""political"" ]
                      },
                      {
                         ""geocoder_status"" : ""OK"",
                         ""place_id"" : ""ChIJ69Pk6jdlyIcRDqM1KDY3Fpg"",
                         ""types"" : [ ""locality"", ""political"" ]
                      },
                      {
                         ""geocoder_status"" : ""OK"",
                         ""place_id"" : ""ChIJgdL4flSKrYcRnTpP0XQSojM"",
                         ""types"" : [ ""locality"", ""political"" ]
                      },
                      {
                         ""geocoder_status"" : ""OK"",
                         ""place_id"" : ""ChIJE9on3F3HwoAR9AhGJW_fL-I"",
                         ""types"" : [ ""locality"", ""political"" ]
                      }
                   ],
                   ""routes"" : [
                      {
                         ""bounds"" : {
                            ""northeast"" : {
                               ""lat"" : 41.8781139,
                               ""lng"" : -87.6297872
                            },
                            ""southwest"" : {
                               ""lat"" : 34.052353,
                               ""lng"" : -118.2435703
                            }
                         },
                         ""copyrights"" : ""Map data ©2016 Google, INEGI"",
                         ""legs"" : [
                            {
                               ""distance"" : {
                                  ""text"" : ""580 mi"",
                                  ""value"" : 932702
                               },
                               ""duration"" : {
                                  ""text"" : ""8 hours 34 mins"",
                                  ""value"" : 30857
                               },
                               ""end_address"" : ""Joplin, MO, USA"",
                               ""end_location"" : {
                                  ""lat"" : 37.0842313,
                                  ""lng"" : -94.51348499999999
                               },
                               ""start_address"" : ""Chicago, IL, USA"",
                               ""start_location"" : {
                                  ""lat"" : 41.8781139,
                                  ""lng"" : -87.6297872
                               },
                               ""steps"" : [ 
				                   {
                                     ""distance"" : {
                                        ""text"" : ""0.2 mi"",
                                        ""value"" : 268
                                     },
                                     ""duration"" : {
                                        ""text"" : ""1 min"",
                                        ""value"" : 57
                                     },
                                     ""end_location"" : {
                                        ""lat"" : 41.8757043,
                                        ""lng"" : -87.6296938
                                     },
                                     ""html_instructions"" : ""Head \u003cb\u003esouth\u003c/b\u003e on \u003cb\u003eS Federal St\u003c/b\u003e toward \u003cb\u003eW Van Buren St\u003c/b\u003e"",
                                     ""polyline"" : {
                                        ""points"" : ""eir~FdezuOpFInFI""
                                     },
                                     ""start_location"" : {
                                        ""lat"" : 41.8781139,
                                        ""lng"" : -87.6297872
                                     },
                                     ""travel_mode"" : ""DRIVING""
                                  }
			                   ],
                               ""via_waypoint"" : []
                            },
                         ],
                         ""overview_polyline"" : {
                            ""points"" : ""a~l~Fjk~uOnzh@vlbBtc~@tsE`vnApw{A`dw@~w\\|tNtqf@l{Yd_Fblh@rxo@b}@xxSfytAblk@xxaBeJxlcBb~t@zbh@jc|Bx}C`rv@rw|@rlhA~dVzeo@vrSnc}Axf]fjz@xfFbw~@dz{A~d{A|zOxbrBbdUvpo@`cFp~xBc`Hk@nurDznmFfwMbwz@bbl@lq~@loPpxq@bw_@v|{CbtY~jGqeMb{iF|n\\~mbDzeVh_Wr|Efc\\x`Ij{kE}mAb~uF{cNd}xBjp]fulBiwJpgg@|kHntyArpb@bijCk_Kv~eGyqTj_|@`uV`k|DcsNdwxAott@r}q@_gc@nu`CnvHx`k@dse@j|p@zpiAp|gEicy@`omFvaErfo@igQxnlApqGze~AsyRzrjAb__@ftyB}pIlo_BflmA~yQftNboWzoAlzp@mz`@|}_@fda@jakEitAn{fB_a]lexClshBtmqAdmY_hLxiZd~XtaBndgC""
                         },
                         ""summary"" : ""I-55 S and I-44"",
                         ""warnings"" : [],
                         ""waypoint_order"" : [ 0, 1 ]
                      }
                   ],
                   ""status"" : ""OK""
                }";

                // Arrange mocks for response data
                var webMocks = client.ArrangeWebResponseResultMocks(
                    new MockResultWebResponseConfig(responseData));

                // Make client call
                var directions = client.Directions.GetDirections(
                    new AddressLocation("Chicago,IL"),
                    new AddressLocation("Los Angeles,CA"),
                    waypoints: new List<Location>
                    {
                        new AddressLocation("Joplin,MO"),
                        new AddressLocation("Oklahoma City,OK")
                    });

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/directions/json?" +
                    "origin=Chicago%2CIL&destination=Los+Angeles%2CCA" + 
                    "&waypoints=Joplin%2CMO%7COklahoma+City%2COK");

                // Data
                directions.IsValid.Should().BeTrue();
                directions.HasErrorMessage.Should().BeFalse();

                // Results
                directions.GeocodedWaypoints.Should().NotBeNullOrEmpty();
                directions.GeocodedWaypoints.Count.Should().Be(4);
                directions.GeocodedWaypoints[2].GeocoderStatus.Should().Be(GeocoderStatusEnum.OK);
                directions.GeocodedWaypoints[2].PlaceId.Should().Be("ChIJgdL4flSKrYcRnTpP0XQSojM");
                directions.GeocodedWaypoints[2].Types.Should().NotBeNullOrEmpty();
                directions.GeocodedWaypoints[2].Types.Should().Contain(
                    new[] {"locality", "political"});

                directions.Routes.Should().NotBeNullOrEmpty();
                directions.Routes.Count.Should().Be(1);
                directions.Routes[0].Summary.Should().Be("I-55 S and I-44");
                directions.Routes[0].Copyrights.Should().Contain("©").And.Contain("Google");
                directions.Routes[0].Warnings.Should().BeEmpty();

                directions.Routes[0].OverviewPolyline.Should().NotBeNull();
                directions.Routes[0].OverviewPolyline.EncodedPoints.Should().NotBeEmpty();
                directions.Routes[0].OverviewPolyline.DecodePoints().Should().NotBeNullOrEmpty();

                directions.Routes[0].WaypointOrder.Should().NotBeNullOrEmpty();
                directions.Routes[0].WaypointOrder.Count.Should().Be(2);
                directions.Routes[0].WaypointOrder.Should().ContainInOrder(0, 1);

                directions.Routes[0].Bounds.Should().NotBeNull();
                directions.Routes[0].Bounds.NorthEast.Should().NotBeNull();
                directions.Routes[0].Bounds.NorthEast.Latitude.Should().Be(41.8781139);
                directions.Routes[0].Bounds.NorthEast.Longitude.Should().Be(-87.6297872);
                directions.Routes[0].Bounds.Southwest.Should().NotBeNull();
                directions.Routes[0].Bounds.Southwest.Latitude.Should().Be(34.052353);
                directions.Routes[0].Bounds.Southwest.Longitude.Should().Be(-118.2435703);

                directions.Routes[0].Legs.Should().NotBeNullOrEmpty();
                directions.Routes[0].Legs.Count.Should().Be(1);

                directions.Routes[0].Legs[0].Distance.Should().NotBeNull();
                directions.Routes[0].Legs[0].Distance.Value.Should().Be(932702);
                directions.Routes[0].Legs[0].Distance.Text.Should().Be("580 mi");
                directions.Routes[0].Legs[0].Duration.Should().NotBeNull();
                directions.Routes[0].Legs[0].Duration.Value.Should().Be(30857);
                directions.Routes[0].Legs[0].Duration.Text.Should().Be("8 hours 34 mins");

                directions.Routes[0].Legs[0].StartLocation.Should().NotBeNull();
                directions.Routes[0].Legs[0].StartLocation.Latitude.Should().Be(41.8781139);
                directions.Routes[0].Legs[0].StartLocation.Longitude.Should().Be(-87.6297872);
                directions.Routes[0].Legs[0].EndLocation.Should().NotBeNull();
                directions.Routes[0].Legs[0].EndLocation.Latitude.Should().Be(37.0842313);
                directions.Routes[0].Legs[0].EndLocation.Longitude.Should().Be(-94.51348499999999);

                directions.Routes[0].Legs[0].StartAddress.Should().Be("Chicago, IL, USA");
                directions.Routes[0].Legs[0].EndAddress.Should().Be("Joplin, MO, USA");

                directions.Routes[0].Legs[0].Steps.Should().NotBeNullOrEmpty();
                directions.Routes[0].Legs[0].Steps.Count.Should().Be(1);

                directions.Routes[0].Legs[0].Steps[0].TravelMode.Should().Be(TransportationModeEnum.Driving);
                directions.Routes[0].Legs[0].Steps[0].StartLocation.Should().NotBeNull();
                directions.Routes[0].Legs[0].Steps[0].StartLocation.Latitude.Should().Be(41.8781139);
                directions.Routes[0].Legs[0].Steps[0].StartLocation.Longitude.Should().Be(-87.6297872);
                directions.Routes[0].Legs[0].Steps[0].EndLocation.Should().NotBeNull();
                directions.Routes[0].Legs[0].Steps[0].EndLocation.Latitude.Should().Be(41.8757043);
                directions.Routes[0].Legs[0].Steps[0].EndLocation.Longitude.Should().Be(-87.6296938);

                directions.Routes[0].Legs[0].Steps[0].Polyline.Should().NotBeNull();
                directions.Routes[0].Legs[0].Steps[0].Polyline.EncodedPoints.Should().NotBeEmpty();
                directions.Routes[0].Legs[0].Steps[0].Polyline.DecodePoints().Should().NotBeNullOrEmpty();

                directions.Routes[0].Legs[0].Steps[0].Duration.Should().NotBeNull();
                directions.Routes[0].Legs[0].Steps[0].Duration.Value.Should().Be(57);
                directions.Routes[0].Legs[0].Steps[0].Duration.Text.Should().Be("1 min");
                directions.Routes[0].Legs[0].Steps[0].Distance.Should().NotBeNull();
                directions.Routes[0].Legs[0].Steps[0].Distance.Value.Should().Be(268);
                directions.Routes[0].Legs[0].Steps[0].Distance.Text.Should().Be("0.2 mi");

                directions.Routes[0].Legs[0].Steps[0].HTMLInstructions.Should().StartWith("Head");

            }

        }

        #endregion

    }
}