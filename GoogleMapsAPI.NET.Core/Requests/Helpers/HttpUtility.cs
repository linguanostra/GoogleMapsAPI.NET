//
// System.Web.HttpUtility
//
// Authors:
//   Patrik Torstensson (Patrik.Torstensson@labs2.com)
//   Wictor Wilén (decode/encode functions) (wictor@ibizkit.se)
//   Tim Coleman (tim@timcoleman.com)
//   Gonzalo Paniagua Javier (gonzalo@ximian.com)
//
// Copyright (C) 2005-2010 Novell, Inc (http://www.novell.com)
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Web;

namespace GoogleMapsAPI.NET.Requests.Helpers
{
    
    /// <summary>
    /// Http Utility module
    /// </summary>
    public sealed class HttpUtility
    {

        #region Methods

        static char[] GetChars(MemoryStream b, Encoding e)
        {
            return e.GetChars(b.GetBuffer(), 0, (int)b.Length);
        }

        static void WriteCharBytes(IList buf, char ch, Encoding e)
        {
            if (ch > 255)
            {
                foreach (byte b in e.GetBytes(new char[] { ch }))
                    buf.Add(b);
            }
            else
                buf.Add((byte)ch);
        }
        
        static int GetInt(byte b)
        {
            char c = (char)b;
            if (c >= '0' && c <= '9')
                return c - '0';

            if (c >= 'a' && c <= 'f')
                return c - 'a' + 10;

            if (c >= 'A' && c <= 'F')
                return c - 'A' + 10;

            return -1;
        }

        static int GetChar(byte[] bytes, int offset, int length)
        {
            int value = 0;
            int end = length + offset;
            for (int i = offset; i < end; i++)
            {
                int current = GetInt(bytes[i]);
                if (current == -1)
                    return -1;
                value = (value << 4) + current;
            }

            return value;
        }

        /// <summary>
        /// Url encode value
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UrlEncode(string str)
        {
            return UrlEncode(str, Encoding.UTF8);
        }

        /// <summary>
        /// Url encode value
        /// </summary>
        /// <param name="s"></param>
        /// <param name="Enc"></param>
        /// <returns></returns>
        public static string UrlEncode(string s, Encoding Enc)
        {
            if (s == null)
                return null;

            if (s == String.Empty)
                return String.Empty;

            bool needEncode = false;
            int len = s.Length;
            for (int i = 0; i < len; i++)
            {
                char c = s[i];
                if ((c < '0') || (c < 'A' && c > '9') || (c > 'Z' && c < 'a') || (c > 'z'))
                {
                    if (HttpEncoder.NotEncoded(c))
                        continue;

                    needEncode = true;
                    break;
                }
            }

            if (!needEncode)
                return s;

            // avoided GetByteCount call
            byte[] bytes = new byte[Enc.GetMaxByteCount(s.Length)];
            int realLen = Enc.GetBytes(s, 0, s.Length, bytes, 0);
            return Encoding.ASCII.GetString(UrlEncodeToBytes(bytes, 0, realLen));
        }

        /// <summary>
        /// Url encode value
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string UrlEncode(byte[] bytes)
        {
            if (bytes == null)
                return null;

            if (bytes.Length == 0)
                return String.Empty;

            return Encoding.ASCII.GetString(UrlEncodeToBytes(bytes, 0, bytes.Length));
        }

        /// <summary>
        /// Url encode value
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string UrlEncode(byte[] bytes, int offset, int count)
        {
            if (bytes == null)
                return null;

            if (bytes.Length == 0)
                return String.Empty;

            return Encoding.ASCII.GetString(UrlEncodeToBytes(bytes, offset, count));
        }

        /// <summary>
        /// Url encode value
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] UrlEncodeToBytes(string str)
        {
            return UrlEncodeToBytes(str, Encoding.UTF8);
        }

        /// <summary>
        /// Url encode value
        /// </summary>
        /// <param name="str"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public static byte[] UrlEncodeToBytes(string str, Encoding e)
        {
            if (str == null)
                return null;

            if (str.Length == 0)
                return new byte[0];

            byte[] bytes = e.GetBytes(str);
            return UrlEncodeToBytes(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// Url encode value
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static byte[] UrlEncodeToBytes(byte[] bytes)
        {
            if (bytes == null)
                return null;

            if (bytes.Length == 0)
                return new byte[0];

            return UrlEncodeToBytes(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// Url encode value
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static byte[] UrlEncodeToBytes(byte[] bytes, int offset, int count)
        {
            if (bytes == null)
                return null;

            return HttpEncoder.UrlEncodeToBytes(bytes, offset, count);

        }

        /// <summary>
        /// Url encode value
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UrlEncodeUnicode(string str)
        {
            if (str == null)
                return null;

            return Encoding.ASCII.GetString(UrlEncodeUnicodeToBytes(str));
        }

        /// <summary>
        /// Url encode value
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] UrlEncodeUnicodeToBytes(string str)
        {
            if (str == null)
                return null;

            if (str.Length == 0)
                return new byte[0];

            MemoryStream result = new MemoryStream(str.Length);
            foreach (char c in str)
            {
                HttpEncoder.UrlEncodeChar(c, result, true);
            }
            return result.ToArray();
        }

        #endregion // Methods
    }
}
