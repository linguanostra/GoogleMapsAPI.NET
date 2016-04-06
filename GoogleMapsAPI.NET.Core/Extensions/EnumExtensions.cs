using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace GoogleMapsAPI.NET.Extensions
{

    /// <summary>
    /// Enum extensions
    /// </summary>
    public static class EnumExtensions
    {

        #region Extension methods

        /// <summary>
        /// Get value serialization name
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>Result name</returns>
        public static string GetSerializationName(this Enum value)
        {

            // Get enum attribute
            var enumAttribute = value.GetCustomAttribute<EnumMemberAttribute>();

            // Ensure it was found
            if (enumAttribute != null)
            {
                return enumAttribute.Value;
            }

            // Not found
            throw new ArgumentOutOfRangeException(nameof(value));

        }

        /// <summary>
        /// Get custom attribute defined on given enum value
        /// </summary>
        /// <typeparam name="TAttribute">Attribute type</typeparam>
        /// <param name="enumValue">Enum value</param>
        /// <returns>Matching custom attribute. Null if attribute not found.</returns>
        public static TAttribute GetCustomAttribute<TAttribute>(this Enum enumValue) where TAttribute : Attribute
        {

            // Get member info for enum value
            var memberInfo = enumValue.GetType().GetMember(enumValue.ToString()).FirstOrDefault();

            // Return attribute
            return (TAttribute)memberInfo?.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault();

        }

        /// <summary>
        /// Get ordered selected enum flags list
        /// </summary>
        /// <param name="value">Enum value</param>
        /// <returns>Result list</returns>
        public static IEnumerable<Enum> GetFlags(this Enum value)
        {
            return
                Enum.GetValues(value.GetType())
                    .Cast<Enum>()
                    .Where(value.HasFlag)
                    .OrderBy(x => x.GetSerializationName());
        }

        #endregion

    }
}