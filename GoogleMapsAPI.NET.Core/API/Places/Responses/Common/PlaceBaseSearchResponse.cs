using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleMapsAPI.NET.API.Common.Responses;

namespace GoogleMapsAPI.NET.API.Places.Responses.Common
{
    /// <summary>
    /// Place base search response
    /// </summary>
    /// <typeparam name="TResult">Result type</typeparam>
    [DataContract]
    public abstract class PlaceBaseSearchResponse<TResult> : APIMultipleResultsResponse<TResult>
    {

        #region Properties

        /// <summary>
        /// Set of attributions about this listing which must be displayed to the user.
        /// </summary>
        [DataMember(Name = "html_attributions")]
        public List<string> HTMLAttributions { get; set; }

        /// <summary>
        /// Token that can be used to return up to 20 additional results.
        /// </summary>
        [DataMember(Name = "next_page_token")]
        public string NextPageToken { get; set; }

        #endregion

    }
}