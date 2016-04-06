using System;
using System.Runtime.Serialization;
using GoogleMapsAPI.NET.API.Places.Components;

namespace GoogleMapsAPI.NET.API.Places.Results
{
    /// <summary>
    /// Place radar search result component
    /// </summary>
    [DataContract]
    public class PlaceRadarSearchResult
    {

        #region Properties

        /// <summary>
        /// geometry information about the result
        /// </summary>
        [DataMember(Name = "geometry")]
        public PlaceGeometry Geometry { get; set; }

        /// <summary>
        /// A unique stable identifier denoting this place.
        /// </summary>
        [DataMember(Name = "place_id")]
        public string PlaceId { get; set; }

        /// <summary>
        /// A unique token that you can use to retrieve additional information about this place 
        /// </summary>
        [DataMember(Name = "reference")]
        [Obsolete]
        public string Reference { get; set; }        

        #endregion

    }
}