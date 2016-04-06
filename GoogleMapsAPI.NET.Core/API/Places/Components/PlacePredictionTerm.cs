using System.Runtime.Serialization;

namespace GoogleMapsAPI.NET.API.Places.Components
{
    /// <summary>
    /// Place prediction term component
    /// </summary>
    [DataContract]
    public class PlacePredictionTerm
    {

        #region Properties

        /// <summary>
        /// The text of the term
        /// </summary>
        [DataMember(Name = "value")]
        public string Value { get; set; }

        /// <summary>
        /// The start position of this term in the description, measured in Unicode characters.
        /// </summary>
        [DataMember(Name = "offset")]
        public int Offset { get; set; } 

        #endregion
         
    }
}