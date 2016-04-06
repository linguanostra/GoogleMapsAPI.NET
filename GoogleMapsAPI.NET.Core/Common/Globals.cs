namespace GoogleMapsAPI.NET.Common
{

    /// <summary>
    /// Globals
    /// </summary>
    public class Globals
    {

        #region Static values

        /// <summary>
        /// Client version
        /// </summary>
        public static string ClientVersion = "3";

        /// <summary>
        /// Use agent
        /// </summary>
        public static string UserAgent = $"GoogleGeoApiClientPython/{ClientVersion}";

        #endregion

        /// <summary>
        /// Default Google MAPS API base url
        /// </summary>
        public const string DefaultBaseUrl = "https://maps.googleapis.com";

        /// <summary>
        /// Retriable status codes
        /// </summary>
        public static int[] RetriableStatuses = {500, 503, 504};
    }
}