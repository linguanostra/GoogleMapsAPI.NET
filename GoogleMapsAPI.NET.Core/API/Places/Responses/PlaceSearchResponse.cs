using System.Runtime.Serialization;
using GoogleMapsAPI.NET.API.Places.Responses.Common;
using GoogleMapsAPI.NET.API.Places.Results;

namespace GoogleMapsAPI.NET.API.Places.Responses
{
    /// <summary>
    /// Place search response
    /// </summary>
    [DataContract]
    public class PlaceSearchResponse : PlaceBaseSearchResponse<PlaceSearchResult>
    {
    }
}