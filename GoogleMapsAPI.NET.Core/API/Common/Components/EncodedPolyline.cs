using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleMapsAPI.NET.API.Common.Components.Locations;
using GoogleMapsAPI.NET.Utils;

namespace GoogleMapsAPI.NET.API.Common.Components
{

    /// <summary>
    /// Encoded Polyline component
    /// </summary>
    [DataContract]
    public class EncodedPolyline
    {

        #region Properties

        /// <summary>
        /// Encoded polyline representation of the route
        /// </summary>
        [DataMember(Name = "points")]
        public string EncodedPoints { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Decode the encoded polyline points
        /// </summary>
        /// <returns>List of coordinates</returns>
        public List<GeoCoordinatesLocation> DecodePoints()
        {

            return Converter.DecodePolyline(EncodedPoints);

        }

        #endregion

    }
}