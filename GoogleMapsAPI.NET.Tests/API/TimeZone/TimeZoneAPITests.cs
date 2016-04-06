using System;
using FluentAssertions;
using GoogleMapsAPI.NET.API.Common.Components.Locations;
using GoogleMapsAPI.NET.Tests.API.Common;
using GoogleMapsAPI.NET.Tests.API.Extensions;
using GoogleMapsAPI.NET.Tests.API.Utils.MockConfig;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleMapsAPI.NET.Tests.API.TimeZone
{

    /// <summary>
    /// TimeZone API tests
    /// </summary>
    [TestClass]
    public class TimeZoneAPITests : APITests
    {

        #region Static methods

        /// <summary>
        /// Test Log Angeles with timestamp
        /// </summary>
        [TestMethod]
        public void TestLosAngelesWithTimestamp()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for result
                var webMocks = client.ArrangeWebResponseResultMocks(
                    new MockResultWebResponseConfig(@"{
                       ""dstOffset"" : 0,
                       ""rawOffset"" : -28800,
                       ""status"" : ""OK"",
                       ""timeZoneId"" : ""America/Los_Angeles"",
                       ""timeZoneName"" : ""Pacific Standard Time""
                    }"));

                // Make client call
                var result = client.TimeZone.GetTimeZone(
                    new GeoCoordinatesLocation(39.6034810, -119.6822510), 1331766000);

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/timezone/json?" +
                    "location=39.603481%2C-119.682251&timestamp=1331766000");

                // Data
                result.DstOffset.Should().Be(0);
                result.RawOffset.Should().Be(-28800);
                result.TimeZoneId.Should().Be("America/Los_Angeles");
                result.TimeZoneName.Should().Be("Pacific Standard Time");

            }

        }

        /// <summary>
        /// Test Log Angeles with date
        /// </summary>
        [TestMethod]
        public void TestLosAngelesWithDate()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for result
                var webMocks = client.ArrangeWebResponseResultMocks(
                    new MockResultWebResponseConfig(@"{
                       ""dstOffset"" : 0,
                       ""rawOffset"" : -28800,
                       ""status"" : ""OK"",
                       ""timeZoneId"" : ""America/Los_Angeles"",
                       ""timeZoneName"" : ""Pacific Standard Time""
                    }"));

                // Make client call
                var result = client.TimeZone.GetTimeZone(
                    new GeoCoordinatesLocation(39.6034810, -119.6822510), 
                    new DateTime(2012,3,14,23,0,0,DateTimeKind.Utc));

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/timezone/json?" +
                    "location=39.603481%2C-119.682251&timestamp=1331766000");

                // Data
                result.DstOffset.Should().Be(0);
                result.RawOffset.Should().Be(-28800);
                result.TimeZoneId.Should().Be("America/Los_Angeles");
                result.TimeZoneName.Should().Be("Pacific Standard Time");

            }

        }

        /// <summary>
        /// Test time zone response data
        /// </summary>
        [TestMethod]
        public void TestTimeZoneResponseData()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Set response data
                var responseData = @"{
                   ""dstOffset"" : 3600,
                   ""rawOffset"" : -28800,
                   ""status"" : ""OK"",
                   ""timeZoneId"" : ""America/Los_Angeles"",
                   ""timeZoneName"" : ""Pacific Daylight Time""}";

                // Arrange mocks for response data
                var webMocks = client.ArrangeWebResponseResultMocks(
                    new MockResultWebResponseConfig(responseData));

                // Make client call
                var timeData = client.TimeZone.GetTimeZone(
                    new GeoCoordinatesLocation(39.6034810, -119.6822510),
                    1331766000);

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/timezone/json?" +
                    "location=39.603481%2C-119.682251&timestamp=1331766000");

                // Data
                timeData.IsValid.Should().BeTrue();
                timeData.HasErrorMessage.Should().BeFalse();

                timeData.DstOffset.Should().Be(3600);
                timeData.RawOffset.Should().Be(-28800);
                timeData.TimeZoneId.Should().Be("America/Los_Angeles");
                timeData.TimeZoneName.Should().Be("Pacific Daylight Time");

            }

        }

        #endregion

    }
}