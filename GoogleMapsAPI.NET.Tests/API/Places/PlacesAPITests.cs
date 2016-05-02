using System;
using System.Drawing.Imaging;
using FluentAssertions;
using GoogleMapsAPI.NET.API.Common.Components.Locations;
using GoogleMapsAPI.NET.API.Directions.Enums;
using GoogleMapsAPI.NET.API.Places.Enums;
using GoogleMapsAPI.NET.Extensions;
using GoogleMapsAPI.NET.Requests;
using GoogleMapsAPI.NET.Tests.API.Common;
using GoogleMapsAPI.NET.Tests.API.Extensions;
using GoogleMapsAPI.NET.Tests.API.Utils.MockConfig;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleMapsAPI.NET.Tests.API.Places
{

    /// <summary>
    /// Places API tests
    /// </summary>
    [TestClass]
    public class PlacesAPITests : APITests
    {

        #region Test methods

        /// <summary>
        /// Test places text search
        /// </summary>
        [TestMethod]
        public void TestPlacesTextSearch()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for places search results
                var webMocks = client.ArrangeWebResponseValidPlacesSearchResultMocks();

                // Make client call
                client.Places.TextSearch(
                    "restaurant",
                    location: new GeoCoordinatesLocation(-33.86746, 151.207090),
                    radius: 100,
                    language: "en-AU",
                    minprice: 1,
                    maxPrice: 4,
                    openNow: true,
                    placeType: PlaceSearchTypeEnum.Restaurant);

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/place/textsearch/json?" +
                    "query=restaurant&location=-33.86746%2C151.20709&radius=100" +
                    "&language=en-AU&minprice=1&maxprice=4&opennow=true&type=" + 
                    "restaurant");

            }

        }

        /// <summary>
        /// Test places nearby search
        /// </summary>
        [TestMethod]
        public void TestPlacesNearbySearch()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for places search results
                var webMocks = client.ArrangeWebResponseValidPlacesSearchResultMocks();

                // Make client call
                client.Places.NearbySearch(
                    new GeoCoordinatesLocation(-33.86746, 151.207090),
                    keyword: "foo",
                    language: "en-AU",
                    minprice: 1,
                    maxPrice: 4,
                    name: new[] {"bar"},
                    openNow: true,
                    rankBy: PlaceRankByEnum.Distance,
                    placeType: PlaceSearchTypeEnum.LiquorStore);

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/place/nearbysearch/json?" +
                    "location=-33.86746%2C151.20709&keyword=foo&language=en-AU" + 
                    "&minprice=1&maxprice=4&name=bar&opennow=true&rankby=distance" + 
                    "&type=liquor_store");

                // Validate params
                Action validation1 = () =>
                {
                    client.Places.NearbySearch(new GeoCoordinatesLocation(-33.86746, 151.207090),
                        rankBy: PlaceRankByEnum.Distance);
                };
                validation1.ShouldThrow<ArgumentException>();

                Action validation2 = () =>
                {
                    client.Places.NearbySearch(new GeoCoordinatesLocation(-33.86746, 151.207090),
                        radius: 100,
                        keyword: "foo",
                        rankBy: PlaceRankByEnum.Distance);
                };
                validation2.ShouldThrow<ArgumentException>();

            }

        }

        /// <summary>
        /// Test places radar search
        /// </summary>
        [TestMethod]
        public void TestPlacesRadarSearch()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for places search results
                var webMocks = client.ArrangeWebResponseValidPlacesSearchResultMocks();

                // Make client call
                client.Places.RadarSearch(
                    new GeoCoordinatesLocation(-33.86746, 151.207090),
                    100,
                    keyword: "foo",
                    minprice: 1,
                    maxPrice: 4,
                    name: new[] { "bar" },
                    openNow: true,
                    placeType: PlaceSearchTypeEnum.LiquorStore);

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/place/radarsearch/json?" +
                    "location=-33.86746%2C151.20709&radius=100&keyword=foo&minprice=1" + 
                    "&maxprice=4&name=bar&opennow=true&type=liquor_store");

                // Validate params
                Action validation = () =>
                {
                    client.Places.RadarSearch(
                        new GeoCoordinatesLocation(-33.86746, 151.207090),
                        100);
                };
                validation.ShouldThrow<ArgumentException>();

            }

        }

        /// <summary>
        /// Test places radar search with zero results
        /// </summary>
        [TestMethod]
        public void TestPlacesRadarSearchZeroResults()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for places search results
                var webMocks = client.ArrangeWebResponseResultMocks(
                    new MockResultWebResponseConfig(@"{
                       ""html_attributions"" : [],
                       ""results"" : [],
                       ""status"" : ""ZERO_RESULTS""
                    }"));

                // Make client call
                var places = client.Places.RadarSearch(
                    new GeoCoordinatesLocation(46.8011704,-71.3277777),
                    10,                    
                    placeType: PlaceSearchTypeEnum.ATM);

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/place/radarsearch/json?" +
                    "location=46.8011704%2C-71.3277777&radius=10&type=atm");

                // Validate results
                places.IsValid.Should().BeTrue();
                places.NoResultsFound.Should().BeTrue();
                places.Status.Should().Be("ZERO_RESULTS");
                places.Results.Should().BeEmpty();

            }

        }

        /// <summary>
        /// Test place details
        /// </summary>
        [TestMethod]
        public void TestPlaceDetails()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for places search results
                var webMocks = client.ArrangeWebResponseValidPlacesSearchResultMocks();

                // Make client call
                client.Places.GetPlaceDetails(
                    "ChIJN1t_tDeuEmsRUsoyG83frY4", 
                    language: "en-AU");

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/place/details/json?" +
                    "placeid=ChIJN1t_tDeuEmsRUsoyG83frY4&language=en-AU");

            }

        }

        /// <summary>
        /// Test place photo
        /// </summary>
        [TestMethod]
        public void TestPlacePhoto()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for image
                var webMocks = client.ArrangePlaceViewImageWebResponseMocks();

                // Make client call
                var result = client.Places.GetPlacePhoto(
                    "CnRtAAAATLZNl354RwP_9UKbQ_5Psy40texXePv4oAlgP4qNEkdIrkyse7rPXYGd9D_Uj1rVsQdWT4oRz4QrYAJNpFX7rzqqMlZw2h2E2y5IKMUZ7ouD_SlcHxYq1yL4KbKUv3qtWgTK0A6QbGh87GB3sscrHRIQiG2RrmU_jF4tENr9wGS_YxoUSSDrYjWmrNfeEHSGSc3FyhNLlBU",
                    maxWidth: 400);

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/place/photo?" +
                    "photoreference=CnRtAAAATLZNl354RwP_9UKbQ_5Psy40texXe" + 
                    "Pv4oAlgP4qNEkdIrkyse7rPXYGd9D_Uj1rVsQdWT4oRz4QrYAJNp" +
                    "FX7rzqqMlZw2h2E2y5IKMUZ7ouD_SlcHxYq1yL4KbKUv3qtWgTK0" + 
                    "A6QbGh87GB3sscrHRIQiG2RrmU_jF4tENr9wGS_YxoUSSDrYjWmr" + 
                    "NfeEHSGSc3FyhNLlBU&maxwidth=400");

                // Image data
                result.Content.Should().NotBeNullOrEmpty();

            }

        }

        /// <summary>
        /// Test place photo without maximum dimension param
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNoMaxDimensionPlacePhoto()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for image
                client.ArrangePlaceViewImageWebResponseMocks();

                // Make client call
                client.Places.GetPlacePhoto(
                    "CnRtAAAATLZNl354RwP_9UKbQ_5Psy40texXePv4oAlgP4qNEkdIrkyse7rPXYGd9D_Uj1rVsQdWT4oRz4QrYAJNpFX7rzqqMlZw2h2E2y5IKMUZ7ouD_SlcHxYq1yL4KbKUv3qtWgTK0A6QbGh87GB3sscrHRIQiG2RrmU_jF4tENr9wGS_YxoUSSDrYjWmrNfeEHSGSc3FyhNLlBU");

            }

        }

        /// <summary>
        /// Test autocomplete
        /// </summary>
        [TestMethod]
        public void TestAutocomplete()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks
                var webMocks = client.ArrangeWebResponseValidResultsMocks();

                // Make client call
                client.Places.AutoComplete(
                    "Google",
                    location: new GeoCoordinatesLocation(-33.86746, 151.207090),
                    offset: 3,
                    language: "en-AU",
                    types: new[] { "geocode" },
                    components: new ComponentsFilter { ["country"] = "au" }
                    );

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/place/autocomplete/json?" +
                    "input=Google&offset=3&location=-33.86746%2C151.20709&language=en-AU" + 
                    "&types=geocode&components=country%3Aau");

            }

        }

        /// <summary>
        /// Test query autocomplete
        /// </summary>
        [TestMethod]
        public void TestQueryAutoComplete()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks
                var webMocks = client.ArrangeWebResponseValidResultsMocks();

                // Make client call
                client.Places.QueryAutoComplete("pizza near New York");

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/place/queryautocomplete/json?" +
                    "input=pizza+near+New+York");

            }

        }

        /// <summary>
        /// Test nearby search response
        /// </summary>
        [TestMethod]
        public void TestNearbySearchResponse()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Set response data
                var responseData = @"{
                   ""html_attributions"" : [],
                   ""results"" : [
                      {
                         ""geometry"" : {
                            ""location"" : {
                               ""lat"" : -33.870775,
                               ""lng"" : 151.199025
                            }
                         },
                         ""icon"" : ""http://maps.gstatic.com/mapfiles/place_api/icons/travel_agent-71.png"",
                         ""id"" : ""21a0b251c9b8392186142c798263e289fe45b4aa"",
                         ""name"" : ""Rhythmboat Cruises"",
                         ""opening_hours"" : {
                            ""open_now"" : true
                         },
                         ""photos"" : [
                            {
                               ""height"" : 270,
                               ""html_attributions"" : [],
                               ""photo_reference"" : ""CnRnAAAAF-LjFR1ZV93eawe1cU_3QNMCNmaGkowY7CnOf-kcNmPhNnPEG9W979jOuJJ1sGr75rhD5hqKzjD8vbMbSsRnq_Ni3ZIGfY6hKWmsOf3qHKJInkm4h55lzvLAXJVc-Rr4kI9O1tmIblblUpg2oqoq8RIQRMQJhFsTr5s9haxQ07EQHxoUO0ICubVFGYfJiMUPor1GnIWb5i8"",
                               ""width"" : 519
                            }
                         ],
                         ""place_id"" : ""ChIJyWEHuEmuEmsRm9hTkapTCrk"",
                         ""scope"" : ""GOOGLE"",
                         ""alt_ids"" : [
                            {
                               ""place_id"" : ""D9iJyWEHuEmuEmsRm9hTkapTCrk"",
                               ""scope"" : ""APP""
                            }
                         ],
                         ""reference"" : ""CoQBdQAAAFSiijw5-cAV68xdf2O18pKIZ0seJh03u9h9wk_lEdG-cP1dWvp_QGS4SNCBMk_fB06YRsfMrNkINtPez22p5lRIlj5ty_HmcNwcl6GZXbD2RdXsVfLYlQwnZQcnu7ihkjZp_2gk1-fWXql3GQ8-1BEGwgCxG-eaSnIJIBPuIpihEhAY1WYdxPvOWsPnb2-nGb6QGhTipN0lgaLpQTnkcMeAIEvCsSa0Ww"",
                         ""types"" : [ ""travel_agency"", ""restaurant"", ""food"", ""establishment"" ],
                         ""vicinity"" : ""Pyrmont Bay Wharf Darling Dr, Sydney""
                      },
                      {
                         ""geometry"" : {
                            ""location"" : {
                               ""lat"" : -33.866891,
                               ""lng"" : 151.200814
                            }
                         },
                         ""icon"" : ""http://maps.gstatic.com/mapfiles/place_api/icons/restaurant-71.png"",
                         ""place_id"" : ""45a27fd8d56c56dc62afc9b49e1d850440d5c403"",
                         ""name"" : ""Private Charter Sydney Habour Cruise"",
                         ""photos"" : [
                            {
                               ""height"" : 426,
                               ""html_attributions"" : [],
                               ""photo_reference"" : ""CnRnAAAAL3n0Zu3U6fseyPl8URGKD49aGB2Wka7CKDZfamoGX2ZTLMBYgTUshjr-MXc0_O2BbvlUAZWtQTBHUVZ-5Sxb1-P-VX2Fx0sZF87q-9vUt19VDwQQmAX_mjQe7UWmU5lJGCOXSgxp2fu1b5VR_PF31RIQTKZLfqm8TA1eynnN4M1XShoU8adzJCcOWK0er14h8SqOIDZctvU"",
                               ""width"" : 640
                            }
                         ],
                         ""place_id"" : ""ChIJqwS6fjiuEmsRJAMiOY9MSms"",
                         ""scope"" : ""GOOGLE"",
                         ""reference"" : ""CpQBhgAAAFN27qR_t5oSDKPUzjQIeQa3lrRpFTm5alW3ZYbMFm8k10ETbISfK9S1nwcJVfrP-bjra7NSPuhaRulxoonSPQklDyB-xGvcJncq6qDXIUQ3hlI-bx4AxYckAOX74LkupHq7bcaREgrSBE-U6GbA1C3U7I-HnweO4IPtztSEcgW09y03v1hgHzL8xSDElmkQtRIQzLbyBfj3e0FhJzABXjM2QBoUE2EnL-DzWrzpgmMEulUBLGrtu2Y"",
                         ""types"" : [ ""restaurant"", ""food"", ""establishment"" ],
                         ""vicinity"" : ""Australia""
                      },
                      {
                         ""geometry"" : {
                            ""location"" : {
                               ""lat"" : -33.870943,
                               ""lng"" : 151.190311
                            }
                         },
                         ""icon"" : ""http://maps.gstatic.com/mapfiles/place_api/icons/restaurant-71.png"",
                         ""id"" : ""30bee58f819b6c47bd24151802f25ecf11df8943"",
                         ""name"" : ""Bucks Party Cruise"",
                         ""opening_hours"" : {
                            ""open_now"" : true
                         },
                         ""photos"" : [
                            {
                               ""height"" : 600,
                               ""html_attributions"" : [],
                               ""photo_reference"" : ""CnRnAAAA48AX5MsHIMiuipON_Lgh97hPiYDFkxx_vnaZQMOcvcQwYN92o33t5RwjRpOue5R47AjfMltntoz71hto40zqo7vFyxhDuuqhAChKGRQ5mdO5jv5CKWlzi182PICiOb37PiBtiFt7lSLe1SedoyrD-xIQD8xqSOaejWejYHCN4Ye2XBoUT3q2IXJQpMkmffJiBNftv8QSwF4"",
                               ""width"" : 800
                            }
                         ],
                         ""place_id"" : ""ChIJLfySpTOuEmsRsc_JfJtljdc"",
                         ""scope"" : ""GOOGLE"",
                         ""reference"" : ""CoQBdQAAANQSThnTekt-UokiTiX3oUFT6YDfdQJIG0ljlQnkLfWefcKmjxax0xmUpWjmpWdOsScl9zSyBNImmrTO9AE9DnWTdQ2hY7n-OOU4UgCfX7U0TE1Vf7jyODRISbK-u86TBJij0b2i7oUWq2bGr0cQSj8CV97U5q8SJR3AFDYi3ogqEhCMXjNLR1k8fiXTkG2BxGJmGhTqwE8C4grdjvJ0w5UsAVoOH7v8HQ"",
                         ""types"" : [ ""restaurant"", ""food"", ""establishment"" ],
                         ""vicinity"" : ""37 Bank St, Pyrmont""
                      },
                      {
                         ""geometry"" : {
                            ""location"" : {
                               ""lat"" : -33.867591,
                               ""lng"" : 151.201196
                            }
                         },
                         ""icon"" : ""http://maps.gstatic.com/mapfiles/place_api/icons/travel_agent-71.png"",
                         ""id"" : ""a97f9fb468bcd26b68a23072a55af82d4b325e0d"",
                         ""name"" : ""Australian Cruise Group"",
                         ""opening_hours"" : {
                            ""open_now"" : true
                         },
                         ""photos"" : [
                            {
                               ""height"" : 242,
                               ""html_attributions"" : [],
                               ""photo_reference"" : ""CnRnAAAABjeoPQ7NUU3pDitV4Vs0BgP1FLhf_iCgStUZUr4ZuNqQnc5k43jbvjKC2hTGM8SrmdJYyOyxRO3D2yutoJwVC4Vp_dzckkjG35L6LfMm5sjrOr6uyOtr2PNCp1xQylx6vhdcpW8yZjBZCvVsjNajLBIQ-z4ttAMIc8EjEZV7LsoFgRoU6OrqxvKCnkJGb9F16W57iIV4LuM"",
                               ""width"" : 200
                            }
                         ],
                         ""place_id"" : ""ChIJrTLr-GyuEmsRBfy61i59si0"",
                         ""scope"" : ""GOOGLE"",
                         ""reference"" : ""CoQBeQAAAFvf12y8veSQMdIMmAXQmus1zqkgKQ-O2KEX0Kr47rIRTy6HNsyosVl0CjvEBulIu_cujrSOgICdcxNioFDHtAxXBhqeR-8xXtm52Bp0lVwnO3LzLFY3jeo8WrsyIwNE1kQlGuWA4xklpOknHJuRXSQJVheRlYijOHSgsBQ35mOcEhC5IpbpqCMe82yR136087wZGhSziPEbooYkHLn9e5njOTuBprcfVw"",
                         ""types"" : [ ""travel_agency"", ""restaurant"", ""food"", ""establishment"" ],
                         ""vicinity"" : ""32 The Promenade, King Street Wharf 5, Sydney""
                      }
                   ],
                   ""status"" : ""OK""
                }";

                // Arrange mocks for response data
                var webMocks = client.ArrangeWebResponseResultMocks(
                    new MockResultWebResponseConfig(responseData));

                // Make client call
                var place = client.Places.NearbySearch(
                    new GeoCoordinatesLocation(-33.870775, 151.199025),
                    rankBy: PlaceRankByEnum.Distance,
                    placeType: PlaceSearchTypeEnum.Restaurant);

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/place/nearbysearch/json?" +
                    "location=-33.870775%2C151.199025&rankby=distance&type=restaurant");

                // Data
                place.IsValid.Should().BeTrue();
                place.HasErrorMessage.Should().BeFalse();

                // Results
                place.Results.Should().NotBeNullOrEmpty();
                place.Results.Count.Should().Be(4);
                place.Results[0].Geometry.Location.Latitude.Should().Be(-33.870775);
                place.Results[0].Geometry.Location.Longitude.Should().Be(151.199025);
                place.Results[0].Icon.Should().Be("http://maps.gstatic.com/mapfiles/place_api/icons/travel_agent-71.png");
                place.Results[0].PlaceId.Should().Be("ChIJyWEHuEmuEmsRm9hTkapTCrk");
                place.Results[0].Name.Should().Be("Rhythmboat Cruises");
                place.Results[0].OpeningHours.OpenNow.Should().Be(true);
                place.Results[0].Photos.Should().NotBeNullOrEmpty();
                place.Results[0].Photos.Count.Should().Be(1);
                place.Results[0].Photos[0].Height.Should().Be(270);
                place.Results[0].Photos[0].Width.Should().Be(519);
                place.Results[0].Photos[0].HTMLAttributions.Should().BeEmpty();
                place.Results[0].Scope.Should().NotBeNull();
                place.Results[0].Scope.Should().Be(PlaceScopeEnum.Google);
                place.Results[0].AlternativeIds.Should().NotBeNullOrEmpty();
                place.Results[0].AlternativeIds.Count.Should().Be(1);
                place.Results[0].AlternativeIds[0].PlaceId.Should().Be("D9iJyWEHuEmuEmsRm9hTkapTCrk");
                place.Results[0].AlternativeIds[0].Scope.Should().Be(PlaceScopeEnum.Application);
                place.Results[0].Types.Should().NotBeNullOrEmpty();
                place.Results[0].Types.Count.Should().Be(4);
                place.Results[0].Types.Should()
                    .Contain(new[]
                    {
                        PlaceResultTypeEnum.TravelAgency,
                        PlaceResultTypeEnum.Restaurant,
                        PlaceResultTypeEnum.Establishment,
                        PlaceResultTypeEnum.Food,
                    });

            }

        }

        /// <summary>
        /// Test parsing place details response
        /// </summary>
        [TestMethod]
        public void TestPlaceDetailsResponse()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Set response data
                var responseData = @"{
                   ""html_attributions"" : [],
                   ""result"" : {
                      ""address_components"" : [
                         {
                            ""long_name"" : ""5"",
                            ""short_name"" : ""5"",
                            ""types"" : [ ""floor"" ]
                         },
                         {
                            ""long_name"" : ""48"",
                            ""short_name"" : ""48"",
                            ""types"" : [ ""street_number"" ]
                         },
                         {
                            ""long_name"" : ""Pirrama Road"",
                            ""short_name"" : ""Pirrama Rd"",
                            ""types"" : [ ""route"" ]
                         },
                         {
                            ""long_name"" : ""Pyrmont"",
                            ""short_name"" : ""Pyrmont"",
                            ""types"" : [ ""locality"", ""political"" ]
                         },
                         {
                            ""long_name"" : ""New South Wales"",
                            ""short_name"" : ""NSW"",
                            ""types"" : [ ""administrative_area_level_1"", ""political"" ]
                         },
                         {
                            ""long_name"" : ""Australia"",
                            ""short_name"" : ""AU"",
                            ""types"" : [ ""country"", ""political"" ]
                         },
                         {
                            ""long_name"" : ""2009"",
                            ""short_name"" : ""2009"",
                            ""types"" : [ ""postal_code"" ]
                         }
                      ],
                      ""adr_address"" : ""5, \u003cspan class=\""street-address\""\u003e48 Pirrama Rd\u003c/span\u003e, \u003cspan class=\""locality\""\u003ePyrmont\u003c/span\u003e \u003cspan class=\""region\""\u003eNSW\u003c/span\u003e \u003cspan class=\""postal-code\""\u003e2009\u003c/span\u003e, \u003cspan class=\""country-name\""\u003eAustralia\u003c/span\u003e"",
                      ""formatted_address"" : ""5, 48 Pirrama Rd, Pyrmont NSW 2009, Australia"",
                      ""formatted_phone_number"" : ""(02) 9374 4000"",
                      ""geometry"" : {
                         ""access_points"" : [
                            {
                               ""location"" : {
                                  ""lat"" : -33.8668233,
                                  ""lng"" : 151.195423
                               },
                               ""travel_modes"" : [ ""DRIVING"", ""BICYCLING"", ""WALKING"", ""TRANSIT"" ]
                            }
                         ],
                         ""location"" : {
                            ""lat"" : -33.8666113,
                            ""lng"" : 151.1958324
                         }
                      },
                      ""icon"" : ""https://maps.gstatic.com/mapfiles/place_api/icons/generic_business-71.png"",
                      ""id"" : ""4f89212bf76dde31f092cfc14d7506555d85b5c7"",
                      ""international_phone_number"" : ""+61 2 9374 4000"",
                      ""name"" : ""Google"",
                      ""photos"" : [
                         {
                            ""height"" : 960,
                            ""html_attributions"" : [
                               ""\u003ca href=\""https://maps.google.com/maps/contrib/100919424873665842845/photos\""\u003eDonnie Piercey\u003c/a\u003e""
                            ],
                            ""photo_reference"" : ""CmRdAAAAgusfl8p-xAH-qafdDa6FjIEEOSzoIivTtmV0LlErJE6QDv2PB-RD8YkPlnisGeVH5EBXt8j0lAbTW8YGUE1rHS1xrFtRAWbYWJRl3haumDUm4MkI1HGVqDDeTDViRF4SEhBnwFKqt4phBNGwNof7uS3MGhTJqYLtt8Lthp8RTICFOFExyDBAcw"",
                            ""width"" : 1280
                         },
                         {
                            ""height"" : 1365,
                            ""html_attributions"" : [
                               ""\u003ca href=\""https://maps.google.com/maps/contrib/105932078588305868215/photos\""\u003eMaksym Kozlenko\u003c/a\u003e""
                            ],
                            ""photo_reference"" : ""CmRdAAAATrtDbYluTnC4vXZKYldXB1fFtjugipVHO4Tqpqd0gztq1wkwLR3QujxteI2NnG7H6OkzU9wP4wmiHTTaT01-r6K_goHg2_GoDanv2UavrPn32yUm7jh-0TguvmCBSlkPEhCcRIbeqWLxk6eJDMGUFVvxGhTD6pSDQ6MaqG03xGrEqrDbacH5BQ"",
                            ""width"" : 2048
                         },
                         {
                            ""height"" : 2368,
                            ""html_attributions"" : [
                               ""\u003ca href=\""https://maps.google.com/maps/contrib/108508601154030859314/photos\""\u003eLeo Angelo George\u003c/a\u003e""
                            ],
                            ""photo_reference"" : ""CmRdAAAAhueFizIvA0SjG4VaSFF2kp_LmlkTfKQo1D0879J_IeLj1ZjmEeETplDn3l5QvTx6cB159TPAlUoO2Gy_sf3cgp3mDlgJI2qKPFwUURLaqxGjFYcfb7g4DmhtdMpV1ALJEhBV70q6juQ3kiyI1DOp0UnAGhQGpDVuL_x3d08T7eGXofdSvQulCw"",
                            ""width"" : 3200
                         },
                         {
                            ""height"" : 1131,
                            ""html_attributions"" : [
                               ""\u003ca href=\""https://maps.google.com/maps/contrib/105637462841200316207/photos\""\u003eJemma Tan\u003c/a\u003e""
                            ],
                            ""photo_reference"" : ""CmRdAAAA-BdvbKSpOLDOlxYONLe0z4ipiZP4uwF9IQdalYQzqIgOjphAFmArvazN24ziSHBJcxbIT-y8UzJyO1mzT6QHIB0BenZkbygjmZZfia33JCFWK81jwbn91mRUy1VtxMlwEhCAwHm0V7U72Dj75C-xuBozGhRJUkYwPPAhjSQ4K9wqossL84fBXg"",
                            ""width"" : 1600
                         },
                         {
                            ""height"" : 1763,
                            ""html_attributions"" : [
                               ""\u003ca href=\""https://maps.google.com/maps/contrib/112306938111295040434/photos\""\u003eClément Bramy\u003c/a\u003e""
                            ],
                            ""photo_reference"" : ""CoQBcwAAAMkhCydYoUYNqfkTrkdkaOahQ3nntYmosRXZJbnbsdDWt8ot-TEpu0Q_zDrMIY7k1CqSa07GvSpkhj11WGedzyy0SLQM4Ok-gbPTuoMh244sLzUUdKIUFk_Q31_I8gG3eSgL4B7Y2aUHdLS5znU7si_PWIE-SpbLUbpZRyc9DK8BEhBdOiBvT_lbouw-Mngsm5h1GhQS5_-gJ-mpRtUtM208ObC3eG8bFQ"",
                            ""width"" : 4160
                         },
                         {
                            ""height"" : 2392,
                            ""html_attributions"" : [
                               ""\u003ca href=\""https://maps.google.com/maps/contrib/118134548993694135497/photos\""\u003eOnel Benjamin\u003c/a\u003e""
                            ],
                            ""photo_reference"" : ""CoQBcwAAAKNhW9wmFzy1ZizmgX-_Ux7jxuSEIVGGMvEPEFWjdJBzcAQQkwry-ZILt75BgPtw1TxaJp1UuBW-bmdeSx-__wogvEt8CwRLUYz7ZLEd7qpYSbS2UPAUMjhjNHyktxgJ4YaA0ipT0vMGRIT3fYM8KssyAhtAziutxRAy55zB2NDgEhCAJl0BDR9So_jBiqvqH01oGhQKpSthEsUk7qvWm2nTuJLmn5C3EQ"",
                            ""width"" : 1440
                         },
                         {
                            ""height"" : 608,
                            ""html_attributions"" : [
                               ""\u003ca href=\""https://maps.google.com/maps/contrib/116750797999944764767/photos\""\u003eJessica Pfund\u003c/a\u003e""
                            ],
                            ""photo_reference"" : ""CmRdAAAAqKujxY77M0LWMWOamtYQFQn34rXNU5cT_shSkJNlRR3FHfYqB-x28DwZoUP3DAgk0tWfMsPyySNPmzsWCGXSzYjNp31jVNEnaWOi97kPi1dLic35Qrb5ZUwKWkxlQtdXEhAIZToIwCttuyvyQl4RI3AuGhS9XlckSawcaChajNCfzDzAz3SZyg"",
                            ""width"" : 1080
                         },
                         {
                            ""height"" : 1536,
                            ""html_attributions"" : [
                               ""\u003ca href=\""https://maps.google.com/maps/contrib/104177669626132953795/photos\""\u003eJustine OBRIEN\u003c/a\u003e""
                            ],
                            ""photo_reference"" : ""CmRdAAAA4Pp-s0ED_BWLQPXxufEndGqbKoE4UJkqEMvkpdkMu3p_0cpI6iBPhnK6bKNxCoolR-9n4K0zDhECX3JbEMQQeLe5pgMa31fEQOpN279RczskVJlJSpHGGu7He-FRRPEoEhAq3HAwFaqxX5eEz9mb0SvLGhQr7Ayy5jmddZyz6HIaFwSwgRThmw"",
                            ""width"" : 2048
                         },
                         {
                            ""height"" : 612,
                            ""html_attributions"" : [
                               ""\u003ca href=\""https://maps.google.com/maps/contrib/114701241123617315548/photos\""\u003eMargaret Lee\u003c/a\u003e""
                            ],
                            ""photo_reference"" : ""CmRdAAAANFpEOT24-HlbdFzrpeOzROitgTRM_1pZ5Vk_LL5aY-JH_deCR7hPApcWhdP54J82SzmF09EncTtZsDIEH3L3KID7nKT6jNa_rmh8tCYGqIzzeAKO-nYVS3z7i1wxZ40sEhCBjfvvVo8Pwl63ccimms0_GhRyWaxq0cKGPWNgMQCk4JBYekPsfA"",
                            ""width"" : 816
                         },
                         {
                            ""height"" : 2184,
                            ""html_attributions"" : [
                               ""\u003ca href=\""https://maps.google.com/maps/contrib/114701241123617315548/photos\""\u003eMargaret Lee\u003c/a\u003e""
                            ],
                            ""photo_reference"" : ""CmRdAAAAGAit-or0HjAC6S1C96DQP5t_c8ehvPaHpa8lxbut2XbZ0tjeVfLB2ciho8xR2STUVB3figg69vr7o-KH2uUD4YPijRhDJ4OfX-cNYz7a3jt_5NdrGM5vArKk7t72pRm2EhCBk4A53IReQhBhWRFgWSMpGhTSwTeWzTjNQH7EXesbXXX1dXqkgg"",
                            ""width"" : 2911
                         }
                      ],
                      ""place_id"" : ""ChIJN1t_tDeuEmsRUsoyG83frY4"",
                      ""rating"" : 4.5,
                      ""reference"" : ""CmRaAAAAt6r4_ib5k-J-IIq5ZNnUa8kv8dYXkTTKSvGYal4Ahpw6FWQzOrDyr_bI7Jh0s1KgFLrnrofwxM3u2mJWoE5xknXbSlSvUVrEhhSFb5Gx5N64NGSWrC-iICGDyE2_wVezEhA-GBrpXNjWIUfGra9hB_H9GhRV8Wo9Qpe4428vSE845fejA7SpIA"",
                      ""reviews"" : [
                         {
                            ""aspects"" : [
                               {
                                  ""rating"" : 3,
                                  ""type"" : ""overall""
                               }
                            ],
                            ""author_name"" : ""Justine OBRIEN"",
                            ""author_url"" : ""https://plus.google.com/104177669626132953795"",
                            ""language"" : ""en"",
                            ""profile_photo_url"" : ""//lh6.googleusercontent.com/-s6AzNe5Qcco/AAAAAAAAAAI/AAAAAAAAFTE/NvVzCuI-jMI/photo.jpg"",
                            ""rating"" : 5,
                            ""text"" : ""Google Sydney is located on Darling Island on the glorious Sydney Harbour in a prime position easy to get to for staff and visitors. The reception has an excellent fresh living wall and the staff are welcoming, pleasant and friendly, ready to assist you with bountiful information for all inquiries. All ready to *do the right thing* Always helping *Go Get IT*, the right information to *Gather IT*, from all the right places plus *Give IT* at all the right times to all the right people! \nGo Get Gather Give Google excellence personified at Google Sydney! Thanks Google Sydney!"",
                            ""time"" : 1451482843
                         },
                         {
                            ""aspects"" : [
                               {
                                  ""rating"" : 3,
                                  ""type"" : ""overall""
                               }
                            ],
                            ""author_name"" : ""Mark Vozzo"",
                            ""author_url"" : ""https://plus.google.com/100482974853389838438"",
                            ""language"" : ""en"",
                            ""profile_photo_url"" : ""//lh3.googleusercontent.com/-95MwIKSvGhw/AAAAAAAAAAI/AAAAAAAAMI0/SDn7W1qL2nI/photo.jpg"",
                            ""rating"" : 5,
                            ""text"" : ""The Google Office is an amazing space inside this building. You are great with an awesome reception area on level 5 and if you're lucky you'll get to meet Basil the parrot (owned by the super friendly receptionist Luke). It's a great office space with nice meeting rooms. Google has very friendly baristas on Level 4 serving coffees from 8.30am to 3.30pm to Googlers and their visitors. The cafe on Level 6 (top floor) serves great breakfast, lunch and dinner with healthy salads, fresh squeeze-your-own juices and the best thing is a spectacular view of the Sydney Harbor Bridge in the distance."",
                            ""time"" : 1455632820
                         },
                         {
                            ""aspects"" : [
                               {
                                  ""rating"" : 3,
                                  ""type"" : ""overall""
                               }
                            ],
                            ""author_name"" : ""Wii Lu"",
                            ""author_url"" : ""https://plus.google.com/112352616160601092271"",
                            ""language"" : ""en"",
                            ""profile_photo_url"" : ""//lh5.googleusercontent.com/-RLMS0wL2avs/AAAAAAAAAAI/AAAAAAAAtLU/dRAbmewWhXs/photo.jpg"",
                            ""rating"" : 5,
                            ""text"" : ""One of my favourite Google offices! It overlooks the Darling harbour, and you can have the best lunch overlooking the harbour. The office is colourful, fun and everyone is friendly. "",
                            ""time"" : 1456171339
                         },
                         {
                            ""aspects"" : [
                               {
                                  ""rating"" : 3,
                                  ""type"" : ""overall""
                               }
                            ],
                            ""author_name"" : ""Jan Gemrich"",
                            ""author_url"" : ""https://plus.google.com/104922001665742539850"",
                            ""language"" : ""en"",
                            ""profile_photo_url"" : ""//lh3.googleusercontent.com/-SsHpPJdyPnI/AAAAAAAAAAI/AAAAAAABUWQ/t_D7jU7enwA/photo.jpg"",
                            ""rating"" : 5,
                            ""text"" : ""If your lucky your will meet talking parrot at the reception. If you have time, get a coffee from 4th barista Tanya"",
                            ""time"" : 1455988590
                         },
                         {
                            ""aspects"" : [
                               {
                                  ""rating"" : 0,
                                  ""type"" : ""overall""
                               }
                            ],
                            ""author_name"" : ""Karl Jo"",
                            ""author_url"" : ""https://plus.google.com/114746545364501357372"",
                            ""language"" : ""en"",
                            ""rating"" : 1,
                            ""text"" : ""It is really disappointing when you phone google for assistance with their online reviews, due to defamation and they send you in circles and never give you an answer. Really disappointing "",
                            ""time"" : 1456990769
                         }
                      ],
                      ""scope"" : ""GOOGLE"",
                      ""types"" : [ ""point_of_interest"", ""establishment"" ],
                      ""url"" : ""https://maps.google.com/?cid=10281119596374313554"",
                      ""user_ratings_total"" : 150,
                      ""utc_offset"" : 600,
                      ""vicinity"" : ""5 48 Pirrama Road, Pyrmont"",
                      ""website"" : ""https://www.google.com.au/about/careers/locations/sydney/""
                   },
                   ""status"" : ""OK""
                }";

                // Arrange mocks for response data
                var webMocks = client.ArrangeWebResponseResultMocks(
                    new MockResultWebResponseConfig(responseData));

                // Make client call
                var details = client.Places.GetPlaceDetails("ChIJN1t_tDeuEmsRUsoyG83frY4");

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/place/details/json?" +
                    "placeid=ChIJN1t_tDeuEmsRUsoyG83frY4");

                // Data
                details.IsValid.Should().BeTrue();
                details.HasErrorMessage.Should().BeFalse();

                details.Result.AddressComponents.Should().NotBeNullOrEmpty();
                details.Result.AddressComponents.Count.Should().Be(7);
                details.Result.AddressComponents[2].ShortName = "Pirrama Rd";
                details.Result.AddressComponents[2].LongName = "Pirrama Road";
                details.Result.AddressComponents[2].Types.Should()
                    .Contain(new[] {PlaceResultTypeEnum.Route});
                details.Result.AddressComponents[3].Types.Should()
                    .Contain(new[] {PlaceResultTypeEnum.Locality, PlaceResultTypeEnum.Political});

                details.Result.Icon.Should().Be("https://maps.gstatic.com/mapfiles/place_api/icons/generic_business-71.png");
                details.Result.InternationalPhoneNumber.Should().Be("+61 2 9374 4000");
                details.Result.FormattedAddress.Should().Be("5, 48 Pirrama Rd, Pyrmont NSW 2009, Australia");
                details.Result.FormattedPhoneNumber.Should().Be("(02) 9374 4000");
                details.Result.Name.Should().Be("Google");
                details.Result.UserRatingsTotal.Should().Be(150);
                details.Result.UTCOffset.Should().Be(600);
                details.Result.PlaceId.Should().Be("ChIJN1t_tDeuEmsRUsoyG83frY4");
                details.Result.Rating.Should().Be(4.5);
                details.Result.Scope.Should().NotBeNull();
                details.Result.Scope.Should().Be(PlaceScopeEnum.Google);
                details.Result.Types.Should().NotBeNullOrEmpty();
                details.Result.Types.Should().Contain(new[] {PlaceResultTypeEnum.PointOfInterest, PlaceResultTypeEnum.Establishment});
                details.Result.Url.Should().StartWith("https://maps.google.com");
                details.Result.Vicinity.Should().EndWith("Pyrmont");
                details.Result.Website.Should().EndWith("/sydney/");

                details.Result.Photos.Should().NotBeNullOrEmpty();
                details.Result.Photos.Count.Should().Be(10);
                details.Result.Photos[9].Height.Should().Be(2184);
                details.Result.Photos[9].Width.Should().Be(2911);
                details.Result.Photos[9].HTMLAttributions.Should().NotBeNullOrEmpty();
                details.Result.Photos[9].HTMLAttributions.Count.Should().Be(1);
                details.Result.Photos[9].HTMLAttributions[0].Should().NotBeEmpty();

                details.Result.Geometry.Should().NotBeNull();
                details.Result.Geometry.AccessPoints.Should().NotBeNullOrEmpty();
                details.Result.Geometry.AccessPoints[0].Location.Should().NotBeNull();
                details.Result.Geometry.AccessPoints[0].Location.Latitude = -33.8668233;
                details.Result.Geometry.AccessPoints[0].Location.Longitude = 151.195423;
                details.Result.Geometry.AccessPoints[0].TravelModes.Should().NotBeNullOrEmpty();
                details.Result.Geometry.AccessPoints[0].TravelModes.Should().Contain(
                    new[]
                    {
                        TransportationModeEnum.Bicycling, TransportationModeEnum.Driving,
                        TransportationModeEnum.Transit, TransportationModeEnum.Walking,
                    });

                details.Result.Reviews.Should().NotBeNullOrEmpty();
                details.Result.Reviews.Count.Should().Be(5);
                details.Result.Reviews[2].Aspects.Should().NotBeNullOrEmpty();
                details.Result.Reviews[2].Aspects.Count.Should().Be(1);
                details.Result.Reviews[2].Aspects[0].Type.Should().Be(AspectRatingTypeEnum.Overall);
                details.Result.Reviews[2].Aspects[0].Rating.Should().Be(3);
                details.Result.Reviews[2].AuthorName.Should().StartWith("Wii");
                details.Result.Reviews[2].AuthorUrl.Should().EndWith("1092271");
                details.Result.Reviews[2].ProfilePhotoUrl.Should().EndWith("/photo.jpg");
                details.Result.Reviews[2].Language.Should().Be("en");
                details.Result.Reviews[2].Rating.Should().Be(5);
                details.Result.Reviews[2].Text.Should().StartWith("One of my favourite Google offices!");
                details.Result.Reviews[2].Time.Should().Be(new DateTime(2016, 2, 22, 20, 2, 19, DateTimeKind.Utc));

                // Results
                details.Result.Should().NotBeNull();

            }

        }

        /// <summary>
        /// Test autocomplete response
        /// </summary>
        [TestMethod]
        public void TestAutoCompleteResponse()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Set response data
                var responseData = @"{
                   ""predictions"" : [
                      {
                         ""description"" : ""Amoeba Music, Haight Street, San Francisco, CA, United States"",
                         ""id"" : ""2358a6f0884520d5b51391c0214b682a20921f0b"",
                         ""matched_substrings"" : [
                            {
                               ""length"" : 6,
                               ""offset"" : 0
                            }
                         ],
                         ""place_id"" : ""ChIJ5YQQf1GHhYARPKG7WLIaOko"",
                         ""reference"" : ""CoQBdQAAALfzw0-552_99m7V3E3rlXRc_PuCMgVbnHNPI96B-KRa6EJYxJ-Kl9bVD1u995PckjGg3JZK2HNG59l1TxluyrNk7jvjMjjjJ_53-1KgyDSXiw0n6CG4DAH4kJM7UAVxMQyjBnVySwIR9-HFuDl6RIDlFGDdBYnSpxJvrhPwzRPYEhBv0_LCKdQi3JGmIpY7ez-BGhQz08xBa7GynWg7j1P3igrWo3DmhA"",
                         ""terms"" : [
                            {
                               ""offset"" : 0,
                               ""value"" : ""Amoeba Music""
                            },
                            {
                               ""offset"" : 14,
                               ""value"" : ""Haight Street""
                            },
                            {
                               ""offset"" : 29,
                               ""value"" : ""San Francisco""
                            },
                            {
                               ""offset"" : 44,
                               ""value"" : ""CA""
                            },
                            {
                               ""offset"" : 48,
                               ""value"" : ""United States""
                            }
                         ],
                         ""types"" : [ ""establishment"" ]
                      },
                      {
                         ""description"" : ""Amoeba Music, Telegraph Avenue, Berkeley, CA, United States"",
                         ""id"" : ""8a40726d6983c2b9f922b0eb72175351527f8f52"",
                         ""matched_substrings"" : [
                            {
                               ""length"" : 6,
                               ""offset"" : 0
                            }
                         ],
                         ""place_id"" : ""ChIJr7uwwy58hYARBY-e7-QVwqw"",
                         ""reference"" : ""CoQBdAAAANeuhj14xBUGW_PtSH6OK6wQvfUaNRT6iT6H-NPrDARYSaRqX8PcGCmBELKKbwdcrAZ2MHHWi4I4YZYTRtegAOssIXctc2It2Wsdhv7EJTW1W1NvjwVGgIxp1RGMzX6TJa9Yp94wTqlM1jRSq2axIuQG94wxY-I2Fg6DXglMIpxuEhBb3pXLKHp21UFO_doKiYyrGhSEuLBOYbA0HCtvDa5_B31v98WElg"",
                         ""terms"" : [
                            {
                               ""offset"" : 0,
                               ""value"" : ""Amoeba Music""
                            },
                            {
                               ""offset"" : 14,
                               ""value"" : ""Telegraph Avenue""
                            },
                            {
                               ""offset"" : 32,
                               ""value"" : ""Berkeley""
                            },
                            {
                               ""offset"" : 42,
                               ""value"" : ""CA""
                            },
                            {
                               ""offset"" : 46,
                               ""value"" : ""United States""
                            }
                         ],
                         ""types"" : [ ""establishment"" ]
                      }
                   ],
                   ""status"" : ""OK""
                }";

                // Arrange mocks for response data
                var webMocks = client.ArrangeWebResponseResultMocks(
                    new MockResultWebResponseConfig(responseData));

                // Make client call
                var response = client.Places.AutoComplete(
                    "Amoeba",
                    types: new[] {PlaceSearchTypeEnum.ElectronicsStore.GetSerializationName()},
                    location: new GeoCoordinatesLocation(37.76999, -122.44696),
                    radius: 500);

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/place/autocomplete/json?" +
                    "input=Amoeba&location=37.76999%2C-122.44696&radius=500" +
                    "&types=electronics_store");

                // Data
                response.IsValid.Should().BeTrue();
                response.HasErrorMessage.Should().BeFalse();

                response.Predictions.Should().NotBeNullOrEmpty();
                response.Predictions.Count.Should().Be(2);
                response.Predictions[1].Description.Should().StartWith("Amoeba");
                response.Predictions[1].PlaceId.Should().Be("ChIJr7uwwy58hYARBY-e7-QVwqw");

                response.Predictions[1].MatchedSubstrings.Should().NotBeNullOrEmpty();
                response.Predictions[1].MatchedSubstrings.Count.Should().Be(1);
                response.Predictions[1].MatchedSubstrings[0].Length.Should().Be(6);
                response.Predictions[1].MatchedSubstrings[0].Offset.Should().Be(0);

                response.Predictions[1].Terms.Should().NotBeNullOrEmpty();
                response.Predictions[1].Terms.Count.Should().Be(5);
                response.Predictions[1].Terms[3].Offset.Should().Be(42);
                response.Predictions[1].Terms[3].Value.Should().Be("CA");

                response.Predictions[1].Types.Should().NotBeNullOrEmpty();
                response.Predictions[1].Types.Count.Should().Be(1);
                response.Predictions[1].Types.Should().Contain(PlaceResultTypeEnum.Establishment);

            }

        }

        #endregion

    }
}