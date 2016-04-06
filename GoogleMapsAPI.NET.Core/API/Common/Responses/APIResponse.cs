using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoogleMapsAPI.NET.API.Common.Responses
{
    /// <summary>
    /// API response
    /// </summary>
    [DataContract]
    public abstract class APIResponse : ContentTextResponse
    {

        #region Properties

        /// <summary>
        /// Status code
        /// </summary>
        [DataMember(Name = "status")]
        public string Status { get; set; }

        /// <summary>
        /// Error message (Version 1)
        /// API documentation states in some places (https://developers.google.com/maps/documentation/timezone/intro#Responses):
        /// "This field is not guaranteed to be always present, and its content is subject to change."
        /// Sometimes value returned as error_message, other time it's errormessage
        /// </summary>
        [DataMember(Name = "error_message")]
        public string ErrorMessageV1 { get; set; }

        /// <summary>
        /// Error message (Version 2)
        /// API documentation states in some places (https://developers.google.com/maps/documentation/timezone/intro#Responses):
        /// "This field is not guaranteed to be always present, and its content is subject to change."
        /// Sometimes value returned as error_message, other time it's errormessage
        /// </summary>
        [DataMember(Name = "errormessage")]
        public string ErrorMessageV2 { get; set; }

        #endregion

        #region Computed properties

        /// <summary>
        /// Get error message
        /// </summary>
        [JsonIgnore]
        public string ErrorMessage => HasErrorMessage ? ErrorMessageV1 ?? ErrorMessageV2 : null;

        /// <summary>
        /// Has error message
        /// </summary>
        [JsonIgnore]
        public bool HasErrorMessage => ErrorMessageV1 != null || ErrorMessageV2 != null;

        /// <summary>
        /// Is valid
        /// </summary>
        [JsonIgnore]
        public bool IsValid => Status == "OK" || Status == "ZERO_RESULTS";

        /// <summary>
        /// Is over query limit
        /// </summary>
        [JsonIgnore]
        public bool IsOverQueryLimit => Status == "OVER_QUERY_LIMIT";

        /// <summary>
        /// No results found
        /// </summary>
        [JsonIgnore]
        public bool NoResultsFound => Status == "ZERO_RESULTS";

        #endregion

        #region Methods

        /// <summary>
        /// Serialize instance
        /// </summary>
        /// <returns>Serialization result</returns>
        public string Serialize()
        {

            return JsonConvert.SerializeObject(this, Formatting.Indented, 
                new StringEnumConverter());

        }

        #endregion

    }

}