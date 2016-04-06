using System.Runtime.Serialization;
using GoogleMapsAPI.NET.API.Common.Responses;
using GoogleMapsAPI.NET.API.Elevation.Results;

namespace GoogleMapsAPI.NET.API.Elevation.Responses
{

    /// <summary>
    /// Get elevation response
    /// </summary>
    [DataContract]
    public class GetElevationResponse : APIMultipleResultsResponse<GetElevationResult>
    {        
    }

}