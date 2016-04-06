using System;
using GoogleMapsAPI.NET.Requests;

namespace GoogleMapsAPI.NET.API.Client
{
    /// <summary>
    /// Google Maps API web services client configuration
    /// </summary>
    public class MapsAPIClientConfig
    {

        #region Properties

        /// <summary>
        /// Timeout (In seconds)
        /// </summary>
        public int Timeout { get; set; }

        /// <summary>
        /// Connection timeout (In seconds)
        /// </summary>
        public int ConnectTimeout { get; set; }

        /// <summary>
        /// Read timeout (In seconds)
        /// </summary>
        public int ReadTimeout { get; set; }

        /// <summary>
        /// Retry timeout (In seconds)
        /// </summary>
        public int RetryTimeout { get; set; } = 60;

        /// <summary>
        /// Common request configuration
        /// </summary>
        public RequestConfig RequestConfig { get; set; }

        /// <summary>
        /// Queries per second limit
        /// </summary>
        public int QueriesPerSecond { get; set; } = 10;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new instance
        /// </summary>
        public MapsAPIClientConfig()
        {
            RequestConfig = new RequestConfig();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initialize config
        /// </summary>
        public void Init()
        {

            // Check timeouts
            if (Timeout > 0 && (ConnectTimeout > 0 || ReadTimeout > 0))
            {
                throw new ArgumentException("Specify either timeout, or connect_timeout and read_timeout");
            }

            // Adjust timeout
            if (ConnectTimeout > 0 && ReadTimeout > 0)
            {
                Timeout = ConnectTimeout + ReadTimeout;
            }

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Get default config
        /// </summary>
        /// <returns>Result</returns>
        public static MapsAPIClientConfig Default()
        {

            return new MapsAPIClientConfig();
            
        }

        #endregion

    }
}