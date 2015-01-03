using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExerciseStatisticService
{
    #region public class EntryXml
    [Serializable]
    public class EntryXml
    {
        [XmlElement]
        public string UID;

        [XmlElement]
        public string Name;

        [XmlElement]
        public float Score;

        [XmlElement]
        public string Date;

        public void SetDate(DateTime date)
        {
            Date = date.ToString();
        }

        public EntryXml()
        {
        }
        public EntryXml(string uid)
        {
            UID = uid;
            Score = float.MinValue;
            Name = "";
            SetDate(DateTime.Now);
        }
    }
    #endregion
    #region public class ExerciseXml
    [Serializable]
    public class ExerciseXml
    {
        [XmlElement]
        public string Name;

        [XmlElement]
        public string Description;

        [XmlElement]
        public float Required = 0;

        [XmlElement("Entry")]
        public EntryXml[] Entries;

        public ExerciseXml()
        {

        }
        public ExerciseXml(string name)
        {
            Name = name;
            Description = "Unknown";
        }
    }
    #endregion
    #region public class CategoryXml
    [Serializable]
    public class CategoryXml
    {
        [XmlElement]
        public string Name;

        [XmlElement]
        public string Description;

        [XmlElement("Exercise")]
        public ExerciseXml[] Exercises;

        public CategoryXml()
        {

        }
        public CategoryXml(string name)
        {
            Name = name;
            Description = "Unknown";
        }
    }
    #endregion

    [Serializable]
    public class DatabaseXml
    {
        #region nLog instance (LOG)
        protected static readonly NLog.Logger LOG = NLog.LogManager.GetCurrentClassLogger();
        #endregion
		
        private string _Filename;
        [XmlIgnore]
        public string Filename
        {
            get
            {
                return _Filename;
            }
        }              
        


        [XmlElement]
        public DateTime LastUpdate;

        [XmlElement("Category")]
        public CategoryXml[] Categories;

        public static DatabaseXml Load(string filename)
        {
            DatabaseXml instance = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(DatabaseXml));
                using (TextReader reader = new StreamReader(filename, System.Text.Encoding.Unicode))
                {
                    instance = serializer.Deserialize(reader) as DatabaseXml;
                    reader.Close();
                }
            }
            catch
            {
                instance = new DatabaseXml();
            }

            instance._Filename = filename;
            return instance;
        }

        public void Save()
        {
            try
            {
                XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                xmlWriterSettings.Indent = true;
                xmlWriterSettings.Encoding = System.Text.Encoding.Unicode;
                XmlSerializer serializer = new XmlSerializer(typeof(DatabaseXml));
                using (XmlWriter xmlWriter = XmlWriter.Create(_Filename, xmlWriterSettings))
                {
                    xmlWriter.WriteProcessingInstruction("xml-stylesheet", "type=\"text/xsl\" href=\"" + System.IO.Path.GetFileNameWithoutExtension(_Filename) + ".xsl\"");
                    serializer.Serialize(xmlWriter, this, null);
                    xmlWriter.Close();
                }
            }
            catch(Exception ex)
            {
                LOG.Error(ex);
            }
        }
    }
}