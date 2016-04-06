using System.Runtime.Serialization;
using GoogleMapsAPI.NET.API.Places.Responses.Common;
using GoogleMapsAPI.NET.API.Places.Results;

namespace GoogleMapsAPI.NET.API.Places.Responses
{
    /// <summary>
    /// Place radar search response
    /// </summary>
    [DataContract]
    public class PlaceRadarSearchResponse : PlaceBaseSearchResponse<PlaceRadarSearchResult>
    {        
    }
}