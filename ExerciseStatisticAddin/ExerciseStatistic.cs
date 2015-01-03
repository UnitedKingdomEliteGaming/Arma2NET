using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arma2Net;

namespace ExerciseStatisticAddin
{
    [Addin("ExerciseStatistic", Version = "1.1", Author = "Pixinger", Description = "for Teamkommando.net")]
    public class ExerciseStatistic : Addin
    {
        public override string Invoke(string args, int maxResultSize)
        {
            if (string.IsNullOrWhiteSpace(args))
                return "ERROR_ARGS_NULL";

            string[] split;
            try
            {
                split = args.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            }
            catch(Exception ex)
            {
                Utils.Log("Exception: " + ex.Message);
                return "ERROR_SPLIT_EXCEPTION";
            }

            if (split == null)
                return "ERROR_SPLIT_NULL";

            if (split.Length != 6)
                return "ERROR_SPLIT_LENGTH";

            if (string.IsNullOrWhiteSpace(split[0])) // Filename
                return "ERROR_0_EMPTY";
            if (string.IsNullOrWhiteSpace(split[1])) // Category
                return "ERROR_1_EMPTY";
            if (string.IsNullOrWhiteSpace(split[2])) // Exercise
                return "ERROR_2_EMPTY";
            if (string.IsNullOrWhiteSpace(split[3])) // Username
                return "ERROR_3_EMPTY";
            if (string.IsNullOrWhiteSpace(split[4])) // UserId
                return "ERROR_4_EMPTY";
            if (string.IsNullOrWhiteSpace(split[5])) // Score
                return "ERROR_5_EMPTY";

            float score = 0.0f;
            try 
            {
                score = Convert.ToSingle(split[5], System.Globalization.CultureInfo.InvariantCulture); 
            }
            catch
            {
                try 
                {
                    score = Convert.ToSingle(split[5]); 
                }
                catch 
                {
                    return "ERROR_SCORE"; 
                }
            }

            string filename = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), split[0]);
            if (FileManager.WriteExerciseEntry(filename, split[1], split[2], split[3], split[4], score))
                return "OK";
            else
                return "ERROR_FILE";
        }
    }
}
