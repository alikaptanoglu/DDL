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
using System.ComponentModel;
using System.Diagnostics;

namespace Drop.Core
{
    public class ProcessAgent
    {
        private string[] processes;
        private BackgroundWorker bgw = new BackgroundWorker();

        private bool shouldRun;

        public bool ShouldRun
        {
            get { return shouldRun; }
            set { shouldRun = value; }
        }

        public ProcessAgent(string[] processList)
        {
            processes = new string[processList.Length];
            Array.Copy(processList, processes, processList.Length);

            bgw.DoWork += Bgw_DoWork;
            bgw.RunWorkerCompleted += Bgw_RunWorkerCompleted;
        }

        public void Start()
        {
            ShouldRun = true;
            if (!bgw.IsBusy) { bgw.RunWorkerAsync(); }
        }
        public void Stop()
        {
            ShouldRun = false;
        }

        private void Bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(100);
        }
        private void Bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            for (int i = 0; i < processes.Length; i++)
            {
                foreach (var process in Process.GetProcessesByName(processes[i]))
                {
                    process.Kill();
                }
            }
            if (shouldRun) { bgw.RunWorkerAsync(); }
        }
    }
}
