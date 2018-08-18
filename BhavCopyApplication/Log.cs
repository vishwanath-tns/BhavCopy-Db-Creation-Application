using System;
using System.IO;

namespace BhavCopyApplication
{
    public class Log : IDisposable
    {
        private string logWorkingDirectory;
        private string logFileName;
        StreamWriter w = null;
        public Log(string LogDirectory,string filename)
        {
            logWorkingDirectory = LogDirectory;
            logFileName = filename;
            w = File.AppendText(logWorkingDirectory + @"\" + logFileName);
        }

        
        public void Dispose() => w.Close();

        public void WriteToLog(string logMessage)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            w.WriteLine("  :");
            w.WriteLine("  :{0}", logMessage);
            w.WriteLine ("-------------------------------");
        }

        
    }
}