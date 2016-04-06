using GoogleMapsAPI.NET.Extensions;
using GoogleMapsAPI.NET.Tests.Properties;

namespace GoogleMapsAPI.NET.Tests.API.Utils.MockConfig.Images
{
    /// <summary>
    /// Config for mocking place image web response
    /// </summary>
    public class MockPlaceImageWebResponseConfig : MockImageWebResponseConfig
    {

        #region Overrides

        /// <summary>
        /// Get image bytes
        /// </summary>
        /// <returns>Result image bytes</returns>
        public override byte[] GetImageBytes()
        {

            return Resources.PlacePhoto.ImageToBytes();

        }

        #endregion

    }
}