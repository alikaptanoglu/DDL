/**************************************************************************\
Copyright (c) 2018 Nirex.0@Gmail.Com

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
\**************************************************************************/

using System;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Drop.Core
{
    public static class HashAgent
    {
        public static string SHA1(string input)
        {
            using (SHA1 hash = System.Security.Cryptography.SHA1.Create())
            {
                return string.Join("", hash.ComputeHash(Encoding.UTF8.GetBytes(input)).Select(item => item.ToString("x2")));
            }
        }
        public static string SHA256(string input)
        {
            using (SHA256 hash = System.Security.Cryptography.SHA256.Create())
            {
                return string.Join("", hash.ComputeHash(Encoding.UTF8.GetBytes(input)).Select(item => item.ToString("x2")));
            }
        }
        public static string SHA384(string input)
        {
            using (SHA384 hash = System.Security.Cryptography.SHA384.Create())
            {
                return string.Join("", hash.ComputeHash(Encoding.UTF8.GetBytes(input)).Select(item => item.ToString("x2")));
            }
        }
        public static string SHA512(string input)
        {
            using (SHA512 hash = SHA512Managed.Create())
            {
                return string.Join("", hash.ComputeHash(Encoding.UTF8.GetBytes(input)).Select(item => item.ToString("x2")));
            }
        }
        public static string MD5Lower(string input, string splitter = "")
        {
            byte[] encoded = new UTF8Encoding().GetBytes(input);
            byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encoded);
            return BitConverter.ToString(hash).Replace("-", splitter).ToLower();
        }
        public static string MD5Upper(string input, string splitter = "")
        {
            byte[] encoded = new UTF8Encoding().GetBytes(input);
            byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encoded);
            return BitConverter.ToString(hash).Replace("-", splitter);
        }
    }
}
