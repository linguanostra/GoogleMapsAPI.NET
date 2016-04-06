using System;

namespace GoogleMapsAPI.NET.Exceptions
{

    /// <summary>
    /// Transport error exception
    /// </summary>
    public class TransportErrorException : Exception
    {

        #region Properties

        /// <summary>
        /// Source exception
        /// </summary>
        public Exception SourceException { get; } 

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new instance
        /// </summary>
        public TransportErrorException()
        {
        }

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="sourceException">Source exception</param>
        public TransportErrorException(Exception sourceException)
        {
            SourceException = sourceException;
        }

        #endregion
    }

}