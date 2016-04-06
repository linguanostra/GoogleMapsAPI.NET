using System.Runtime.Serialization;
using GoogleMapsAPI.NET.API.Common.Components.Locations.Common;
using GoogleMapsAPI.NET.API.Common.Components.Locations.Interfaces;

namespace GoogleMapsAPI.NET.API.Common.Components.Locations
{
    /// <summary>
    /// Address location
    /// </summary>
    [DataContract]
    public class AddressLocation : Location, IAddressLocation
    {

        #region Properties

        /// <summary>
        /// Address value
        /// </summary>
        [DataMember(Name = "address")]
        public string Address { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new instance
        /// </summary>
        public AddressLocation()
        {
        }

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="address">Address value</param>
        public AddressLocation(string address)
        {
            Address = address;
        }

        #endregion
    }

}