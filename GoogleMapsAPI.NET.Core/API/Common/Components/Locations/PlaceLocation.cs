using System.Runtime.Serialization;
using GoogleMapsAPI.NET.API.Common.Components.Locations.Common;
using GoogleMapsAPI.NET.API.Common.Components.Locations.Interfaces;

namespace GoogleMapsAPI.NET.API.Common.Components.Locations
{

    /// <summary>
    /// Place location
    /// </summary>
    [DataContract]
    public class PlaceLocation : Location, IPlaceLocation
    {

        #region Properties

        /// <summary>
        /// Place Id
        /// </summary>
        [DataMember(Name = "place_id")]
        public string PlaceId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new instance
        /// </summary>
        public PlaceLocation()
        {
        }

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="placeId">Place Id</param>
        public PlaceLocation(string placeId)
        {
            PlaceId = placeId;
        }

        #endregion
         
    }
}