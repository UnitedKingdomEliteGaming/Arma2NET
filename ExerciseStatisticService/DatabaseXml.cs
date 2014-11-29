using System;
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
        public DateTime Date;

        public EntryXml()
        {

        }
        public EntryXml(string uid)
        {
            UID = uid;
            Score = float.MaxValue;
            Name = "";
            Date = DateTime.Now;
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

        [XmlElement("Entry")]
        public EntryXml[] Entries;

        public ExerciseXml()
        {

        }
        public ExerciseXml(string name)
        {
            Name = name;
            Description = ".";
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
            Description = ".";
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
                XmlSerializer serializer = new XmlSerializer(typeof(DatabaseXml));
                using (StreamWriter streamWriter = new StreamWriter(_Filename, false, System.Text.Encoding.Unicode))
                {
                    serializer.Serialize(streamWriter, this, null);
                    streamWriter.Close();
                }
            }
            catch(Exception ex)
            {
                LOG.Error(ex);
            }
        }
    }
}