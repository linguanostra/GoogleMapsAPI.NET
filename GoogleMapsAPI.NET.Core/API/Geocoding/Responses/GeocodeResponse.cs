using System.Runtime.Serialization;
using GoogleMapsAPI.NET.API.Common.Responses;
using GoogleMapsAPI.NET.API.Geocoding.Results;

namespace GoogleMapsAPI.NET.API.Geocoding.Responses
{

    /// <summary>
    /// Geocode operation result response
    /// </summary>
    [DataContract]
    public class GeocodeResponse : APIMultipleResultsResponse<GeocodeResult>
    {
    }

}