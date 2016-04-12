using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleMapsAPI.NET.Tests.Initialization
{

    /// <summary>
    /// Client library tests initializer
    /// </summary>
    public class ClientLibraryTestsInitializer
    {

        #region Test methods

        /// <summary>
        /// Initialize tests
        /// </summary>
        /// <param name="context">Test context</param>
        [AssemblyInitialize]
        public static void InitializeTests(TestContext context)
        {
        }

        /// <summary>
        /// Cleanup tests
        /// </summary>
        [AssemblyCleanup]
        public static void CleanupTests()
        {            
        }        

        #endregion

    }

}