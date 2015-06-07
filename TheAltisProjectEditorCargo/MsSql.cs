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
        #region public class IdStringPair
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
        #endregion

        private static string _ConnectionStringCargo;
        public static string ConnectionStringCargo
        {
            get
            {
                return _ConnectionStringCargo;
            }
        }

        public static void Init()
        {
#if(DEBUG)
            string filename = @"C:\Program Files (x86)\Steam\SteamApps\common\Arma 3\@Arma2Net\Addins\TheAltisProjectAddin\DatabaseCargo.mdf";
#else
            string filename = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "DatabaseCargo.mdf");
#endif
            _ConnectionStringCargo = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + filename + ";Integrated Security=True";
        }

        public static string[] GetTables()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionStringCargo))
                {
                    sqlConnection.Open();
                    using (System.Data.DataTable schema = sqlConnection.GetSchema("Tables"))
                    {
                        List<string> tables = new List<string>(8);
                        foreach (System.Data.DataRow row in schema.Rows)
                            tables.Add(row[2].ToString());

                        return tables.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Exception: " + ex.Message);
                return null;
            }
        }
        public static bool DropTable(string table)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionStringCargo))
                {
                    sqlConnection.Open();

                    string commandText = string.Format("DROP TABLE {0}", table);
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
        public static string[] GetCargoIds(string table)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionStringCargo))
                {
                    sqlConnection.Open();

                    SqlCommand sqlCommand = new SqlCommand("SELECT DISTINCT CargoId FROM " + table + " ORDER BY CargoId DESC;", sqlConnection);
                    using (SqlDataReader sqlReader = sqlCommand.ExecuteReader())
                    {
                        List<string> items = new List<string>(32);

                        while (sqlReader.Read())
                        {
                            if (sqlReader.IsDBNull(0))
                                return null;

                            items.Add(sqlReader.GetString(0));
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
        public static IdStringPair[] GetCargoData(string table, string cargoId, string cargoType)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionStringCargo))
                {
                    sqlConnection.Open();

                    SqlCommand sqlCommand = new SqlCommand(string.Format("SELECT Id, CargoData FROM {0} WHERE CargoId='{1}' AND CargoType='{2}';", table, cargoId, cargoType), sqlConnection);
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
        public static bool DeleteCargoType(string table, string cargoId, string cargoType)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionStringCargo))
                {
                    sqlConnection.Open();

                    string commandText = string.Format("DELETE FROM {0} WHERE CargoId='{1}' AND CargoType='{2}'", table, cargoId, cargoType);
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
        public static bool DeleteCargoSingle(string table, Int64 id)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionStringCargo))
                {
                    sqlConnection.Open();

                    string commandText = string.Format("DELETE FROM {0} WHERE Id='{1}'", table, id);
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
        public static bool DeleteCargoId(string table, string cargoId)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionStringCargo))
                {
                    sqlConnection.Open();

                    string commandText = string.Format("DELETE FROM {0} WHERE CargoId='{1}'", table, cargoId);
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
        public static bool Insert(string table, string cargoId, string cargoType, string cargoData)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionStringCargo))
                {
                    sqlConnection.Open();

                    string commandText = string.Format("INSERT into {0} (CargoId, CargoType, CargoData) VALUES ('{1}', '{2}', '{3}')", table, cargoId, cargoType, cargoData);
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
        public static bool Update(string table, string cargoId, string cargoType, string cargoData)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionStringCargo))
                {
                    sqlConnection.Open();

                    string commandText = string.Format("UPDATE {0} SET CargoId='{1}', CargoType='{2}', CargoData='{3}'", table, cargoId, cargoType, cargoData);
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
