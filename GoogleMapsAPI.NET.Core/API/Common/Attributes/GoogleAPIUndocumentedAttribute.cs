using System;

namespace GoogleMapsAPI.NET.API.Common.Attributes
{

    /// <summary>
    /// Attribute indicating a given item is undocumented in the Google Maps API documentation.
    /// </summary>
    public class GoogleAPIUndocumentedAttribute : Attribute
    {

        #region Properties

        /// <summary>
        /// Date when documentation was checked to identify this issue
        /// </summary>
        public DateTime DateChecked { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="yearChecked">Year when documentation was checked to identify this issue</param>
        /// <param name="monthChecked">Month when documentation was checked to identify this issue</param>
        /// <param name="dayChecked">Day when documentation was checked to identify this issue</param>
        public GoogleAPIUndocumentedAttribute(int yearChecked, int monthChecked, int dayChecked)
        {
            DateChecked = new DateTime(yearChecked, monthChecked, dayChecked);
        }

        #endregion
                 
    }

}