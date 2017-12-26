using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOSerialize
{
    public class MyIOClass
    {
        private static string LogPath = ConfigurationManager.AppSettings["LogPath"];
        private static string LogMovePath = ConfigurationManager.AppSettings["LogMovePath"];
        /// <summary>
        /// 获取当前程序路径
        /// </summary>
        private static string LogPath2 = AppDomain.CurrentDomain.BaseDirectory;

        public static void show()
        {
            if (!Directory.Exists(LogPath))//检测文件夹是否存在
            {
                DirectoryInfo directoryInfo = Directory.CreateDirectory(LogPath);//一次性创建全部的子路径
                Directory.Move(LogPath, LogMovePath);//移动  原文件夹就不在了
                Directory.Delete(LogMovePath);//删除
            }
            DirectoryInfo directory = new DirectoryInfo(LogPath);//不存在不报错  注意exists属性

            if (File.Exists(Path.Combine(LogPath, "info.txt")))
            {
                FileInfo fileInfo = new FileInfo(Path.Combine(LogPath, "info.txt"));
            }
            {
                string fileName = Path.Combine(LogPath, "log.txt");
                bool isExists = File.Exists(fileName);
                if (!isExists)
                {
                    Directory.CreateDirectory(LogPath);
                    using (FileStream fileStream = File.Create(fileName))//打开文件流 （创建文件并写入）
                    {
                        string name = "12345567778890";
                        byte[] bytes = Encoding.Default.GetBytes(name);
                        fileStream.Write(bytes, 0, bytes.Length);
                        fileStream.Flush();
                    }
                    using (FileStream fileStream = File.Create(fileName))//打开文件流 （创建文件并写入）
                    {
                        StreamWriter sw = new StreamWriter(fileStream);
                        sw.WriteLine("1234567890");
                        sw.Flush();
                    }

                    using (StreamWriter sw = File.AppendText(fileName))//流写入器（创建/打开文件并写入）
                    {
                        string msg = "今天是Course6IOSerialize，今天上课的人有55个人";
                        sw.WriteLine(msg);
                        sw.Flush();
                    }
                    using (StreamWriter sw = File.AppendText(fileName))//流写入器（创建/打开文件并写入）
                    {
                        string name = "0987654321";
                        byte[] bytes = Encoding.Default.GetBytes(name);
                        sw.BaseStream.Write(bytes, 0, bytes.Length);
                        sw.Flush();
                    }

                    string[] stringArray = File.ReadAllLines(fileName);
                    string fileString = File.ReadAllText(fileName);
                    Byte[] byteArray = File.ReadAllBytes(fileName);
                    fileString = System.Text.Encoding.UTF8.GetString(byteArray);


                }
            }
        }

        public static void WriteLog(string msg)
        {
            StreamWriter streamWriter = null;
            try
            {
                string logDirectotyPath = LogPath;
                if (!Directory.Exists(logDirectotyPath))
                {
                    Directory.CreateDirectory(logDirectotyPath);
                }
                string logPath = Path.Combine(logDirectotyPath, "log.txt");
                streamWriter = File.AppendText(logPath);
                streamWriter.WriteLine(string.Format("{0}:{1}", DateTime.Now, msg));
                streamWriter.WriteLine("***************************************************");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);//log
            }
            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Flush();
                    streamWriter.Close();
                    streamWriter.Dispose();
                }
            }
        }
    }
}
