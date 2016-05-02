using System;
using System.Collections.Generic;
using GoogleMapsAPI.NET.API.Client;
using GoogleMapsAPI.NET.API.Common;
using GoogleMapsAPI.NET.API.Common.Components.Locations;
using GoogleMapsAPI.NET.API.Common.Components.Locations.Common;
using GoogleMapsAPI.NET.API.Directions.Enums;
using GoogleMapsAPI.NET.API.Directions.Responses;
using GoogleMapsAPI.NET.Extensions;
using GoogleMapsAPI.NET.Requests;
using GoogleMapsAPI.NET.Utils;

namespace GoogleMapsAPI.NET.API.Directions
{

    /// <summary>
    /// Directions API
    /// </summary>
    public class DirectionsAPI : MapsAPI
    {

        #region Constructors

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="client">API client</param>
        public DirectionsAPI(MapsAPIClient client) : base(client)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get directions between an origin point and a destination point.
        /// </summary>
        /// <param name="origin">
        /// The address or latitude/longitude value from which you wish
        /// to calculate directions.
        /// </param>
        /// <param name="destination">
        /// The address or latitude/longitude value from which
        /// you wish to calculate directions.
        /// </param>
        /// <param name="mode">
        /// Specifies the mode of transport to use when calculating directions.
        /// </param>
        /// <param name="waypoints">
        /// Specifies an array of waypoints. Waypoints alter a route by routing it through the specified location(s).
        /// </param>
        /// <param name="alternatives">
        /// If True, more than one route may be returned in the response.
        /// </param>
        /// <param name="avoid">
        /// Indicates that the calculated route(s) should avoid the indicated features.
        /// </param>
        /// <param name="language">
        /// The language in which to return results.
        /// </param>
        /// <param name="units">
        /// Specifies the unit system to use when displaying results.
        /// "metric" or "imperial"
        /// </param>
        /// <param name="region">
        /// The region code, specified as a ccTLD ("top-level domain"
        /// two-character value.
        /// </param>
        /// <param name="departureTime">
        /// Specifies the desired time of departure.
        /// </param>
        /// <param name="arrivalTime">
        /// Specifies the desired time of arrival for transit
        /// directions.Note: you can't specify both departureTime and
        /// arrivalTime.
        /// </param>
        /// <param name="optimizeWaypoints">
        /// Optimize the provided route by rearranging the
        /// waypoints in a more efficient order.
        /// </param>
        /// <param name="transitMode">
        /// Specifies one or more preferred modes of transit.
        /// This parameter may only be specified for requests where the mode is
        /// transit.Valid values are "bus", "subway", "train", "tram", "rail".
        /// "rail" is equivalent to ["train", "tram", "subway"].
        /// </param>
        /// <param name="transitRoutingPreference">
        /// Specifies preferences for transit
        /// requests.Valid values are "less_walking" or "fewer_transfers"
        /// </param>
        /// <param name="trafficModel">
        /// Specifies the predictive travel time model to use.
        /// Valid values are "best_guess" or "optimistic" or "pessimistic".
        /// The trafficModel parameter may only be specified for requests where
        /// the travel mode is driving, and where the request includes a
        /// departureTime.
        /// </param>
        /// <exception cref="ArgumentException"></exception>
        /// <returns>Result</returns>
        public GetDirectionsResponse GetDirections(string origin, string destination,
            TransportationModeEnum? mode = null, IList<Location> waypoints = null,
            bool alternatives = false, AvoidFeaturesEnum? avoid = null,
            string language = null, UnitSystemEnum? units = null, string region = null, DateTime? departureTime = null,
            DateTime? arrivalTime = null, bool optimizeWaypoints = false, TransitModeEnum? transitMode = null,
            TransitRoutingPreferenceEnum? transitRoutingPreference = null, TrafficModelEnum? trafficModel = null)
        {

            return GetDirections(new AddressLocation(origin), new AddressLocation(destination),
                mode, waypoints, alternatives, avoid, language, units, region, departureTime, arrivalTime,
                optimizeWaypoints, transitMode, transitRoutingPreference, trafficModel);
        }

        /// <summary>
        /// Get directions between an origin point and a destination point.
        /// </summary>
        /// <param name="origin">
        /// The address or latitude/longitude value from which you wish
        /// to calculate directions.
        /// </param>
        /// <param name="destination">
        /// The address or latitude/longitude value from which
        /// you wish to calculate directions.
        /// </param>
        /// <param name="mode">
        /// Specifies the mode of transport to use when calculating directions.
        /// </param>
        /// <param name="waypoints">
        /// Specifies an array of waypoints. Waypoints alter a route by routing it through the specified location(s).
        /// </param>
        /// <param name="alternatives">
        /// If True, more than one route may be returned in the response.
        /// </param>
        /// <param name="avoid">
        /// Indicates that the calculated route(s) should avoid the indicated features.
        /// </param>
        /// <param name="language">
        /// The language in which to return results.
        /// </param>
        /// <param name="units">
        /// Specifies the unit system to use when displaying results.
        /// "metric" or "imperial"
        /// </param>
        /// <param name="region">
        /// The region code, specified as a ccTLD ("top-level domain"
        /// two-character value.
        /// </param>
        /// <param name="departureTime">
        /// Specifies the desired time of departure.
        /// </param>
        /// <param name="arrivalTime">
        /// Specifies the desired time of arrival for transit
        /// directions.Note: you can't specify both departureTime and
        /// arrivalTime.
        /// </param>
        /// <param name="optimizeWaypoints">
        /// Optimize the provided route by rearranging the
        /// waypoints in a more efficient order.
        /// </param>
        /// <param name="transitMode">
        /// Specifies one or more preferred modes of transit.
        /// This parameter may only be specified for requests where the mode is
        /// transit.Valid values are "bus", "subway", "train", "tram", "rail".
        /// "rail" is equivalent to ["train", "tram", "subway"].
        /// </param>
        /// <param name="transitRoutingPreference">
        /// Specifies preferences for transit
        /// requests.Valid values are "less_walking" or "fewer_transfers"
        /// </param>
        /// <param name="trafficModel">
        /// Specifies the predictive travel time model to use.
        /// Valid values are "best_guess" or "optimistic" or "pessimistic".
        /// The trafficModel parameter may only be specified for requests where
        /// the travel mode is driving, and where the request includes a
        /// departureTime.
        /// </param>
        /// <exception cref="ArgumentException"></exception>
        /// <returns>Result</returns>
        public GetDirectionsResponse GetDirections(Location origin, Location destination,
            TransportationModeEnum? mode = null, IList<Location> waypoints = null,
            bool alternatives = false, AvoidFeaturesEnum? avoid = null,
            string language = null, UnitSystemEnum? units = null, string region = null, DateTime? departureTime = null,
            DateTime? arrivalTime = null, bool optimizeWaypoints = false, TransitModeEnum? transitMode = null,
            TransitRoutingPreferenceEnum? transitRoutingPreference = null, TrafficModelEnum? trafficModel = null)
        {

            // Assign query params
            var queryParams = new QueryParams
            {
                ["origin"] = Converter.Location(origin),
                ["destination"] = Converter.Location(destination)
            };

            // Transportation mode
            if (mode.HasValue) queryParams["mode"] = mode.Value.GetSerializationName();

            // Waypoints
            if (waypoints != null)
            {
                var waypointsValue = Converter.Location(waypoints);
                if (optimizeWaypoints)
                {
                    waypointsValue = "optimize:true|" + waypointsValue;
                }
                queryParams["waypoints"] = waypointsValue;
            }

            // Alternatives
            if (alternatives) queryParams["alternatives"] = "true";

            // Features to avoid
            if (avoid.HasValue)
            {
                queryParams["avoid"] = Converter.EnumFlagsList(avoid.Value);
            }

            // Language
            if (language != null) queryParams["language"] = language;

            // Units system
            if (units != null) queryParams["units"] = units.Value.GetSerializationName();

            // Region
            if (region != null) queryParams["region"] = region;

            // Departure time
            if (departureTime != null) queryParams["departure_time"] = Converter.Time(departureTime.Value);

            // Arrival time
            if (arrivalTime != null) queryParams["arrival_time"] = Converter.Time(arrivalTime.Value);

            // Should not specify both departure and arrival time
            if (departureTime != null && arrivalTime != null)
            {
                throw new ArgumentException("Should not specify both departure and arrival time.");
            }

            // Transit mode
            if (transitMode != null)
            {
                queryParams["transit_mode"] = Converter.EnumFlagsList(transitMode.Value);
            }

            // Transit routing preference
            if (transitRoutingPreference != null)
            {
                queryParams["transit_routing_preference"] = transitRoutingPreference.Value.GetSerializationName();
            }

            // Traffic model
            if (trafficModel != null)
            {
                queryParams["traffic_model"] = trafficModel.Value.GetSerializationName();
            }

            // Get API response result
            var response = Client.APIGet<GetDirectionsResponse>("/maps/api/directions/json", queryParams);

            // Return it
            return response;

        }

        #endregion

    }
}