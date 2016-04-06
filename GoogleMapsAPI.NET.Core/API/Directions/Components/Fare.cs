using System.Runtime.Serialization;

namespace GoogleMapsAPI.NET.API.Directions.Components
{

    /// <summary>
    /// Fare component
    /// </summary>
    [DataContract]
    public class Fare
    {

        #region Properties

        /// <summary>
        /// An ISO 4217 currency code indicating the currency that the amount is expressed in.
        /// </summary>
        [DataMember(Name = "currency")]
        public string Currency { get; set; }

        /// <summary>
        /// The total fare amount
        /// </summary>
        [DataMember(Name = "value")]
        public string Value { get; set; }

        /// <summary>
        /// The total fare amount, formatted in the requested language.
        /// </summary>
        [DataMember(Name = "text")]
        public string Text { get; set; } 

        #endregion
         
    }
}