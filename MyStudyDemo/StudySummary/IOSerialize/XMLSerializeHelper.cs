using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace IOSerialize
{
    public class XMLSerializeHelper
    {
        public static string ObjectToXML<T>(T model)
        {
            string xMLString = string.Empty;

            Stream stream = new MemoryStream();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            xmlSerializer.Serialize(stream, model);
            stream.Position = 0;
            using (StreamReader streamReader = new StreamReader(stream))
            {
                xMLString = streamReader.ReadToEnd();
                streamReader.Dispose();
            }
            return xMLString;
        }

        public static T XMLToObject<T>(string xml)
        {
            using (MemoryStream stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(xml)))
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(T));
                return (T)xmlFormat.Deserialize(stream);
            }
        }
    }
}
