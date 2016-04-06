using System.Runtime.Serialization;

namespace GoogleMapsAPI.NET.API.Common.Responses
{
    /// <summary>
    /// API single result response
    /// </summary>
    /// <typeparam name="TResult">Result type</typeparam>
    [DataContract]
    public abstract class APISingleResultResponse<TResult> : APIResponse
    {

        #region Properties

        /// <summary>
        /// Result
        /// </summary>
        [DataMember(Name = "result")]
        public TResult Result { get; set; }

        #endregion

    }
}