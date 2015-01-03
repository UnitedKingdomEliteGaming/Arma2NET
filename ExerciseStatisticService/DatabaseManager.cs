using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

namespace ExerciseStatisticService
{
    internal class DatabaseManager: IDisposable
    {
        #region nLog instance (LOG)
        protected static readonly NLog.Logger LOG = NLog.LogManager.GetCurrentClassLogger();
        #endregion		

        private ConfigurationXml _Configuration;
        private DatabaseXml _Database;
        private FileManager _FileManager;
        private FtpManager _FtpManager;

        public DatabaseManager(ConfigurationXml configuration)
        {
            if (configuration == null)
                throw new ArgumentNullException();

            _Configuration = configuration;

            try { LOG.Info("Loading XML-File from '" + Path.GetFullPath(_Configuration.DatabaseFilename) + "'"); }
            catch { LOG.Error("Unable to detect fullpath of XML-File: "); }
            try { LOG.Info("Loading TXT-File from '" + Path.GetFullPath(_Configuration.TransferFilename) + "'"); }
            catch { LOG.Error("Unable to detect fullpath of TXT-File: "); }

            _Database = DatabaseXml.Load(_Configuration.DatabaseFilename);
            _FtpManager = new FtpManager(_Configuration.FtpUser, _Configuration.FtpPassword, _Configuration.FtpPath);
            _FileManager = new FileManager(_Configuration.TransferFilename, new FileManager.StringDelegate(ehFileManager_OnNewExerciseDetected));
        }
        #region IDisposable Member
        ~DatabaseManager()
        {
            Dispose(false);
        }
        private bool _Disposed = false;
        private bool _Disposing = false;
        public bool Disposed
        {
            get { return _Disposed; }
        }
        public bool Disposing
        {
            get { return _Disposing; }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            _Disposing = true;
            OnDispose(disposing);
            _Disposing = false;
            _Disposed = true;
        }
        #endregion
        protected virtual void OnDispose(bool disposing)
        {
            _FileManager.Dispose();

            lock (_Database)
            {
                try { _Database.Save(); }
                catch { }
            }
        }

        private CategoryXml GetCategory(string name)
        {
            System.Diagnostics.Debug.Assert(_Database != null);

            if (_Database.Categories == null)
            {
                _Database.Categories = new CategoryXml[1];
                _Database.Categories[0] = new CategoryXml(name);
                return _Database.Categories[0];
            }

            foreach (CategoryXml category in _Database.Categories)
            {
                if (category.Name == name)
                    return category;
            }

            CategoryXml appendedCategory = new CategoryXml(name);
            CategoryXml[] categories = new CategoryXml[_Database.Categories.Length + 1];
            categories[categories.Length - 1] = appendedCategory;
            _Database.Categories.CopyTo(categories, 0);
            _Database.Categories = categories;

            return appendedCategory;
        }
        private ExerciseXml GetExercise(string categoryName, string exerciseName)
        {
            CategoryXml category = GetCategory(categoryName);

            if (category.Exercises == null)
            {
                category.Exercises = new ExerciseXml[1];
                category.Exercises[0] = new ExerciseXml(exerciseName);
                return category.Exercises[0];
            }

            foreach (ExerciseXml exercise in category.Exercises)
                if (exercise.Name == exerciseName)
                    return exercise;

            ExerciseXml appendedExercise = new ExerciseXml(exerciseName);
            ExerciseXml[] exercises = new ExerciseXml[category.Exercises.Length + 1];
            exercises[exercises.Length - 1] = appendedExercise;
            category.Exercises.CopyTo(exercises, 0);
            category.Exercises = exercises;

            return appendedExercise;
        }
        private EntryXml GetEntry(string categoryName, string exerciseName, string userId)
        {
            ExerciseXml exercise = GetExercise(categoryName, exerciseName);

            if (exercise.Entries == null)
            {
                exercise.Entries = new EntryXml[1];
                exercise.Entries[0] = new EntryXml(userId);
                return exercise.Entries[0];
            }

            foreach (EntryXml entry in exercise.Entries)
                if (entry.UID == userId)
                    return entry;

            EntryXml appendedEntry = new EntryXml(userId);
            EntryXml[] entries = new EntryXml[exercise.Entries.Length + 1];
            entries[entries.Length - 1] = appendedEntry;
            exercise.Entries.CopyTo(entries, 0);
            exercise.Entries = entries;

            return appendedEntry;
        }
        private void UpdateExerciseInformation(string category, string exercise, string username, string userid, float score)
        {
            try
            {
                if (_Disposed)
                    return;

                if (_Database == null)
                    return;
                
                LOG.Info("Update Exercise: category:" + category + " exercise:" + exercise + " username:" + username + " userid:" + userid + " score:" + score);

                lock (_Database)
                {
                    // Sicher stellen, dass dieser Eintrag auch wirklich gültig ist. Wenn wir ihn einmal suchen, wird er auch erzeugt.
                    if (score <= 1)
                        return;
                    if ((string.IsNullOrWhiteSpace(userid)) || (userid.Length < 5))
                        return;
                    if (string.IsNullOrWhiteSpace(username))
                        return;
                    if (string.IsNullOrWhiteSpace(category))
                        return;
                    if (string.IsNullOrWhiteSpace(exercise))
                        return;

                    // Eintrag suchen/erstellen
                    EntryXml entry = GetEntry(category, exercise, userid); // Never null

                    // Eintrag anpassen
                    if (entry.Score < score)
                    {
                        LOG.Info("New highscore!");
                        entry.Name = username;
                        entry.Score = score;
                        entry.SetDate(DateTime.Now);

                        _Database.LastUpdate = DateTime.Now;
                        _Database.Save();
                        _FtpManager.UploadFtp(_Configuration.DatabaseFilename);
                    }
                    else
                        LOG.Info("No highscore!");
                }

            }
            catch (Exception ex)
            {
                LOG.Error(ex);
            }
        }

        private void ehFileManager_OnNewExerciseDetected(string text)
        {
            try
            {
                // Text prüfen
                if (string.IsNullOrWhiteSpace(text))
                {
                    LOG.Warn("Invalid line: text is null");
                    return;
                }

                // Text zerlegen
                string[] splittedText = text.Split(new char[] { ';' });

                // Zerlegten Text prüfen
                if ((splittedText == null) || (splittedText.Length != 5))
                {
                    LOG.Warn("Invalid line: splitted == null || length != 5");
                    return;
                }
                if (string.IsNullOrEmpty(splittedText[0]))
                {
                    LOG.Warn("Invalid line: splitted[0] is emtpy");
                    return;
                }
                string category = splittedText[0];
                if (string.IsNullOrEmpty(splittedText[1]))
                {
                    LOG.Warn("Invalid line: splitted[1] is emtpy");
                    return;
                }
                string exercise = splittedText[1];
                if (string.IsNullOrEmpty(splittedText[2]))
                {
                    LOG.Warn("Invalid line: splitted[2] is emtpy");
                    return;
                }
                string username = splittedText[2];
                if (string.IsNullOrEmpty(splittedText[3]) || (splittedText[3].Length < 5))
                {
                    LOG.Warn("Invalid line: splitted[3] is emtpy || length < 5");
                    return;
                }
                string userid = splittedText[3];

                float score = -1.0f;
                try { score = Convert.ToSingle(splittedText[4], System.Globalization.CultureInfo.InvariantCulture); }
                catch { score = -1.0f; }
                if (score < 1.0f)
                {
                    LOG.Warn("Invalid line: score is no float || or score < 1.0");
                    return;
                }

                // Übungsdaten an die Datenbank weiterreichen
                UpdateExerciseInformation(category, exercise, username, userid, score);
            }
            catch (Exception ex)
            {
                LOG.Error(ex);
            }
        }
    }
}
