using System.Collections.Specialized;

namespace GoogleMapsAPI.NET.Requests
{
    
    /// <summary>
    /// Query params
    /// </summary>
    public class QueryParams : NameValueCollection
    {

        #region Static methods

        /// <summary>
        /// Get empty query params
        /// </summary>
        /// <returns>Result</returns>
        public static QueryParams Empty()
        {
            return new QueryParams();
        }

        #endregion

    }

}