using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TX.HomeWork.Model;
using System.IO;

namespace TX.HomeWork.Common
{
    public class JsonHelper
    {
        private static string configSomeThingPath = Path.Combine("../../config", "Something.json");

        public static List<ConfigThingModel> getConfigThing()
        {
            string configJsonString = GetConfigString();
            List<ConfigThingModel> list = JsonConvert.DeserializeObject<List<ConfigThingModel>>(configJsonString);
            return list;
        }

        private static string GetConfigString()
        {
            using (FileStream fileStream = new FileStream(configSomeThingPath, FileMode.Open, FileAccess.Read))
            {
                long fslength = fileStream.Length;
                byte[] byteList = new byte[fslength];
                fileStream.Read(byteList, 0, byteList.Length);
                return System.Text.Encoding.Default.GetString(byteList);
            }
        }
    }
}
