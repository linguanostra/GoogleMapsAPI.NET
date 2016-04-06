using System;
using GoogleMapsAPI.NET.API.Client;

namespace GoogleMapsAPI.NET.API.Common
{

    /// <summary>
    /// Maps API
    /// </summary>
    public abstract class MapsAPI : IDisposable
    {

        #region Properties

        /// <summary>
        /// API client
        /// </summary>
        protected MapsAPIClient Client { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="client">API client</param>
        protected MapsAPI(MapsAPIClient client)
        {
            Client = client;
        }

        #endregion
        
        #region IDisposable members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public virtual void Dispose()
        {
            
            // Dispose of client
            Client?.Dispose();

        }

        #endregion

    }

}