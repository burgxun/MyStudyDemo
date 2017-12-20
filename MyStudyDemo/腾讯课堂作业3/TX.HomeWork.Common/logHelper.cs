using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TX.HomeWork.Common
{
    public class LogHelper
    {
        private static readonly string directoryPth = Path.Combine("../../Log/");
        private static readonly string logFileName = "SystemLog.txt";
        private static object logLock = new object();

        public static void WriteLog(string logString)
        {
            lock (logLock)
            {
                if (Directory.Exists(directoryPth) == false)
                {
                    Directory.CreateDirectory(directoryPth);
                }
                string filePath = Path.Combine(directoryPth, logFileName);
                using (FileStream fileStream = new FileStream(filePath, FileMode.Append))
                {
                    byte[] writeByte = Encoding.Default.GetBytes(logString+ "\r\n"); 
                    fileStream.Write(writeByte, 0, writeByte.Length);
                    fileStream.Flush();
                    fileStream.Dispose();
                }
            }
        }
    }
}
