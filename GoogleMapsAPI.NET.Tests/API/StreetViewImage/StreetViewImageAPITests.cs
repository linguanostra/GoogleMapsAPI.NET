using System.Drawing.Imaging;
using FluentAssertions;
using GoogleMapsAPI.NET.API.Common.Components.Locations;
using GoogleMapsAPI.NET.Tests.API.Common;
using GoogleMapsAPI.NET.Tests.API.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleMapsAPI.NET.Tests.API.StreetViewImage
{

    /// <summary>
    /// Street view image API tests
    /// </summary>
    [TestClass]
    public class StreetViewImageAPITests : APITests
    {

        #region Test methods

        /// <summary>
        /// Test get street view image
        /// </summary>
        [TestMethod]
        public void TestGetStreetViewImage()
        {

            // Get mocked client
            using (var client = GetMockedAPIClient())
            {

                // Arrange mocks for image
                var webMocks = client.ArrangeStreetViewImageWebResponseMocks();

                // Make client call
                var result = client.StreetViewImage.GetStreetViewImage(
                    new GeoCoordinatesLocation(46.414382, 10.013988),
                    width: 600, 
                    height: 300,
                    heading: 151.780,
                    pitch: -0.76);

                // Assertions
                webMocks.WebRequestUtil.AssertGetWasCalledOnceWithUrl(
                    "https://maps.googleapis.com/maps/api/streetview?" +
                    "location=46.414382%2C10.013988&size=600x300" +
                    "&heading=151.78&pitch=-0.76");

                // Image data
                result.Content.Should().NotBeNullOrEmpty();

            }

        } 

        #endregion
         
    }
}