using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleMapsAPI.NET.API.Common.Responses;
using GoogleMapsAPI.NET.API.Places.Components;

namespace GoogleMapsAPI.NET.API.Places.Responses
{
    /// <summary>
    /// Places autocomplete response
    /// </summary>
    [DataContract]
    public class PlaceAutocompleteResponse : APIResponse
    {

        #region Properties

        /// <summary>
        /// Predictions
        /// </summary>
        [DataMember(Name = "predictions")]
        public List<PlacePrediction> Predictions { get; set; }

        #endregion

    }
}