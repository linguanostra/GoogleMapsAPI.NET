using GoogleMapsAPI.NET.Common;

namespace GoogleMapsAPI.NET.Requests
{

    /// <summary>
    /// Request config
    /// </summary>
    public class RequestConfig
    {

        #region Properties

        /// <summary>
        /// Headers
        /// </summary>
        public RequestHeaders Headers { get; }

        /// <summary>
        /// Timeout
        /// </summary>
        public int Timeout { get; set; } = 0;

        /// <summary>
        /// Verify SSL certificates
        /// </summary>
        public bool VerifySSLCerts { get; set; } = true;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new instance
        /// </summary>
        public RequestConfig()
        {
            Headers = new RequestHeaders
            {
                UserAgent = Globals.UserAgent
            };
        }

        #endregion
         
    }
}