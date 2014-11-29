using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExerciseStatisticService
{
    [Serializable]
    public class ConfigurationXml
    {
        #region nLog instance (LOG)
        protected static readonly NLog.Logger LOG = NLog.LogManager.GetCurrentClassLogger();
        #endregion
		
        public const string FILENAME = "ExerciseStatisticService.xml";
        public string DatabaseFilename = "FullPathToXmlFile";
        public string TransferFilename = "FullPathToTxtFile";
        public string FtpUser = "FtpUsername";
        public string FtpPassword = "FtpPassword";
        public string FtpPath = "FtpPathIncludingFilename.xml";

        public static ConfigurationXml Load()
        {
            ConfigurationXml instance = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ConfigurationXml));
                using (TextReader reader = new StreamReader(FILENAME, System.Text.Encoding.Unicode))
                {
                    instance = serializer.Deserialize(reader) as ConfigurationXml;
                    reader.Close();
                }
            }
            catch
            {
                instance = new ConfigurationXml();
                instance.Save();
            }

            return instance;
        }
        public void Save()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ConfigurationXml));
                using (StreamWriter streamWriter = new StreamWriter(FILENAME, false, System.Text.Encoding.Unicode))
                {
                    serializer.Serialize(streamWriter, this, null);
                    streamWriter.Close();
                }
            }
            catch (Exception ex)
            {
                LOG.Error(ex);
            }
        }
    }
}
