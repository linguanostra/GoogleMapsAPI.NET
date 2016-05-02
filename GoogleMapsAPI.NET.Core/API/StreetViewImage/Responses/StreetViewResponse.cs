using GoogleMapsAPI.NET.API.Common.Responses;

namespace GoogleMapsAPI.NET.API.StreetViewImage.Responses
{

    /// <summary>
    /// Street view response
    /// </summary>
    public class StreetViewResponse : ContentBinaryResponse
    {

        #region Constructors

        /// <summary>
        /// Create a new instance
        /// </summary>
        public StreetViewResponse()
        {
        }

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="content">Content bytes</param>
        public StreetViewResponse(byte[] content) : base(content)
        {
        }

        #endregion

    }
}