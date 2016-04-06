using System.Runtime.Serialization;

namespace GoogleMapsAPI.NET.API.Places.Components
{
    /// <summary>
    /// Place prediction matched substring component
    /// </summary>
    [DataContract]
    public class PlacePredictionMatchedSubstring
    {

        #region Properties

        /// <summary>
        /// The start position of this matched substring
        /// </summary>
        [DataMember(Name = "offset")]
        public int Offset { get; set; }

        /// <summary>
        /// The length of this matched substring
        /// </summary>
        [DataMember(Name = "length")]
        public int Length { get; set; }

        #endregion

    }
}