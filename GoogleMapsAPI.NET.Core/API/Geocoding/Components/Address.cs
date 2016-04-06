using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleMapsAPI.NET.API.Places.Enums;

namespace GoogleMapsAPI.NET.API.Geocoding.Components
{
    /// <summary>
    /// Address component
    /// </summary>
    [DataContract]
    public class Address
    {

        #region Properties

        /// <summary>
        /// Full text description or name
        /// </summary>
        [DataMember(Name = "long_name")]
        public string LongName { get; set; }

        /// <summary>
        /// Abbreviated textual name, if available
        /// </summary>
        [DataMember(Name = "short_name")]
        public string ShortName { get; set; }

        /// <summary>
        /// Types of the address component
        /// </summary>
        [DataMember(Name = "types")]
        public List<PlaceResultTypeEnum> Types { get; set; } 

        #endregion
            
    }
}