using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using GoogleMapsAPI.NET.API.Common.Components;
using GoogleMapsAPI.NET.API.Common.Components.Locations;
using GoogleMapsAPI.NET.API.Common.Components.Locations.Common.Interfaces;
using GoogleMapsAPI.NET.API.Common.Components.Locations.Interfaces;
using GoogleMapsAPI.NET.Extensions;
using GoogleMapsAPI.NET.Requests;

namespace GoogleMapsAPI.NET.Utils
{
    /// <summary>
    /// Converts Python types to string representations suitable for Maps API server.
    ///
    /// For example:
    /// 
    /// sydney = {
    ///     "lat" : -33.8674869,
    ///     "lng" : 151.2069902
    /// }
    ///
    /// convert.latlng(sydney)
    ///    # '-33.8674869,151.2069902'
    /// </summary>
    public class Converter
    {

        #region Static methods

        /// <summary>
        /// Converts a dict of components to the format expected by the Google Maps
        /// server.
        /// 
        /// For example:
        /// c = {"country": "US", "postal_code": "94043"}
        /// convert.components(c)
        /// # 'country:US|postal_code:94043'
        /// 
        /// </summary>
        /// <param name="components">The components filter</param>
        /// <returns>Result string</returns>
        public static string Components(ComponentsFilter components)
        {

            return string.Join("|", 
                components.AllKeys.OrderBy(x => x).Select(y => $"{y}:{components[y]}"));
            
            /*

            if isinstance(arg, dict):
                arg = sorted(["%s:%s" % (k, arg[k]) for k in arg])
                return "|".join(arg)

            */

        }

        #endregion

        /// <summary>
        /// Converts a lat/lon bounds to a comma- and pipe-separated string.
        ///
        /// Accepts two representations:
        /// 
        /// 1) string: pipe-separated pair of comma-separated lat/lon pairs.
        /// 2) dict with two entries - "southwest" and "northeast". See convert.latlng
        /// for information on how these can be represented.
        ///
        /// For example:
        ///
        /// sydney_bounds = {
        ///    "northeast" : {
        ///         "lat" : -33.4245981,
        ///         "lng" : 151.3426361
        ///    },
        ///    "southwest" : {
        ///         "lat" : -34.1692489,
        ///         "lng" : 150.502229
        ///    }
        /// }
        ///
        /// convert.bounds(sydney_bounds)
        /// # '-34.169249,150.502229|-33.424598,151.342636'            
        /// 
        /// </summary>
        /// <param name="bounds"></param>
        /// <returns>Result string</returns>
        public static string Bounds(ViewportBoundingBox bounds)
        {

            return $"{bounds.Southwest.Latitude},{bounds.Southwest.Longitude}" +
                   $"|{bounds.NorthEast.Latitude},{bounds.NorthEast.Longitude}";

        }

        /// <summary>
        /// Converts a location to a comma-separated string (when applicable)
        /// </summary>
        /// <param name="location">Location</param>
        /// <returns>Result string</returns>
        public static string Location(ILocation location)
        {
            
            // Get location type
            var locationType = location.GetType();

            // Check for inherited type

            // Address location
            if (locationType.InheritsOrImplements(typeof(IAddressLocation)))
            {

                return ((IAddressLocation) location).Address;

            }

            // Geo coordinates location
            if (locationType.InheritsOrImplements(typeof (IGeoCoordinatesLocation)))
            {

                var coordinates = (IGeoCoordinatesLocation) location;
                return $"{coordinates.Latitude},{coordinates.Longitude}";

            }

            // Place location
            if (locationType.InheritsOrImplements(typeof (IPlaceLocation)))
            {

                return $"place_id: {((IPlaceLocation)location).PlaceId}";

            }
            
            // Not supported
            throw new NotSupportedException();

        }

        /// <summary>
        /// Joins a list of locations into a pipe separated string, handling
        /// the various formats supported for lat/lng values
        /// </summary>
        /// <param name="locations">Locations list</param>
        /// <returns>Result string</returns>
        public static string Location(IEnumerable<ILocation> locations)
        {

            return 
                locations
                .Aggregate("", (current, location) => current + $"{Location(location)}|")
                .TrimEnd('|');

        }

        /// <summary>
        /// Join enum list with separator
        /// </summary>
        /// <param name="values">Values</param>
        /// <param name="separator">Separator</param>
        /// <returns>Result string</returns>
        public static string JoinEnumList(IEnumerable<Enum> values, char separator = '|')
        {

            return
                values
                .Aggregate("", (current, value) => current + $"{value.GetSerializationName()}{separator}")
                .TrimEnd(separator);

        }

        /// <summary>
        /// Join list with separator
        /// </summary>
        /// <typeparam name="TValue">Value type</typeparam>
        /// <param name="values">Values</param>
        /// <param name="separator">Separator</param>
        /// <returns>Result string</returns>
        public static string JoinList<TValue>(IEnumerable<TValue> values, char separator = '|')
        {

            return
                values
                .Aggregate("", (current, value) => current + $"{value}{separator}")
                .TrimEnd(separator);

        }
        
        /// <summary>
        /// Converts the value into a unix time (seconds since unix epoch).
        /// 
        /// For example:
        /// convert.time(DateTime.now())
        /// '1409810596'
        /// 
        /// </summary>
        /// <param name="time">Time value</param>
        /// <returns>Result string</returns>
        public static string Time(DateTime time)
        {
            return time.SecondsSinceEpoch().ToString();
        }

        /// <summary>
        /// Converts the value into a unix time (seconds since unix epoch).
        /// </summary>
        /// <param name="time">Time value</param>
        /// <returns>Result string</returns>
        public static string Time(long time)
        {
            return time.ToString();
        }

        /// <summary>
        /// Decodes an encoded polyline point string
        /// </summary>
        /// <param name="polyline">Encoded polyline</param>
        /// <returns>List of coordinates</returns>
        public static IList<GeoCoordinatesLocation> DecodePolyline(EncodedPolyline polyline)
        {

            return DecodePolyline(polyline.EncodedPoints);

        }

        /// <summary>
        /// Decodes an encoded polyline points string
        /// </summary>
        /// <param name="polylinePoints">Encoded polyline value</param>
        /// <returns>List of coordinates</returns>
        public static List<GeoCoordinatesLocation> DecodePolyline(string polylinePoints)
        {

            var points = new List<GeoCoordinatesLocation>();
            var index = 0;
            double lat = 0, lng = 0;

            while (index < polylinePoints.Length)
            {

                var result = 1;
                var shift = 0;
                while (true)
                {

                    var b = polylinePoints[index] - 63 - 1;
                    index += 1;
                    result += b << shift;
                    shift += 5;
                    if (b < 0x1f) break;

                }

                lat += (result & 1) != 0 ? (~result >> 1) : (result >> 1);
                result = 1;
                shift = 0;
                while (true)
                {
                    var b = polylinePoints[index] - 63 - 1;
                    index += 1;
                    result += b << shift;
                    shift += 5;
                    if (b < 0x1f) break;
                }

                lng += (result & 1) != 0 ? ~(result >> 1) : (result >> 1);

                points.Add(new GeoCoordinatesLocation(lat * 1e-5, lng * 1e-5));

            }

            return points;

        }

        /// <summary>
        /// Encode points into polyline
        /// See: https://gist.github.com/shinyzhu/4617989
        /// </summary>
        /// <param name="points">Points</param>
        /// <returns>Result polyline</returns>
        public static string EncodePolyline(IEnumerable<IGeoCoordinatesLocation> points)
        {
            
            var str = new StringBuilder();

            var encodeDiff = (Action<int>)(diff =>
            {
                int shifted = diff << 1;
                if (diff < 0)
                    shifted = ~shifted;

                int rem = shifted;

                while (rem >= 0x20)
                {
                    str.Append((char)((0x20 | (rem & 0x1f)) + 63));

                    rem >>= 5;
                }

                str.Append((char)(rem + 63));
            });

            var lastLat = 0;
            var lastLng = 0;

            foreach (var point in points)
            {
                var lat = (int)Math.Round(point.Latitude * 1E5);
                var lng = (int)Math.Round(point.Longitude * 1E5);

                encodeDiff(lat - lastLat);
                encodeDiff(lng - lastLng);

                lastLat = lat;
                lastLng = lng;
            }

            return str.ToString();

        }        

        /// <summary>
        /// Convert numeric value
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>Result string</returns>
        public static string Number(decimal value)
        {

            return value.ToString(CultureInfo.InvariantCulture);

        }

        /// <summary>
        /// Convert numeric value
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>Result string</returns>
        public static string Number(double value)
        {

            return value.ToString(CultureInfo.InvariantCulture);

        }

        /// <summary>
        /// Convert numeric value
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>Result string</returns>
        public static string Number(int value)
        {

            return value.ToString(CultureInfo.InvariantCulture);

        }

        /// <summary>
        /// Convert boolean value
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>Result string</returns>
        public static string Value(bool value)
        {

            return value ? "true" : "false";

        }

        /// <summary>
        /// Returns the shortest representation of the given location.
        /// 
        /// The Elevations API limits requests to 2000 characters, and accepts
        /// multiple locations either as pipe-delimited lat/lng values, or
        /// an encoded polyline, so we determine which is shortest and use it.
        /// </summary>
        /// <param name="location">Location</param>
        /// <returns>Shortest representation</returns>
        public static string ShortestPath(IGeoCoordinatesLocation location)
        {

            return ShortestPath(new List<IGeoCoordinatesLocation> {location});

        }

        /// <summary>
        /// Returns the shortest representation of the given locations.
        /// 
        /// The Elevations API limits requests to 2000 characters, and accepts
        /// multiple locations either as pipe-delimited lat/lng values, or
        /// an encoded polyline, so we determine which is shortest and use it.
        /// </summary>
        /// <param name="locations">Locations</param>
        /// <returns>Shortest representation</returns>
        public static string ShortestPath(IEnumerable<IGeoCoordinatesLocation> locations)
        {

            // Get encoded path representation
            var encodedPath = $"enc:{EncodePolyline(locations)}";

            // Get unencoded path representation
            var unencodedPath = Location(locations);

            // Return the shortest one
            return encodedPath.Length < unencodedPath.Length ? encodedPath : unencodedPath;

        }

        /// <summary>
        /// Convert enum flags to list
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>Result string</returns>
        public static string EnumFlagsList(Enum value)
        {

            return JoinEnumList(value.GetFlags());

        }

    }
}