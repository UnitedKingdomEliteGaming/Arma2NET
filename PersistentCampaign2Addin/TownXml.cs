using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistentCampaign2Addin
{
    [Serializable]
    public class TownXml
    {
        #region public class Town
        [Serializable]
        public class Town
        {
            public string Name;
            public float Water = 0;
            public float Food = 0;
            public float Mood = 0;
            public float Civ = 100;
            public float Red = 100;
            public float Weapon = 0;
            public float Warlord = 0;
            public float Injured = 10;

            public string ToArmaArray()
            {
                return string.Format("[\"{0}\",{1},{2},{3},{4},{5},{6},{7},{8}]", Name, Water, Food, Mood, Civ, Red, Weapon, Warlord, Injured);
            }
        }
        #endregion

        [System.Xml.Serialization.XmlElement("Town")]
        public Town[] Towns = null;

        private Town Find(string name)
        {
            if (Towns != null)
                foreach (Town town in Towns)
                    if (town.Name.ToLower() == name)
                        return town;

            Town newTown = new Town();
            newTown.Name = name;

            Arma2Net.Utils.Log("New town added: " + name);

            if (Towns == null)
                Towns = new Town[0];

            Town[] tmp = Towns;
            Towns = new Town[tmp.Length + 1];
            Array.Copy(tmp, Towns, tmp.Length);
            Towns[Towns.Length - 1] = newTown;

            return newTown;
        }
        private void Update(string name, string water, string food, string mood, string civ, string red, string weapon, string warlord, string injured)
        {
            TownXml.Town town = Find(name);
            town.Water = Convert.ToSingle(water, System.Globalization.CultureInfo.InvariantCulture);
            town.Food = Convert.ToSingle(food, System.Globalization.CultureInfo.InvariantCulture);
            town.Mood = Convert.ToSingle(mood, System.Globalization.CultureInfo.InvariantCulture);
            town.Civ = Convert.ToSingle(civ, System.Globalization.CultureInfo.InvariantCulture);
            town.Red = Convert.ToSingle(red, System.Globalization.CultureInfo.InvariantCulture);
            town.Weapon = Convert.ToSingle(weapon, System.Globalization.CultureInfo.InvariantCulture);
            town.Warlord = Convert.ToSingle(warlord, System.Globalization.CultureInfo.InvariantCulture);
            town.Injured = Convert.ToSingle(injured, System.Globalization.CultureInfo.InvariantCulture);
        }

        public string ArgumentParser(string[] split)
        {
            try
            {
                if (split.Length < 2)
                    return "ERROR_TOWN_SPLIT_LENGTH";

                if (split[1].ToLower() == "load")
                {
                    #region load
                    try
                    {
                        if (split.Length < 3)
                            return "ERROR_TOWN_LOAD_SPLIT_LENGTH";

                        TownXml.Town town = Find(split[2].ToLower());
                        return town.ToArmaArray();
                    }
                    catch (Exception ex)
                    {
                        Arma2Net.Utils.Log("ERROR: Town.Load failed: " + ex.Message);
                        return "ERROR_TOWN_LOAD_EXCEPTION";
                    }
                    #endregion
                }
                else if (split[1].ToLower() == "update")
                {
                    #region update
                    try
                    {
                        if (split.Length < 11)
                            return "ERROR_TOWN_UPDATE_SPLIT_LENGTH";

                        Update(split[2], split[3], split[4], split[5], split[6], split[7], split[8], split[9], split[10]);
                        return "OK";
                    }
                    catch (Exception ex)
                    {
                        Arma2Net.Utils.Log("ERROR: Town.Update failed: " + ex.Message);
                        return "ERROR_TOWN_UPDATE_EXCEPTION";
                    }
                    #endregion
                }
                else if (split[1].ToLower() == "save")
                {
                    #region save
                    try
                    {
                        XmlTools.Save<TownXml>(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Towns.xml"), this);

                        return "OK";
                    }
                    catch (Exception ex)
                    {
                        Arma2Net.Utils.Log("ERROR: Town.Save failed: " + ex.Message);
                        return "ERROR_TOWN_SAVE_EXCEPTION";
                    }
                    #endregion
                }
                else
                    return "ERROR_TOWN_INVALID_COMMAND";
            }
            catch (Exception ex)
            {
                Arma2Net.Utils.Log("ERROR: Town-Exception: " + ex.Message);
                return "ERROR_TOWN_EXCEPTION";
            }
        }
    }
}
