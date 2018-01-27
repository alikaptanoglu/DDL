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

namespace Drop.Crypt
{
    public static class Key
    {
        private static int rnd_seed = 0;
        static Key()
        {
            rnd_seed = DateTime.Now.Second + DateTime.Now.Minute;
        }
        public static string GenerateKey()
        {          
            Random rnd = new Random(rnd_seed);
            string buildup = string.Empty;
            for (int i = 0; i < 32; i++) buildup = buildup + (char)(rnd.Next(0x00, 0xff));
            return buildup;
        }
        public static string[] GenerateKeyRing(int length)
        {
            string[] ring = new string[length];
            for (int i = 0; i < length; i++)
            {
                ring[i] = GenerateKey();
            }
            return ring;
        }
    }
}
