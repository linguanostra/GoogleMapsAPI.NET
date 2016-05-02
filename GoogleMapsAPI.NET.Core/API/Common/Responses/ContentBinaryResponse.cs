using System.IO;

namespace GoogleMapsAPI.NET.API.Common.Responses
{
    /// <summary>
    /// Content binary response
    /// </summary>
    public abstract class ContentBinaryResponse : ContentResponse<byte[]>
    {

        #region Constructors

        /// <summary>
        /// Create a new instance
        /// </summary>
        protected ContentBinaryResponse()
        {
        }

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="content">Content bytes</param>
        protected ContentBinaryResponse(byte[] content)
        {

            // Set content
            SetContent(content);

        }

        #endregion

        #region Overrides

        /// <summary>
        /// Save content
        /// </summary>
        /// <param name="path">Path</param>
        public override void SaveContent(string path)
        {

            File.WriteAllBytes(path, Content);

        }

        #endregion

    }

}