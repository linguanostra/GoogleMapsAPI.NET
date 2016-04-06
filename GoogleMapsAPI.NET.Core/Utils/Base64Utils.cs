using System;
using System.Text;

namespace GoogleMapsAPI.NET.Utils
{

    /// <summary>
    /// Base-64 utils
    /// </summary>
    public class Base64Utils
    {

        #region Static methods

        /// <summary>
        /// Encode string s using the URL- and filesystem-safe alphabet, which substitutes - instead of + and _ instead of 
        /// / in the standard Base64 alphabet. The result can still contain =.
        /// See: https://docs.python.org/2/library/base64.html#base64.urlsafe_b64encode
        /// </summary>
        /// <param name="value">Value to encode</param>
        /// <returns>Result</returns>
        public static string UrlSafeBase64Encode(string value)
        {

            return UrlSafeBase64Encode(Encoding.ASCII.GetBytes(value));

        }

        /// <summary>
        /// Encode string s using the URL- and filesystem-safe alphabet, which substitutes - instead of + and _ instead of 
        /// / in the standard Base64 alphabet. The result can still contain =.
        /// See: https://docs.python.org/2/library/base64.html
        /// http://stackoverflow.com/questions/26353710/how-to-achieve-base64-url-safe-encoding-in-c
        /// </summary>
        /// <param name="valueBytes">Value bytes to encode</param>
        /// <returns>Result</returns>
        public static string UrlSafeBase64Encode(byte[] valueBytes)
        {

            return Convert.ToBase64String(valueBytes)
                .Replace('+', '-').Replace('/', '_');

        }

        /// <summary>
        /// Decode string s using the URL- and filesystem-safe alphabet, which substitutes - instead of + and _ instead 
        /// of / in the standard Base64 alphabet.
        /// See: https://docs.python.org/2/library/base64.html
        /// http://stackoverflow.com/questions/26353710/how-to-achieve-base64-url-safe-encoding-in-c
        /// </summary>
        /// <param name="value">Value to decode</param>
        /// <returns>Result</returns>
        public static string UrlSafeBase64Decode(string value)
        {

            var incoming = value.Replace('_', '/').Replace('-', '+');

            switch (value.Length%4)
            {
                case 2:
                    incoming += "==";
                    break;
                case 3:
                    incoming += "=";
                    break;
            }
            byte[] bytes = Convert.FromBase64String(incoming);
            return Encoding.ASCII.GetString(bytes);

        }

        #endregion

    }
}