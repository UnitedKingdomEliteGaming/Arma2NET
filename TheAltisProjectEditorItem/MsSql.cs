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
        #region public class SqlItem
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
        #endregion

        private static string _ConnectionStringItem;
        public static string ConnectionStringItem
        {
            get
            {
                return _ConnectionStringItem;
            }
        }

        public static void Init()
        {
#if(DEBUG)
            string filename = @"C:\Program Files (x86)\Steam\SteamApps\common\Arma 3\@Arma2Net\Addins\TheAltisProjectAddin\DatabaseItem.mdf";
#else
            string filename = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "DatabaseItem.mdf");
#endif
            _ConnectionStringItem = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + filename + ";Integrated Security=True";
        }

        public static string[] GetTables()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionStringItem))
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
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionStringItem))
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
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionStringItem))
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
        public static bool Insert(string table, string id, string data)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionStringItem))
                {
                    sqlConnection.Open();

                    string commandText = string.Format("INSERT into {0} (ItemId, ItemData) VALUES ('{1}', '{2}')", table, id, data);
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
        public static bool Update(string table, Int64 id, string itemId, string itemData)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionStringItem))
                {
                    sqlConnection.Open();

                    string commandText = string.Format("UPDATE {0} SET ItemId='{2}' ItemData='{3}' WHERE Id={1}", table, itemId, itemData);
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
        public static bool Delete(string table, Int64 id)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionStringItem))
                {
                    sqlConnection.Open();

                    string commandText = string.Format("DELETE FROM {0} WHERE Id={1}", table, id);
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
