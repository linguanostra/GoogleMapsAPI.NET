using GoogleMapsAPI.NET.API.Common.Components.Locations.Common.Interfaces;
using GoogleMapsAPI.NET.API.Common.Components.Locations.Interfaces.Combined;

namespace GoogleMapsAPI.NET.API.Common.Components.Locations.Interfaces
{

    /// <summary>
    /// Address location interface
    /// </summary>
    public interface IAddressLocation : ILocation, IAddressOrGeoCoordinatesLocation
    {

        #region Properties

        /// <summary>
        /// Address value
        /// </summary>
        string Address { get; set; }

        #endregion

    }
}