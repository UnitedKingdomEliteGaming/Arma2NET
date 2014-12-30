using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistentCampaign2Addin
{
    internal static class XmlTools
    {
        public static T Load<T>(string filename) where T : class, new()
        {
            T instance = null;
            try
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                using (System.IO.TextReader reader = new System.IO.StreamReader(filename, System.Text.Encoding.Unicode))
                {
                    instance = serializer.Deserialize(reader) as T;
                    reader.Close();
                }
            }
            catch
            {
                instance = new T();
                XmlTools.Save(filename, instance);
            }

            return instance;
        }
        public static void Save<T>(string filename, T cfg) where T : class, new()
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            using (System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(filename, false, System.Text.Encoding.Unicode))
            {
                serializer.Serialize(streamWriter, cfg, null);
                streamWriter.Close();
            }
        }
    }
}
