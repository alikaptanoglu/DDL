/**************************************************************************\
Copyright (c) 2017 Nirex.0@Gmail.Com

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
using System.Text;
using System.Security.Cryptography;

namespace Drop.Crypt
{
    public static class Decrypt
    {
        public static byte[] AES_Data(byte[] input, string key, string IV)
        {
            key = Utility.IUtility.Shorten(key, 32);
            IV = Utility.IUtility.Shorten(IV, 16);
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.Key = Encoding.ASCII.GetBytes(key);
            aes.IV = Encoding.ASCII.GetBytes(IV);
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CBC;
            ICryptoTransform cryptotransform = aes.CreateDecryptor(aes.Key, aes.IV);
            byte[] decrypted = cryptotransform.TransformFinalBlock(input, 0, input.Length);
            cryptotransform.Dispose();
            return decrypted;
        }
        public static string AES_Text(string input, string key, string IV)
        {
            key = Utility.IUtility.Shorten(key, 32);
            IV = Utility.IUtility.Shorten(IV, 16);
            byte[] encryptedByte = Convert.FromBase64String(input);
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.Key = Encoding.ASCII.GetBytes(key);
            aes.IV = Encoding.ASCII.GetBytes(IV);
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CBC;
            ICryptoTransform cryptotransform = aes.CreateDecryptor(aes.Key, aes.IV);
            byte[] decrypted = cryptotransform.TransformFinalBlock(encryptedByte, 0, encryptedByte.Length);
            cryptotransform.Dispose();
            return Encoding.ASCII.GetString(decrypted);
        }
    }
}
