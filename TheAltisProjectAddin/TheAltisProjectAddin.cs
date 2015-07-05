using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAltisProjectAddin
{
    [Arma2Net.Addin("Tap", Version = "1.1", Author = "Pixinger", Description = "TheAltisProjectDatabase")]
    public class TheAltisProjectAddin : Arma2Net.Addin, IDisposable
    {
        private ItemCommandManager _ItemCommandManager = new ItemCommandManager();
        private CargoCommandManager _CargoCommandManager = new CargoCommandManager();

        public TheAltisProjectAddin()
        {
        }

        #region IDisposable Member
        ~TheAltisProjectAddin()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            OnDispose(disposing);
        }
        #endregion
        protected virtual void OnDispose(bool disposing)
        {
        }

        public override string Invoke(string args, int maxResultSize)
        {
            lock (this)
            {
                // Vorab Prüfungen
                if (string.IsNullOrWhiteSpace(args))
                    return "ERROR_ARGS_NULL";
#if(DEBUG)
                Arma2Net.Utils.Log(args);
#endif

                // Argumente zerlegen
                string[] split;
                try
                {
                    split = args.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                }
                catch (Exception ex)
                {
                    Arma2Net.Utils.Log("Exception: " + ex.Message);
                    return "ERROR_SPLIT_EXCEPTION";
                }

                // Zerlegte Argumente prüfen
                if (split == null)
                    return "ERROR_SPLIT_NULL";
                if (split.Length < 1)
                    return "ERROR_SPLIT_LENGTH";

                // Die einzelnen Befehlsgruppen verarbeiten
                if (split[0].ToLower() == "item")
                {
                    return _ItemCommandManager.Parse(split);
                }
                else if (split[0].ToLower() == "cargo")
                {
                    return _CargoCommandManager.Parse(split);
                }
                else
                    return "ERROR_INVALID_COMMAND";
            }
        }
    }
}