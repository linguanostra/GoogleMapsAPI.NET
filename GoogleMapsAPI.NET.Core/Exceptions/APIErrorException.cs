using System;

namespace GoogleMapsAPI.NET.Exceptions
{

    /// <summary>
    /// API error exception
    /// </summary>
    public class APIErrorException : Exception
    {

        #region Properties

        /// <summary>
        /// Status
        /// </summary>
        public string Status { get; } 

        /// <summary>
        /// Error message
        /// </summary>
        public string ErrorMessage { get; } 

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="status">Status</param>
        public APIErrorException(string status)
        {
            Status = status;
        }

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="status">Status</param>
        /// <param name="errorMessage">Error message</param>
        public APIErrorException(string status, string errorMessage)
        {
            Status = status;
            ErrorMessage = errorMessage;
        }

        #endregion
         
    }
}