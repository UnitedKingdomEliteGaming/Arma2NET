using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arma2Net;

namespace ExerciseStatisticAddin
{
    public static class FileManager
    {
        public static bool WriteExerciseEntry(string filename, string category, string exercise, string username, string userid, float score)
        {
            int limit = 1000;
            while (limit > 0)
            {
                limit--;
                try
                {
                    string concatenatedText = category + ";" + exercise + ";" + username + ";" + userid + ";" + score.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                    FileInfo fileInfo = new FileInfo(filename);
                    using (FileStream fileStream = fileInfo.Open(FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                    {
                        StreamWriter sw = new StreamWriter(fileStream, System.Text.UTF8Encoding.UTF8);
                        sw.BaseStream.Position = sw.BaseStream.Length;
                        sw.WriteLine(concatenatedText);
                        sw.Flush();
                        sw.Close();
                        sw.Dispose();
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    Utils.Log(ex.Message);
                }
            }

            return false;
        }
    }
}
