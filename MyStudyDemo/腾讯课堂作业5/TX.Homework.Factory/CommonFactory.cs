using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TX.Homework.Factory
{
    public class CommonFactory
    {
        public static T GetConfigData<T>(string fileName)
        {
            try
            {
                string menuJsonStr = GetDishDetailJsonString(fileName);
                return JsonConvert.DeserializeObject<T>(menuJsonStr);
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        private static string GetDishDetailJsonString(string fileName)
        {
            string jsonStr = string.Empty;
            if (string.IsNullOrWhiteSpace(fileName))
                return jsonStr;

            string directoryPath = ConfigurationManager.AppSettings["ConfigJsonDicPath"].ToString();
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            using (FileStream fileStream = new FileStream(Path.Combine(directoryPath, fileName), FileMode.Open, FileAccess.Read))
            {
                byte[] byteStr = new byte[fileStream.Length];
                fileStream.Read(byteStr, 0, byteStr.Length);

                jsonStr = System.Text.Encoding.Default.GetString(byteStr);
                fileStream.Close();
            }

            return jsonStr;
        }
    }
}
