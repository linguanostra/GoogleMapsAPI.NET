using System.Runtime.Serialization;

namespace GoogleMapsAPI.NET.API.Common.Responses
{
    /// <summary>
    /// API Version 1 response
    /// </summary>
    [DataContract]
    public abstract class APIV1Response : APIResponse
    {

        #region Constructors

        /// <summary>
        /// Create a new instance
        /// </summary>
        protected APIV1Response()
        {

            // Always set status as OK since it's Version 1 of the API
            Status = "OK";

        }

        #endregion

    }
}