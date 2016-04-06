using System;
using System.IO;
using System.Net;

namespace GoogleMapsAPI.NET.Web.Extensions
{

    /// <summary>
    /// Http Web Response extensions
    /// </summary>
    public static class HttpWebResponseExtensions
    {

        #region Extension methods

        /// <summary>
        /// Get response content
        /// </summary>
        /// <param name="response">Response</param>
        /// <returns>Content</returns>
        public static string GetResponseContent(this HttpWebResponse response)
        {

            // Ensure that a response is defined
            if (response == null) return null;

            // Get response stream
            using (var responseStream = response.GetResponseStream())
            {

                // Ensure it's not null
                if (responseStream == null) throw new NullReferenceException();

                // Read stream
                using (var sr = new StreamReader(responseStream))
                {

                    // Get content
                    var responseContent = sr.ReadToEnd();

                    // Return it
                    return responseContent;

                }

            }

        }

        /// <summary>
        /// Get response bytes
        /// </summary>
        /// <param name="response">Response</param>
        /// <returns>Content</returns>
        public static byte[] GetResponseBytes(this HttpWebResponse response)
        {

            // Ensure that a response is defined
            if (response == null) return null;

            // Get response stream
            using (var responseStream = response.GetResponseStream())
            {

                // Ensure it's not null
                if (responseStream == null) throw new NullReferenceException();

                // Init target stream
                using (var ms = new MemoryStream())
                {

                    // Copy it to memory
                    responseStream.CopyTo(ms);
                    
                    // Return bytes
                    return ms.ToArray();

                }                

            }

        }

        #endregion

    }
}