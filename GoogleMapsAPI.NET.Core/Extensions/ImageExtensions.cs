using System.Drawing;

namespace GoogleMapsAPI.NET.Extensions
{

    /// <summary>
    /// Image extensions
    /// </summary>
    public static class ImageExtensions
    {

        #region Extension methods

        /// <summary>
        /// Convert image to bytes
        /// </summary>
        /// <param name="img">Image</param>
        /// <returns>Result bytes</returns>
        public static byte[] ImageToBytes(this Image img)
        {
            var converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        #endregion

    }
}