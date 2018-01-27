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
using System.IO;

namespace Drop.FileManager
{
    public class NManager
    {
        private string files;
        public string[] GetFiles(string[] directories)
        {
            string[] splitstr = new string[1];
            splitstr[0] = "\n";

            string retStr = string.Empty;
            foreach (string dir in directories)
            {
                foreach (string file in Directory.GetFiles(dir))
                {
                    retStr += file + "\n";
                }
            }

            return retStr.Split(splitstr, StringSplitOptions.RemoveEmptyEntries);
        }

        public string[] GetFolders(string path)
        {
            string[] splitstr = new string[1];
            splitstr[0] = "\n";
            return GetAllFolders(path).Split(splitstr, StringSplitOptions.RemoveEmptyEntries);
        }

        private string GetAllFolders(string path)
        {
            foreach (string f in Directory.GetDirectories(path))
            {
                if (
                    HasWritePermissionOnDir(f)
                    && !f.Contains("Windows")
                    && !f.Contains("Program Files")
                    && !f.Contains("Program Files (x86)")
                    && !f.Contains("ProgramData")
                    && !f.Contains("AppData")
                    && !f.Contains("Microsoft")
                    && !f.Contains("All Users")
                    )
                {
                    files += f + "\n";
                    GetAllFolders(f);
                }
            }
            return files;
        }
        private bool HasWritePermissionOnDir(string path)
        {
            try
            {
                Directory.GetDirectories(path);
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}