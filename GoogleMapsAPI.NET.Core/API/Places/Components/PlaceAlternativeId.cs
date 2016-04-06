using System.Runtime.Serialization;
using GoogleMapsAPI.NET.API.Places.Enums;

namespace GoogleMapsAPI.NET.API.Places.Components
{

    /// <summary>
    /// Place alternative id component
    /// </summary>
    [DataContract]
    public class PlaceAlternativeId
    {

        #region Properties

        /// <summary>
        /// Place Id
        /// </summary>
        [DataMember(Name = "place_id")]
        public string PlaceId { get; set; }

        /// <summary>
        /// Scope
        /// </summary>
        [DataMember(Name = "scope")]
        public PlaceScopeEnum Scope { get; set; } 

        #endregion
         
    }
}