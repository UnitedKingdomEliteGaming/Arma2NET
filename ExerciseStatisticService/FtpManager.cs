using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExerciseStatisticService
{
    internal class FtpManager
    {
        #region nLog instance (LOG)
        protected static readonly NLog.Logger LOG = NLog.LogManager.GetCurrentClassLogger();
        #endregion		
        
        private string _Username;
        private string _Password;
        private string _Path;

        public FtpManager(string username, string password, string path)
        {
            _Username = username;
            _Password = password;
            _Path = path;
        }

        public bool UploadFtp(string localFilename)
        {
            try
            {
                FtpWebRequest ftpWebRequest = (FtpWebRequest)FtpWebRequest.Create(_Path);
                ftpWebRequest.Credentials = new NetworkCredential(_Username, _Password);
                ftpWebRequest.UsePassive = true;
                ftpWebRequest.UseBinary = true;
                ftpWebRequest.KeepAlive = true;
                ftpWebRequest.ConnectionGroupName = "ExerciseStatisticServiceConnectionGroupName";
                ftpWebRequest.ServicePoint.Expect100Continue = true;
                ftpWebRequest.ServicePoint.ConnectionLimit = 2;
                ftpWebRequest.Method = WebRequestMethods.Ftp.UploadFile;

                FileInfo fileToCompress = new FileInfo(localFilename);
                using (Stream requestStream = ftpWebRequest.GetRequestStream())
                {
                    using (FileStream fileStream = fileToCompress.OpenRead())
                    {
                        fileStream.CopyTo(requestStream);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                LOG.Error(ex);
                return false;
            }
        }
    }
}
