using System.Collections.Generic;
using System.Text;
using GoogleMapsAPI.NET.API.Client;
using GoogleMapsAPI.NET.API.Common;
using GoogleMapsAPI.NET.API.Common.Components.Locations.Interfaces;
using GoogleMapsAPI.NET.API.Roads.Enums;
using GoogleMapsAPI.NET.API.Roads.Responses;
using GoogleMapsAPI.NET.Extensions;
using GoogleMapsAPI.NET.Requests;
using GoogleMapsAPI.NET.Utils;

namespace GoogleMapsAPI.NET.API.Roads
{

    /// <summary>
    /// Roads API
    /// </summary>
    public class RoadsAPI : MapsAPI
    {

        #region Constructors

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="client">API client</param>
        public RoadsAPI(MapsAPIClient client) : base(client)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// takes up to 100 GPS points collected along a route, and returns a similar set of data, with the points snapped 
        /// to the most likely roads the vehicle was traveling along
        /// </summary>
        /// <param name="path">The path to be snapped</param>
        /// <param name="interpolate">Whether to interpolate a path to include all points forming the full road-geometry</param>
        /// <returns>Result</returns>
        public SnapToRoadsResponse SnapToRoads(IGeoCoordinatesLocation path, bool? interpolate = null)
        {

            return SnapToRoads(new List<IGeoCoordinatesLocation> { path }, interpolate);

        }

        /// <summary>
        /// takes up to 100 GPS points collected along a route, and returns a similar set of data, with the points snapped 
        /// to the most likely roads the vehicle was traveling along
        /// </summary>
        /// <param name="path">The path to be snapped</param>
        /// <param name="interpolate">Whether to interpolate a path to include all points forming the full road-geometry</param>
        /// <returns>Result</returns>
        public SnapToRoadsResponse SnapToRoads(List<IGeoCoordinatesLocation> path, bool? interpolate = null)
        {

            // Assign query params
            var queryParams = new QueryParams
            {
                ["path"] = Converter.Location(path)
            };

            // Interpolate
            if (interpolate.HasValue) queryParams["interpolate"] = "true";

            // Get API response result
            var response = Client.APIGet<SnapToRoadsResponse>("/v1/snapToRoads", queryParams, 
                baseUrl: "https://roads.googleapis.com");

            // Return it
            return response;

        }

        /// <summary>
        /// Get the posted speed limit for a given road segment
        /// </summary>
        /// <param name="path">The path to be snapped</param>
        /// <param name="units">Speed limits units</param>
        /// <returns>result</returns>
        public SpeedLimitsResponse SpeedLimits(IGeoCoordinatesLocation path, SpeedUnitEnum? units = null)
        {
            
            return SpeedLimits(new List<IGeoCoordinatesLocation> {path}, units);

        }

        /// <summary>
        /// Get the posted speed limit for a given road segment
        /// </summary>
        /// <param name="path">The path to be snapped</param>
        /// <param name="units">Speed limits units</param>
        /// <returns>result</returns>
        public SpeedLimitsResponse SpeedLimits(List<IGeoCoordinatesLocation> path, SpeedUnitEnum? units = null)
        {

            // Assign query params
            var queryParams = new QueryParams
            {
                ["path"] = Converter.Location(path)
            };

            // Speed limits units
            if (units.HasValue) queryParams["units"] = units.Value.GetSerializationName();

            // Get API response result
            var response = Client.APIGet<SpeedLimitsResponse>("/v1/speedLimits", queryParams,
                baseUrl: "https://roads.googleapis.com");

            // Return it
            return response;

        }

        /// <summary>
        /// Get the posted speed limit for a given road segment
        /// </summary>
        /// <param name="places">Places on the road segment</param>
        /// <param name="units">Speed limits units</param>
        /// <returns>result</returns>
        public SpeedLimitsResponse SpeedLimits(IPlaceLocation places, SpeedUnitEnum? units = null)
        {

            return SpeedLimits(new List<IPlaceLocation> { places }, units);
            
        }

        /// <summary>
        /// Get the posted speed limit for a given road segment
        /// </summary>
        /// <param name="places">Places on the road segment</param>
        /// <param name="units">Speed limits units</param>
        /// <returns>result</returns>
        public SpeedLimitsResponse SpeedLimits(List<IPlaceLocation> places, SpeedUnitEnum? units = null)
        {

            // Build url directly without using the usual QueryParams since the API V1 handles multiple values differently
            var queryParams = new StringBuilder();

            // Places (as repeated entries)
            foreach (var place in places)
            {
                queryParams.Append($"placeId={place.PlaceId}&");
            }

            // Speed limits units
            if (units.HasValue)
            {
                queryParams.Append($"units={units.Value.GetSerializationName()}&");
            }

            // Get API response result
            var response = Client.APIGet<SpeedLimitsResponse>(
                "https://roads.googleapis.com/v1/speedLimits?" + queryParams, 
                new QueryParams(),
                baseUrl: "");

            // Return it
            return response;

        }

        #endregion

    }
}