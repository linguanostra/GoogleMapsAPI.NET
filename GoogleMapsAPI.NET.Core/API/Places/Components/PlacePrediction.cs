using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleMapsAPI.NET.API.Places.Enums;

namespace GoogleMapsAPI.NET.API.Places.Components
{

    /// <summary>
    /// Place prediction component
    /// </summary>
    [DataContract]
    public class PlacePrediction
    {

        #region Properties

        /// <summary>
        /// Human-readable name for the returned result.
        /// </summary>
        [DataMember(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Textual identifier that uniquely identifies a place
        /// </summary>
        [DataMember(Name = "place_id")]
        public string PlaceId { get; set; }

        /// <summary>
        /// A unique token that you can use to retrieve additional information about this place 
        /// </summary>
        [DataMember(Name = "reference")]
        [Obsolete]
        public string Reference { get; set; }

        /// <summary>
        /// A unique stable identifier denoting this place
        /// </summary>
        [DataMember(Name = "id")]
        [Obsolete]
        public string Id { get; set; }

        /// <summary>
        /// Terms identifying each section of the returned description
        /// </summary>
        [DataMember(Name = "terms")]
        public List<PlacePredictionTerm> Terms { get; set; }

        /// <summary>
        /// Types that apply to this place.
        /// </summary>
        [DataMember(Name = "types")]
        public List<PlaceResultTypeEnum> Types { get; set; }

        /// <summary>
        /// Describe the location of the entered term in the prediction result text, so that 
        /// the term can be highlighted if desired.
        /// </summary>
        [DataMember(Name = "matched_substrings")]
        public List<PlacePredictionMatchedSubstring> MatchedSubstrings { get; set; }

        #endregion

    }
}