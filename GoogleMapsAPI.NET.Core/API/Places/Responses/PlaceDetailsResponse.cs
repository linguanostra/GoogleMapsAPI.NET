using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleMapsAPI.NET.API.Common.Responses;
using GoogleMapsAPI.NET.API.Places.Results;

namespace GoogleMapsAPI.NET.API.Places.Responses
{

    /// <summary>
    /// Place details response
    /// </summary>
    [DataContract]
    public class PlaceDetailsResponse : APISingleResultResponse<PlaceDetailsResult>
    {

        #region Properties

        /// <summary>
        /// Set of attributions about this listing which must be displayed to the user.
        /// </summary>
        [DataMember(Name = "html_attributions")]
        public List<string> HTMLAttributions { get; set; }

        #endregion
    }
}