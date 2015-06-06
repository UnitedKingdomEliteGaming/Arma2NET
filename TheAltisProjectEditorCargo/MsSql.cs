using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAltisProjectEditorCargo
{
    class MsSql
    {
        public class IdStringPair
        {
            public Int64 Id;
            public string Text;

            public IdStringPair(Int64 id, string text)
            {
                Id = id;
                Text = text;
            }
            public override string ToString()
            {
                return Text;
            }
        }

        //public const string DatabaseFilename = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Database.mdf");
        public const string DatabaseFilename = @"C:\Program Files (x86)\Steam\SteamApps\common\Arma 3\@Arma2Net\Addins\TheAltisProjectAddin\Database.mdf";
        public const string ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + DatabaseFilename + ";Integrated Security=True";

        public static IdStringPair[] GetCargoIds()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();

                    SqlCommand sqlCommand = new SqlCommand("SELECT DISTINCT CargoId, Id FROM Cargo ORDER BY CargoId DESC;", sqlConnection);
                    using (SqlDataReader sqlReader = sqlCommand.ExecuteReader())
                    {
                        List<IdStringPair> items = new List<IdStringPair>(32);

                        while (sqlReader.Read())
                        {
                            if (sqlReader.IsDBNull(0))
                                return null;
                            if (sqlReader.IsDBNull(1))
                                return null;

                            items.Add(new IdStringPair(sqlReader.GetInt64(1), sqlReader.GetString(0)));
                        }

                        return items.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Exception: " + ex.Message);
                return null;
            }
        }
        public static IdStringPair[] GetCargoData(string cargoId, string cargoType)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();

                    SqlCommand sqlCommand = new SqlCommand(string.Format("SELECT Id, CargoData FROM Cargo WHERE CargoId='{0}' AND CargoType='{1}';", cargoId, cargoType), sqlConnection);
                    using (SqlDataReader sqlReader = sqlCommand.ExecuteReader())
                    {
                        List<IdStringPair> items = new List<IdStringPair>(32);

                        while (sqlReader.Read())
                        {
                            if (sqlReader.IsDBNull(0))
                                return null;
                            if (sqlReader.IsDBNull(1))
                                return null;

                            items.Add(new IdStringPair(sqlReader.GetInt64(0), sqlReader.GetString(1)));
                        }

                        return items.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Exception: " + ex.Message);
                return null;
            }
        }
        public static bool DeleteCargoType(string cargoId, string cargoType)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();

                    string commandText = string.Format("DELETE FROM Cargo WHERE CargoId='{0}' AND CargoType='{1}'", cargoId, cargoType);
                    using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                    {
                        int result = sqlCommand.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Exception: " + ex.Message);
                return false;
            }
        }
        public static bool DeleteCargoSingle(Int64 id)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();

                    string commandText = string.Format("DELETE FROM Cargo WHERE Id='{0}'", id);
                    using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                    {
                        int result = sqlCommand.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Exception: " + ex.Message);
                return false;
            }
        }
        public static bool DeleteCargoId(string cargoId)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();

                    string commandText = string.Format("DELETE FROM Cargo WHERE CargoId='{0}'", cargoId);
                    using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                    {
                        int result = sqlCommand.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Exception: " + ex.Message);
                return false;
            }
        }
        public static bool Insert(string cargoId, string cargoType, string cargoData)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();

                    string commandText = string.Format("INSERT into Cargo (CargoId, CargoType, CargoData) VALUES ('{0}', '{1}', '{2}')", cargoId, cargoType, cargoData);
                    using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                    {
                        int result = sqlCommand.ExecuteNonQuery();
                        return (result == 1);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Exception: " + ex.Message);
                return false;
            }
        }
        public static bool Update(string cargoId, string cargoType, string cargoData)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();

                    string commandText = string.Format("UPDATE Cargo SET CargoId='{0}', CargoType='{1}', CargoData='{2}'", cargoId, cargoType, cargoData);
                    using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                    {
                        int result = sqlCommand.ExecuteNonQuery();
                        return (result == 1);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Exception: " + ex.Message);
                return false;
            }
        }


    }
}
