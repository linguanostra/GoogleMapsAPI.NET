using System.Runtime.Serialization;

namespace GoogleMapsAPI.NET.API.Places.Components
{
    /// <summary>
    /// Place opening hours component
    /// </summary>
    [DataContract]
    public class PlaceOpeningHours
    {

        #region Properties

        /// <summary>
        /// Open now
        /// </summary>
        [DataMember(Name = "open_now")]
        public bool OpenNow { get; set; }

        #endregion
         
    }
}