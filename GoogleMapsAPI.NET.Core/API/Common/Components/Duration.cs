namespace GoogleMapsAPI.NET.API.Common.Components
{
    /// <summary>
    /// Duration component
    /// </summary>
    public class Duration
    {

        #region Properties

        /// <summary>
        /// The duration in seconds
        /// </summary>
        public long Value { get; set; }

        /// <summary>
        /// Human-readable representation of the duration
        /// </summary>
        public string Text { get; set; } 

        #endregion
         
    }
}