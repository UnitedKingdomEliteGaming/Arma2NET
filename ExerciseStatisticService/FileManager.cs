using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExerciseStatisticService
{
    public class FileManager: IDisposable
    {
        #region nLog instance (LOG)
        protected static readonly NLog.Logger LOG = NLog.LogManager.GetCurrentClassLogger();
        #endregion
		
        public delegate void StringDelegate(string text);

        private string _Filename;
        private FileSystemWatcher _FileSystemWatcher;
        private StringDelegate _NewExerciseDetected;

        public FileManager(string filename, StringDelegate onNewExerciseDetected)
        {
            if (onNewExerciseDetected == null)
                throw new ArgumentNullException("onNewExerciseDetected");
            if (string.IsNullOrWhiteSpace(filename))
                throw new ArgumentNullException("filename");

            try
            {
                _NewExerciseDetected = onNewExerciseDetected;

                _Filename = Path.GetFullPath(filename);

                _FileSystemWatcher = new FileSystemWatcher();
                _FileSystemWatcher.IncludeSubdirectories = false;
                _FileSystemWatcher.NotifyFilter = NotifyFilters.LastWrite;
                _FileSystemWatcher.Filter = Path.GetFileName(_Filename);
                _FileSystemWatcher.Path = Path.GetDirectoryName(_Filename);
                _FileSystemWatcher.Changed += new FileSystemEventHandler(_FileSystemWatcher_Changed);
                _FileSystemWatcher.Error += new ErrorEventHandler(_FileSystemWatcher_Error);
                _FileSystemWatcher.EnableRaisingEvents = true;
            }
            catch(Exception ex)
            {
                LOG.Error(ex);
                _FileSystemWatcher = null;
            }           
        }
        #region IDisposable Member
        ~FileManager()
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
            if (_FileSystemWatcher != null)
                _FileSystemWatcher.Dispose();
        }

        private void _FileSystemWatcher_Error(object sender, ErrorEventArgs e)
        {
            LOG.Error(e.GetException());
        }
        private void _FileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            ReadAndClearFile(_Filename);
        }

        private void ReadAndClearFile(string filename)
        {
            int limit = 10000;

            while (limit > 0)
            {
                limit--; // Worst case Limiter

                try
                {
                    FileInfo fileInfo = new FileInfo(filename);
                    using (FileStream fileStream = fileInfo.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
                    {
                        if (fileStream.Length > 0)
                        {
                            // Erst die Einträge lesen
                            StreamReader streamReader = new StreamReader(fileStream, System.Text.UTF8Encoding.UTF8);
                            string text;
                            while ((text = streamReader.ReadLine()) != null)
                            {
                                try
                                {
                                    LOG.Info("Read new line: " + text);
                                    _NewExerciseDetected(text);
                                }
                                catch (Exception ex)
                                {
                                    LOG.Error(ex);
                                }
                            }

                            // Dann die Datei "leeren"
                            using (StreamWriter streamWriter = new StreamWriter(fileStream, System.Text.UTF8Encoding.UTF8))
                            {
                                streamWriter.BaseStream.Position = 0;
                                streamWriter.BaseStream.SetLength(0);
                            }
                        }
                    }

                    return;
                }
                catch 
                {
                }
            }

            LOG.Warn("Unable to open file after 1000 attempts");
        }
    }
}
