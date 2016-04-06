using GoogleMapsAPI.NET.API.Common.Components.Locations.Common.Interfaces;

namespace GoogleMapsAPI.NET.API.Common.Components.Locations.Interfaces
{

    /// <summary>
    /// Place location interface
    /// </summary>
    public interface IPlaceLocation : ILocation
    {

        #region Properties

        /// <summary>
        /// Place Id
        /// </summary>
        string PlaceId { get; set; }

        #endregion

    }
}