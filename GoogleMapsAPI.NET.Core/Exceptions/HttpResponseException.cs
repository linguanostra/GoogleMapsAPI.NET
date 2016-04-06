using System;
using System.Net;

namespace GoogleMapsAPI.NET.Exceptions
{

    /// <summary>
    /// Http response exception
    /// </summary>
    public class HttpResponseException : Exception
    {

        #region Properties

        /// <summary>
        /// Response
        /// </summary>
        public HttpWebResponse Response { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="response">Response</param>
        public HttpResponseException(HttpWebResponse response)
        {
            Response = response;
        }

        #endregion

    }
}