using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistentCampaign2Addin
{
    [Arma2Net.Addin("PC", Version = "2.0", Author = "Pixinger", Description = "Pixinger")]
    public class PersistentCampaign2 : Arma2Net.Addin
    {
        private TownXml _TownXml = XmlTools.Load<TownXml>(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Towns.xml"));
        private VehicleXml _VehicleXml = XmlTools.Load<VehicleXml>(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Vehicle.xml"));

        public override string Invoke(string args, int maxResultSize)
        {
            lock (this)
            {
                // Vorab Prüfungen
                if (string.IsNullOrWhiteSpace(args))
                    return "ERROR_ARGS_NULL";

                // Argumente zerlegen
                string[] split;
                try
                {
                    split = args.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
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
                if (split[0].ToLower() == "town")
                {
                    return _TownXml.ArgumentParser(split);
                }
                else if (split[0].ToLower() == "vehicle")
                {
                    return _VehicleXml.ArgumentParser(split);
                }
                else
                    return "ERROR_INVALID_COMMAND";
            }
        }
    }
}
