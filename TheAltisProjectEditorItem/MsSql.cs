using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAltisProjectEditorItem
{
    class MsSql
    {
        public class SqlItem
        {
            public Int64 Id;
            public string ItemId;
            public string ItemData;

            public SqlItem(Int64 id, string itemId, string itemData)
            {
                Id = id;
                ItemId = itemId;
                ItemData = itemData;
            }
            public override string ToString()
            {
                return ItemId;
            }
        }

        //public const string DatabaseFilename = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Database.mdf");
        public const string DatabaseFilename = @"C:\Program Files (x86)\Steam\SteamApps\common\Arma 3\@Arma2Net\Addins\TheAltisProjectAddin\Database.mdf";
        public const string ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + DatabaseFilename + ";Integrated Security=True";

        public static string[] GetTables()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
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
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
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
        public static SqlItem[] GetItems(string table)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();

                    SqlCommand sqlCommand = new SqlCommand(string.Format("SELECT Id, ItemId, ItemData FROM {0} ORDER BY ItemId DESC;", table), sqlConnection);
                    using (SqlDataReader sqlReader = sqlCommand.ExecuteReader())
                    {
                        List<SqlItem> items = new List<SqlItem>(32);

                        while (sqlReader.Read())
                        {
                            if (sqlReader.IsDBNull(0))
                                return null;
                            if (sqlReader.IsDBNull(1))
                                return null;
                            if (sqlReader.IsDBNull(2))
                                return null;

                            items.Add(new SqlItem(sqlReader.GetInt64(0), sqlReader.GetString(1), sqlReader.GetString(2)));
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
        public static bool Update(string table, Int64 id, string itemData)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();

                    string commandText = string.Format("UPDATE {0} SET ItemData='{2}' WHERE Id={1}", table, id, itemData);
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


    }
}
