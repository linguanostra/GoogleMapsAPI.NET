using System;
using GoogleMapsAPI.NET.API.Client;
using GoogleMapsAPI.NET.API.Common;
using GoogleMapsAPI.NET.API.Common.Components.Locations;
using GoogleMapsAPI.NET.API.TimeZone.Responses;
using GoogleMapsAPI.NET.Extensions;
using GoogleMapsAPI.NET.Requests;
using GoogleMapsAPI.NET.Utils;

namespace GoogleMapsAPI.NET.API.TimeZone
{

    /// <summary>
    /// TimeZone API
    /// </summary>
    public class TimeZoneAPI : MapsAPI
    {

        #region Constructors

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="client">API client</param>
        public TimeZoneAPI(MapsAPIClient client) : base(client)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Provides time offset data for locations on the surface of the earth
        /// </summary>
        /// <param name="latitude">The latitude of the location to look up.</param>
        /// <param name="longitude">The longitude of the location to look up.</param>
        /// <param name="timestamp">The desired time as seconds since midnight, January 1, 1970 UTC. The Google Maps Time 
        /// Zone API uses the timestamp to determine whether or not Daylight Savings should be applied. Times before 1970 
        /// can be expressed as negative values.</param>
        /// <param name="language">The language in which to return results.</param>
        /// <returns>Result</returns>
        public GetTimeZoneResponse GetTimeZone(double latitude, double longitude, long timestamp, string language = null)
        {

            return GetTimeZone(new GeoCoordinatesLocation(latitude, longitude), timestamp);

        }

        /// <summary>
        /// Provides time offset data for locations on the surface of the earth
        /// </summary>
        /// <param name="location">The location to look up.</param>
        /// <param name="timestamp">The desired time as seconds since midnight, January 1, 1970 UTC. The Google Maps Time 
        /// Zone API uses the timestamp to determine whether or not Daylight Savings should be applied. Times before 1970 
        /// can be expressed as negative values.</param>
        /// <param name="language">The language in which to return results.</param>
        /// <returns>Result</returns>
        public GetTimeZoneResponse GetTimeZone(GeoCoordinatesLocation location, long timestamp, string language = null)
        {

            // Assign query params
            var queryParams = new QueryParams
            {
                ["location"] = Converter.Location(location),
                ["timestamp"] = Converter.Time(timestamp)
            };

            // Get API response result
            var response = Client.APIGet<GetTimeZoneResponse>("/maps/api/timezone/json", queryParams);

            // Return it
            return response;

        }

        /// <summary>
        /// Provides time offset data for locations on the surface of the earth
        /// </summary>
        /// <param name="latitude">The latitude of the location to look up.</param>
        /// <param name="longitude">The longitude of the location to look up.</param>
        /// <param name="forDate">The date to determine whether or not Daylight Savings should be applied</param>
        /// <param name="language">The language in which to return results.</param>
        /// <returns>Result</returns>
        public GetTimeZoneResponse GetTimeZone(double latitude, double longitude, DateTime forDate, string language = null)
        {

            return GetTimeZone(new GeoCoordinatesLocation(latitude, longitude), forDate);

        }

        /// <summary>
        /// Provides time offset data for locations on the surface of the earth
        /// </summary>
        /// <param name="location">The location to look up.</param>
        /// <param name="forDate">The date to determine whether or not Daylight Savings should be applied</param>
        /// <param name="language">The language in which to return results.</param>
        /// <returns>Result</returns>
        public GetTimeZoneResponse GetTimeZone(GeoCoordinatesLocation location, DateTime forDate, string language = null)
        {

            // Call overload with converted target date
            return GetTimeZone(location, forDate.SecondsSinceEpoch(), language);

        }

        #endregion

    }
}