using System;
using GoogleMapsAPI.NET.Requests;
using GoogleMapsAPI.NET.Requests.Interfaces;
using Rhino.Mocks;
using Rhino.Mocks.Interfaces;

namespace GoogleMapsAPI.NET.Tests.API.Extensions
{

    /// <summary>
    /// Web request utility tests extensions
    /// </summary>
    public static class WebRequestUtilityTestsExtensions
    {

        #region Extension methods

        /// <summary>
        /// Assert the Get method for the web request utility was called with given url
        /// </summary>
        /// <param name="webRequestUtil">Web request utility</param>
        /// <param name="url">Url</param>
        /// <param name="useCredentials">Use credentials from client</param>
        public static void AssertGetWasCalledWithUrl(this IWebRequestUtility webRequestUtil, string url, bool useCredentials = true)
        {

            // Normalize url with credentials, if required
            var normalizedUrl = useCredentials ? webRequestUtil.AppendCredentialsToUrl(url) : url;

            // Assertion
            webRequestUtil.AssertWasCalled(utility =>
                utility.Get(
                    Arg<string>.Is.Equal(normalizedUrl),
                    Arg<RequestConfig>.Is.Anything));

        }

        /// <summary>
        /// Assert the Get method for the web request utility was called once with given url
        /// </summary>
        /// <param name="webRequestUtil">Web request utility</param>
        /// <param name="url">Url</param>
        /// <param name="useCredentials">Use credentials from client</param>
        public static void AssertGetWasCalledOnceWithUrl(this IWebRequestUtility webRequestUtil, string url, bool useCredentials = true)
        {

            webRequestUtil.AssertGetWasCalledWithUrl(url, options => options.Repeat.Once(), useCredentials);

        }

        /// <summary>
        /// Assert the Get method for the web request utility was called with given url
        /// </summary>
        /// <param name="webRequestUtil">Web request utility</param>
        /// <param name="url">Url</param>
        /// <param name="options">Options</param>
        /// <param name="useCredentials">Use credentials from client</param>
        public static void AssertGetWasCalledWithUrl(this IWebRequestUtility webRequestUtil, string url, Action<IMethodOptions<object>> options, bool useCredentials = true)
        {

            // Normalize url with credentials, if required
            var normalizedUrl = useCredentials ? webRequestUtil.AppendCredentialsToUrl(url) : url;

            // Assertion
            webRequestUtil.AssertWasCalled(utility =>
                utility.Get(
                    Arg<string>.Is.Equal(normalizedUrl),
                    Arg<RequestConfig>.Is.Anything),
                options);

        }

        #endregion

    }
}