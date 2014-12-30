using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistentCampaign2Addin
{
    [Serializable]
    public class VehicleXml
    {
        #region public class Vehicle
        [Serializable]
        public class Vehicle
        {
            public string Classname;
            public string Position;
            public string Orientation;
            public float Damage;
            public string Content;

            public string ToArmaArray()
            {
                return string.Format("[\"{0}\",{1},{2},{3},{4}]", Classname, Position, Orientation, Damage, Content);
            }
        }
        #endregion

        [System.Xml.Serialization.XmlElement("Vehicle")]
        public Vehicle[] Vehicles = null;

        [System.Xml.Serialization.XmlIgnore]
        private List<Vehicle> _TmpVehicles = null;

        public string ArgumentParser(string[] split)
        {
            try
            {
                if (split.Length < 2)
                    return "ERROR_VEHICLE_SPLIT_LENGTH";

                if (split[1].ToLower() == "read")
                {
                    #region read
                    try
                    {
                        if (split.Length < 3)
                            return "ERROR_VEHICLE_READ_SPLIT_LENGTH";

                        int index = Convert.ToInt32(split[2]);
                        
                        if ((Vehicles == null) || (Vehicles.Length <= index))
                            return "ERROR_VEHICLE_READ_INDEX";

                        return Vehicles[index].ToArmaArray();
                    }
                    catch (Exception ex)
                    {
                        Arma2Net.Utils.Log("ERROR: Vehicle.Read failed: " + ex.Message);
                        return "ERROR_VEHICLE_READ_EXCEPTION: " + ex.Message;
                    }
                    #endregion
                }
                else if (split[1].ToLower() == "beginwrite")
                {
                    #region beginwrite
                    try
                    {
                        _TmpVehicles = new List<Vehicle>();
                        return "OK";
                    }
                    catch (Exception ex)
                    {
                        Arma2Net.Utils.Log("ERROR: Vehicle.BeginWrite failed: " + ex.Message);
                        return "ERROR_VEHICLE_BEGINWRITE_EXCEPTION";
                    }
                    #endregion
                }
                else if (split[1].ToLower() == "write")
                {
                    #region write
                    try
                    {
                        if (split.Length < 7)
                            return "ERROR_VEHICLE_WRITE_SPLIT_LENGTH";

                        Vehicle vehicle = new Vehicle();
                        vehicle.Classname = split[2];
                        vehicle.Position = split[3];
                        vehicle.Orientation = split[4];
                        vehicle.Damage = Convert.ToSingle(split[5], System.Globalization.CultureInfo.InvariantCulture);
                        vehicle.Content = split[6];
                        _TmpVehicles.Add(vehicle);

                        return "OK";
                    }
                    catch (Exception ex)
                    {
                        Arma2Net.Utils.Log("ERROR: Vehicle.Write failed: " + ex.Message);
                        return "ERROR_VEHICLE_WRITE_EXCEPTION";
                    }
                    #endregion
                }
                else if (split[1].ToLower() == "endwrite")
                {
                    #region endwrite
                    try
                    {
                        Vehicles = _TmpVehicles.ToArray();
                        _TmpVehicles = null;
                        XmlTools.Save<VehicleXml>(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Vehicle.xml"), this);

                        return "OK";
                    }
                    catch (Exception ex)
                    {
                        Arma2Net.Utils.Log("ERROR: Vehicle.EndWrite failed: " + ex.Message);
                        return "ERROR_VEHICLE_ENDWRITE_EXCEPTION";
                    }
                    #endregion
                }
                else
                    return "ERROR_VEHICLE_INVALID_COMMAND";
            }
            catch (Exception ex)
            {
                Arma2Net.Utils.Log("ERROR: Vehicle-Exception: " + ex.Message);
                return "ERROR_VEHICLE_EXCEPTION";
            }
        }
    }
}
