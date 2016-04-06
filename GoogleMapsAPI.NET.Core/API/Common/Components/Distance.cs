namespace GoogleMapsAPI.NET.API.Common.Components
{

    /// <summary>
    /// Distance component
    /// </summary>
    public class Distance
    {

        #region Properties

        /// <summary>
        /// The distance in meters
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Human-readable representation of the distance, displayed in units as used at 
        /// the origin (or as overridden within the units parameter in the request). 
        /// </summary>
        public string Text { get; set; } 

        #endregion
         
    }
}