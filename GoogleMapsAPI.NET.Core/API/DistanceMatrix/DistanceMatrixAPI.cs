using System;
using System.Collections.Generic;
using System.Linq;
using GoogleMapsAPI.NET.API.Client;
using GoogleMapsAPI.NET.API.Common;
using GoogleMapsAPI.NET.API.Common.Components.Locations.Interfaces.Combined;
using GoogleMapsAPI.NET.API.Directions.Enums;
using GoogleMapsAPI.NET.API.DistanceMatrix.Responses;
using GoogleMapsAPI.NET.Extensions;
using GoogleMapsAPI.NET.Requests;
using GoogleMapsAPI.NET.Utils;

namespace GoogleMapsAPI.NET.API.DistanceMatrix
{

    /// <summary>
    /// Distance matrix API
    /// </summary>
    public class DistanceMatrixAPI : MapsAPI
    {

        #region Constructors

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="client">API client</param>
        public DistanceMatrixAPI(MapsAPIClient client) : base(client)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get travel distance and time for a matrix of origins and destinations
        /// </summary>
        /// <param name="origins">One or more locations to use as the starting point for calculating travel distance and time.</param>
        /// <param name="destinations">One or more locations to use as the finishing point for calculating travel distance and time.</param>
        /// <param name="mode">The mode of transport to use when calculating distance.</param>
        /// <param name="language">The language in which to return results.</param>
        /// <param name="avoid">Introduces restrictions to the route.</param>
        /// <param name="units">The unit system to use when expressing distance as text</param>
        /// <param name="arrivalTime">The desired time of arrival for transit requests</param>
        /// <param name="departureTime">The desired time of departure</param>
        /// <param name="trafficModel">Specifies the assumptions to use when calculating time in traffic. </param>
        /// <param name="transitMode">Specifies one or more preferred modes of transit.</param>
        /// <param name="transitRoutingPreference">Specifies preferences for transit requests.</param>
        /// <returns></returns>
        public GetDistanceMatrixResponse GetDistanceMatrix(IAddressOrGeoCoordinatesLocation origins,
            IAddressOrGeoCoordinatesLocation destinations, TransportationModeEnum? mode = null,
            string language = null, AvoidFeaturesEnum? avoid = null, UnitSystemEnum? units = null,
            DateTime? arrivalTime = null,
            DateTime? departureTime = null, TrafficModelEnum? trafficModel = null, TransitModeEnum? transitMode = null,
            TransitRoutingPreferenceEnum? transitRoutingPreference = null)
        {
            
            return GetDistanceMatrix(new List<IAddressOrGeoCoordinatesLocation> {origins}, new List<IAddressOrGeoCoordinatesLocation> { destinations },
                mode, language, avoid, units, arrivalTime, departureTime, trafficModel, transitMode, transitRoutingPreference);

        }

        /// <summary>
        /// Get travel distance and time for a matrix of origins and destinations
        /// </summary>
        /// <param name="origins">One or more locations to use as the starting point for calculating travel distance and time.</param>
        /// <param name="destinations">One or more locations to use as the finishing point for calculating travel distance and time.</param>
        /// <param name="mode">The mode of transport to use when calculating distance.</param>
        /// <param name="language">The language in which to return results.</param>
        /// <param name="avoid">Introduces restrictions to the route.</param>
        /// <param name="units">The unit system to use when expressing distance as text</param>
        /// <param name="arrivalTime">The desired time of arrival for transit requests</param>
        /// <param name="departureTime">The desired time of departure</param>
        /// <param name="trafficModel">Specifies the assumptions to use when calculating time in traffic. </param>
        /// <param name="transitMode">Specifies one or more preferred modes of transit.</param>
        /// <param name="transitRoutingPreference">Specifies preferences for transit requests.</param>
        /// <returns></returns>
        public GetDistanceMatrixResponse GetDistanceMatrix(IEnumerable<IAddressOrGeoCoordinatesLocation> origins,
            IAddressOrGeoCoordinatesLocation destinations, TransportationModeEnum? mode = null,
            string language = null, AvoidFeaturesEnum? avoid = null, UnitSystemEnum? units = null,
            DateTime? arrivalTime = null,
            DateTime? departureTime = null, TrafficModelEnum? trafficModel = null, TransitModeEnum? transitMode = null,
            TransitRoutingPreferenceEnum? transitRoutingPreference = null)
        {
            
            return GetDistanceMatrix(origins, new List<IAddressOrGeoCoordinatesLocation> { destinations },
                mode, language, avoid, units, arrivalTime, departureTime, trafficModel, transitMode, transitRoutingPreference);

        }

        /// <summary>
        /// Get travel distance and time for a matrix of origins and destinations
        /// </summary>
        /// <param name="origins">One or more locations to use as the starting point for calculating travel distance and time.</param>
        /// <param name="destinations">One or more locations to use as the finishing point for calculating travel distance and time.</param>
        /// <param name="mode">The mode of transport to use when calculating distance.</param>
        /// <param name="language">The language in which to return results.</param>
        /// <param name="avoid">Introduces restrictions to the route.</param>
        /// <param name="units">The unit system to use when expressing distance as text</param>
        /// <param name="arrivalTime">The desired time of arrival for transit requests</param>
        /// <param name="departureTime">The desired time of departure</param>
        /// <param name="trafficModel">Specifies the assumptions to use when calculating time in traffic. </param>
        /// <param name="transitMode">Specifies one or more preferred modes of transit.</param>
        /// <param name="transitRoutingPreference">Specifies preferences for transit requests.</param>
        /// <returns></returns>
        public GetDistanceMatrixResponse GetDistanceMatrix(IAddressOrGeoCoordinatesLocation origins,
            IEnumerable<IAddressOrGeoCoordinatesLocation> destinations, TransportationModeEnum? mode = null,
            string language = null, AvoidFeaturesEnum? avoid = null, UnitSystemEnum? units = null,
            DateTime? arrivalTime = null,
            DateTime? departureTime = null, TrafficModelEnum? trafficModel = null, TransitModeEnum? transitMode = null,
            TransitRoutingPreferenceEnum? transitRoutingPreference = null)
        {

            return GetDistanceMatrix(new List<IAddressOrGeoCoordinatesLocation> {origins}, destinations,
                mode, language, avoid, units, arrivalTime, departureTime, trafficModel, transitMode, transitRoutingPreference);

        }

        /// <summary>
        /// Get travel distance and time for a matrix of origins and destinations
        /// </summary>
        /// <param name="origins">One or more locations to use as the starting point for calculating travel distance and time.</param>
        /// <param name="destinations">One or more locations to use as the finishing point for calculating travel distance and time.</param>
        /// <param name="mode">The mode of transport to use when calculating distance.</param>
        /// <param name="language">The language in which to return results.</param>
        /// <param name="avoid">Introduces restrictions to the route.</param>
        /// <param name="units">The unit system to use when expressing distance as text</param>
        /// <param name="arrivalTime">The desired time of arrival for transit requests</param>
        /// <param name="departureTime">The desired time of departure</param>
        /// <param name="trafficModel">Specifies the assumptions to use when calculating time in traffic. </param>
        /// <param name="transitMode">Specifies one or more preferred modes of transit.</param>
        /// <param name="transitRoutingPreference">Specifies preferences for transit requests.</param>
        /// <returns></returns>
        public GetDistanceMatrixResponse GetDistanceMatrix(IEnumerable<IAddressOrGeoCoordinatesLocation> origins,
            IEnumerable<IAddressOrGeoCoordinatesLocation> destinations, TransportationModeEnum? mode = null,
            string language = null, AvoidFeaturesEnum? avoid = null, UnitSystemEnum? units = null, DateTime? arrivalTime = null,
            DateTime? departureTime = null, TrafficModelEnum? trafficModel = null, TransitModeEnum? transitMode = null,
            TransitRoutingPreferenceEnum? transitRoutingPreference = null)
        {

            // Assign query params
            var queryParams = new QueryParams
            {
                ["origins"] = Converter.Location(origins),
                ["destinations"] = Converter.Location(destinations)
            };

            // Transportation mode
            if (mode.HasValue) queryParams["mode"] = mode.Value.GetSerializationName();

            // Language
            if (language != null) queryParams["language"] = language;

            // Features to avoid
            if (avoid.HasValue)
            {
                // Only one restriction can be specified.
                var selectedRestrictions = avoid.Value.GetFlags();
                if (selectedRestrictions.Count() == 1)
                {
                    queryParams["avoid"] = Converter.EnumFlagsList(avoid.Value);
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(avoid), "Only one restriction can be specified.");
                }
            }

            // Units system
            if (units != null) queryParams["units"] = units.Value.GetSerializationName();

            // Departure time
            if (departureTime != null) queryParams["departure_time"] = Converter.Time(departureTime.Value);

            // Arrival time
            if (arrivalTime != null) queryParams["arrival_time"] = Converter.Time(arrivalTime.Value);

            // Should not specify both departure and arrival time
            if (departureTime != null && arrivalTime != null)
            {
                throw new ArgumentException("Should not specify both departure and arrival time.");
            }

            // Traffic model
            if (trafficModel != null)
            {
                queryParams["traffic_model"] = trafficModel.Value.GetSerializationName();
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

            // Get API response result
            var response = Client.APIGet<GetDistanceMatrixResponse>("/maps/api/distancematrix/json", queryParams);

            // Return it
            return response;

        } 

        #endregion
         
    }
}