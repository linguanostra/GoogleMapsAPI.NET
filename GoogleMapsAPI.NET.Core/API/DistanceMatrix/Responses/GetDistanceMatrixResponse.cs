using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleMapsAPI.NET.API.Common.Responses;
using GoogleMapsAPI.NET.API.DistanceMatrix.Components;

namespace GoogleMapsAPI.NET.API.DistanceMatrix.Responses
{

    /// <summary>
    /// Get distance matrix response
    /// </summary>
    [DataContract]
    public class GetDistanceMatrixResponse : APIResponse
    {

        #region Properties

        /// <summary>
        /// Origin addresses
        /// </summary>
        [DataMember(Name = "origin_addresses")]
        public List<string> OriginAddresses { get; set; }

        /// <summary>
        /// Destination addresses
        /// </summary>
        [DataMember(Name = "destination_addresses")]
        public List<string> DestinationAddresses { get; set; }

        /// <summary>
        /// Rows
        /// </summary>
        [DataMember(Name = "rows")]
        public List<DistanceMatrixRow> Rows { get; set; } 

        #endregion

    }
}