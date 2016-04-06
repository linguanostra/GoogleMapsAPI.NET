using System;
using GoogleMapsAPI.NET.API.Client;
using GoogleMapsAPI.NET.API.Common;
using GoogleMapsAPI.NET.API.Common.Components.Locations.Common;
using GoogleMapsAPI.NET.API.StreetViewImage.Responses;
using GoogleMapsAPI.NET.Requests;
using GoogleMapsAPI.NET.Utils;

namespace GoogleMapsAPI.NET.API.StreetViewImage
{

    /// <summary>
    /// Street view image API
    /// </summary>
    public class StreetViewImageAPI : MapsAPI
    {

        #region Constructors

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="client">API client</param>
        public StreetViewImageAPI(MapsAPIClient client) : base(client)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get street view image
        /// </summary>
        /// <param name="location">Location</param>
        /// <param name="width">Image width</param>
        /// <param name="height">Image height</param>
        /// <param name="heading">Heading</param>
        /// <param name="fieldOfView">Field of view</param>
        /// <param name="pitch">Pitch</param>
        /// <returns>Response result</returns>
        public StreetViewResponse GetStreetViewImage(Location location, int width = 600, int height = 400, double? heading = null,
            int? fieldOfView = null, double? pitch = null)
        {

            // Assign query params
            var queryParams = new QueryParams
            {
                ["location"] = Converter.Location(location),
                ["size"] = $"{width}x{height}"
            };

            if (heading.HasValue) queryParams["heading"] = Converter.Number(heading.Value);
            if (fieldOfView.HasValue) queryParams["fov"] = Converter.Number(fieldOfView.Value);
            if (pitch.HasValue) queryParams["pitch"] = Converter.Number(pitch.Value);

            // Get response content
            var responseContent = Client.GetBinary("/maps/api/streetview", queryParams);

            // Return response
            return new StreetViewResponse(responseContent);

        }
        
        #endregion

    }
}