using System.IO;
using System.Text;

namespace GoogleMapsAPI.NET.API.Common.Responses
{
    /// <summary>
    /// Content text response
    /// </summary>
    public abstract class ContentTextResponse : ContentResponse<string>
    {

        #region Overrides

        /// <summary>
        /// Save content
        /// </summary>
        /// <param name="path">Path</param>
        public override void SaveContent(string path)
        {

            // Save with default encoding
            SaveContent(path, Encoding.Default);

        }

        #endregion

        #region Methods

        /// <summary>
        /// Save content with encoding
        /// </summary>
        /// <param name="path">Path</param>
        /// <param name="encoding">Encoding</param>
        public void SaveContent(string path, Encoding encoding)
        {

            File.WriteAllText(path, Content, encoding);

        } 

        #endregion
    }

}