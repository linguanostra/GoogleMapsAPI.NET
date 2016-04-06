using System.Collections.Generic;
using GoogleMapsAPI.NET.API.Client;
using GoogleMapsAPI.NET.API.Common;
using GoogleMapsAPI.NET.API.Common.Components;
using GoogleMapsAPI.NET.API.Common.Components.Locations;
using GoogleMapsAPI.NET.API.Common.Components.Locations.Interfaces;
using GoogleMapsAPI.NET.API.Elevation.Responses;
using GoogleMapsAPI.NET.Requests;
using GoogleMapsAPI.NET.Utils;

namespace GoogleMapsAPI.NET.API.Elevation
{

    /// <summary>
    /// Elevation API
    /// </summary>
    public class ElevationAPI : MapsAPI
    {

        #region Constructors

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="client">API client</param>
        public ElevationAPI(MapsAPIClient client) : base(client)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get elevation
        /// </summary>
        /// <param name="location">Location</param>
        /// <returns>Result</returns>
        public GetElevationResponse GetElevations(GeoCoordinatesLocation location)
        {

            return GetElevations(new [] { location });
            
        }

        /// <summary>
        /// Get elevations
        /// </summary>
        /// <param name="locations">Locations</param>
        /// <param name="locationsPerQueries">Locations per queries</param>
        /// <returns>Results</returns>
        public GetElevationResponse GetElevations(IEnumerable<IGeoCoordinatesLocation> locations, int locationsPerQueries = 50)
        {

            // Assign query params
            var queryParams = new QueryParams
            {
                ["locations"] = Converter.ShortestPath(locations)
            };

            // Get API response result
            var response = Client.APIGet<GetElevationResponse>("/maps/api/elevation/json", queryParams);

            // Return it
            return response;

        }

        /// <summary>
        /// Provides elevation data sampled along a path on the surface of the earth.
        /// </summary>
        /// <param name="polylinePath">Polyline path from which you wish to calculate elevation data</param>
        /// <param name="samples">The number of sample points along a path for which to return elevation data.</param>
        /// <returns>Results</returns>
        public GetElevationResponse ElevationAlongPath(EncodedPolyline polylinePath, int samples)
        {

            // Assign query params
            var queryParams = new QueryParams
            {
                ["path"] = $"enc:{polylinePath.EncodedPoints}",
                ["samples"] = samples.ToString()
            };

            // Get API response result
            var response = Client.APIGet<GetElevationResponse>("/maps/api/elevation/json", queryParams);

            // Return it
            return response;

        }

        /// <summary>
        /// Provides elevation data sampled along a path on the surface of the earth.
        /// </summary>
        /// <param name="locations">List of latitude/longitude values from which you wish to calculate elevation data</param>
        /// <param name="samples">The number of sample points along a path for which to return elevation data.</param>
        /// <returns>Results</returns>
        public GetElevationResponse ElevationAlongPath(List<GeoCoordinatesLocation> locations, int samples)
        {

            // Assign query params
            var queryParams = new QueryParams
            {
                ["path"] = Converter.ShortestPath(locations),
                ["samples"] = samples.ToString()
            };

            // Get API response result
            var response = Client.APIGet<GetElevationResponse>("/maps/api/elevation/json", queryParams);

            // Return it
            return response;

        }


        #endregion

    }
}