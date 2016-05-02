using GoogleMapsAPI.NET.API.Common.Responses;

namespace GoogleMapsAPI.NET.API.Places.Responses
{

    /// <summary>
    /// Place photo response
    /// </summary>
    public class PlacePhotoResponse : ContentBinaryResponse
    {

        #region Constructors

        /// <summary>
        /// Create a new instance
        /// </summary>
        public PlacePhotoResponse()
        {
        }

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="content">Content bytes</param>
        public PlacePhotoResponse(byte[] content) : base(content)
        {
        }

        #endregion

    }
}