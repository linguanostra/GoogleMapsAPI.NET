using System;

namespace GoogleMapsAPI.NET.API.Common.Responses
{
    /// <summary>
    /// Response
    /// </summary>
    public abstract class Response : IDisposable
    {

        #region IDisposable members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public virtual void Dispose()
        {
        }

        #endregion
    }
}