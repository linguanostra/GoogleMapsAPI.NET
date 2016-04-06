using GoogleMapsAPI.NET.API.Client;
using GoogleMapsAPI.NET.API.Client.Interfaces;
using GoogleMapsAPI.NET.Tests.Config;
using Rhino.Mocks;

namespace GoogleMapsAPI.NET.Tests.API.Common
{

    /// <summary>
    /// API tests
    /// </summary>
    public class APITests
    {

        #region Methods

        /// <summary>
        /// Get API client (with API key)
        /// </summary>
        /// <param name="apiKey">API key</param>
        /// <param name="clientConfig">Client config</param>
        /// <returns>Client</returns>
        public IMapsAPIClient GetAPIClient(string apiKey = TestsStaticConfiguration.GoogleMapsAPIKey, MapsAPIClientConfig clientConfig = null)
        {
            
            return new MapsAPIClient(apiKey, clientConfig??MapsAPIClientConfig.Default());

        }

        /// <summary>
        /// Get mocked API client (with API key)
        /// </summary>
        /// <param name="apiKey">API key</param>
        /// <param name="clientConfig">Client config</param>
        /// <returns>Client</returns>
        public IMapsAPIClient GetMockedAPIClient(string apiKey = TestsStaticConfiguration.GoogleMapsAPIKey, MapsAPIClientConfig clientConfig = null)
        {

            return MockRepository.GenerateMock<MapsAPIClient>(apiKey, clientConfig??MapsAPIClientConfig.Default());

        }

        /// <summary>
        /// Get API client (with enteprrise credentials)
        /// </summary>
        /// <param name="clientId">Client Id</param>
        /// <param name="clientSecret">Client secret</param>
        /// <param name="clientConfig">Client config</param>
        /// <returns>Client</returns>
        public IMapsAPIClient GetAPIClient(string clientId, string clientSecret, MapsAPIClientConfig clientConfig = null)
        {
            
            return new MapsAPIClient(clientId, clientSecret, clientConfig??MapsAPIClientConfig.Default());

        } 

        /// <summary>
        /// Get mocked API client (with enteprrise credentials)
        /// </summary>
        /// <param name="clientId">Client Id</param>
        /// <param name="clientSecret">Client secret</param>
        /// <param name="clientConfig">Client config</param>
        /// <returns>Client</returns>
        public IMapsAPIClient GetMockedAPIClient(string clientId, string clientSecret, MapsAPIClientConfig clientConfig = null)
        {

            return MockRepository.GenerateMock<MapsAPIClient>(clientId, clientSecret, clientConfig ?? MapsAPIClientConfig.Default());

        } 

        #endregion
         
    }
}