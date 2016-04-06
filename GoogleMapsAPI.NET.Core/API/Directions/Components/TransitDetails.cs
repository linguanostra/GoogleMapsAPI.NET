using System.Runtime.Serialization;

namespace GoogleMapsAPI.NET.API.Directions.Components
{
    /// <summary>
    /// Transit details component
    /// </summary>
    [DataContract]
    public class TransitDetails
    {

        #region Properties

        /// <summary>
        /// Arrival stop
        /// </summary>
        [DataMember(Name = "arrival_stop")]
        public TransitStopStation ArrivalStop { get; set; }

        /// <summary>
        /// Departure stop
        /// </summary>
        [DataMember(Name = "departure_stop")]
        public TransitStopStation DepartureStop { get; set; }

        #endregion

    }
}