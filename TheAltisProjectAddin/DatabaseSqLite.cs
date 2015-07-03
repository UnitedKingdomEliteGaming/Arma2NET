using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace TheAltisProjectAddin
{
    public class DatabaseItemSQLite : IDatabaseItem, IDatabaseItemGui
    {
        private string _ConnectionString;

        public DatabaseItemSQLite()
        {
            _ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "DatabaseItem.mdf") + ";Integrated Security=True";
        }

        private bool CreateTable(string table)
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();

                    string commandText = @"
                            CREATE TABLE [dbo].[" + table.ToLower() + @"] (
                                [Id] BIGINT IDENTITY (1, 1) NOT NULL,
                                [ItemId]   NVARCHAR (64)  NOT NULL,
                                [ItemData] NVARCHAR (MAX) NOT NULL,
                                PRIMARY KEY CLUSTERED ([Id] ASC)
                            );";

                    using (SQLiteCommand SQLiteCommand = new SQLiteCommand(commandText, SQLiteConnection))
                    {
                        SQLiteCommand.ExecuteNonQuery();
                        LogManager.Write("New table created (Item): {0}", table);
                        SQLiteConnection.Close();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Write("Exception: " + ex.Message);
                return false;
            }
        }
        private bool IsIdValid(string itemId)
        {
            if (string.IsNullOrWhiteSpace(itemId))
                return false;

            return true;
        }
        private bool IsDataValid(string data)
        {
            if (data == null)
                return false;

            return true;
        }

        public string[] GetTables()
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();
                    using (System.Data.DataTable schema = SQLiteConnection.GetSchema("Tables"))
                    {
                        List<string> tables = new List<string>(8);
                        foreach (System.Data.DataRow row in schema.Rows)
                            tables.Add(row[2].ToString());

                        SQLiteConnection.Close();
                        return tables.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Write(ex.Message);
                return null;
            }
        }
        public bool DropTable(string table)
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();

                    string commandText = string.Format("DROP TABLE {0}", table);
                    using (SQLiteCommand SQLiteCommand = new SQLiteCommand(commandText, SQLiteConnection))
                    {
                        int result = SQLiteCommand.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Write("Exception: " + ex.Message);
                return false;
            }
        }
        public IDatabaseItemGui.SqlItem[] GetItems(string table)
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();

                    SQLiteCommand SQLiteCommand = new SQLiteCommand(string.Format("SELECT Id, ItemId, ItemData FROM {0} ORDER BY ItemId DESC;", table), SQLiteConnection);
                    using (SQLiteDataReader sqlReader = SQLiteCommand.ExecuteReader())
                    {
                        List<IDatabaseItemGui.SqlItem> items = new List<IDatabaseItemGui.SqlItem>(32);

                        while (sqlReader.Read())
                        {
                            if (sqlReader.IsDBNull(0))
                                return null;
                            if (sqlReader.IsDBNull(1))
                                return null;
                            if (sqlReader.IsDBNull(2))
                                return null;

                            items.Add(new IDatabaseItemGui.SqlItem(sqlReader.GetInt64(0), sqlReader.GetString(1), sqlReader.GetString(2)));
                        }

                        return items.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Write("Exception: " + ex.Message);
                return null;
            }
        }
        public bool Initialize(string table)
        {
            string[] tables = GetTables();
            if (tables == null)
                return false;

            if (tables.Contains(table.ToLower()))
                return true;

            return CreateTable(table.ToLower());
        }
        public bool InsertItemId(string table, string itemId, string itemData)
        {
            if (!IsIdValid(itemId))
                return false;
            if (!IsDataValid(itemData))
                return false;

            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();

                    string commandText = string.Format("INSERT into {0} (ItemId, ItemData) VALUES ('{1}', '{2}')", table.ToLower(), itemId, itemData);
                    using (SQLiteCommand SQLiteCommand = new SQLiteCommand(commandText, SQLiteConnection))
                    {
                        int result = SQLiteCommand.ExecuteNonQuery();
                        //Arma2Net.Utils.Log(commandText + ": " + result);
                        SQLiteConnection.Close();
                        return (result == 1);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Write("Exception: " + ex.Message);
                return false;
            }
        }
        public bool UpdateId(string table, Int64 id, string itemId, string itemData)
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();

                    string commandText = string.Format("UPDATE {0} SET ItemId='{2}' ItemData='{3}' WHERE Id={1}", table, itemId, itemData);
                    using (SQLiteCommand SQLiteCommand = new SQLiteCommand(commandText, SQLiteConnection))
                    {
                        int result = SQLiteCommand.ExecuteNonQuery();
                        return (result == 1);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Write("Exception: " + ex.Message);
                return false;
            }
        }
        public bool UpdateItemId(string table, string itemId, string itemData)
        {
            if (!IsIdValid(itemId))
                return false;
            if (!IsDataValid(itemData))
                return false;

            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();

                    string commandText = string.Format("UPDATE {0} SET ItemData='{2}' WHERE ItemId='{1}'", table.ToLower(), itemId, itemData);
                    using (SQLiteCommand SQLiteCommand = new SQLiteCommand(commandText, SQLiteConnection))
                    {
                        int result = SQLiteCommand.ExecuteNonQuery();
                        //Arma2Net.Utils.Log(commandText + ": " + result);
                        SQLiteConnection.Close();
                        return (result == 1);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Write("Exception: " + ex.Message);
                return false;
            }
        }
        public bool UpdateOrInsertItemId(string table, string itemId, string itemData)
        {
            if (UpdateItemId(table, itemId, itemData))
                return true;

            return InsertItemId(table, itemId, itemData);
        }
        public bool DeleteId(string table, Int64 id)
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();

                    string commandText = string.Format("DELETE FROM {0} WHERE Id={1}", table, id);
                    using (SQLiteCommand SQLiteCommand = new SQLiteCommand(commandText, SQLiteConnection))
                    {
                        int result = SQLiteCommand.ExecuteNonQuery();
                        return (result == 1);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Write("Exception: " + ex.Message);
                return false;
            }
        }
        public bool DeleteItemId(string table, string itemId)
        {
            if (!IsIdValid(itemId))
                return false;

            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();

                    string commandText = string.Format("DELETE FROM {0} WHERE ItemId='{1}'", table.ToLower(), itemId);
                    using (SQLiteCommand SQLiteCommand = new SQLiteCommand(commandText, SQLiteConnection))
                    {
                        int result = SQLiteCommand.ExecuteNonQuery();
                        //Arma2Net.Utils.Log(commandText + ": " + result);
                        SQLiteConnection.Close();
                        return (result == 1);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Write("Exception: " + ex.Message);
                return false;
            }
        }
        public string Select(string table, string itemId)
        {
            if (!IsIdValid(itemId))
                return null;

            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();

                    string commandText = string.Format("SELECT ItemData FROM {0} WHERE ItemId='{1}'", table.ToLower(), itemId);
                    using (SQLiteCommand SQLiteCommand = new SQLiteCommand(commandText, SQLiteConnection))
                    {
                        using (SQLiteDataReader sqlReader = SQLiteCommand.ExecuteReader())
                        {
                            if (!sqlReader.Read())
                                return null;

                            if (sqlReader.IsDBNull(0))
                                return null;

                            string result = sqlReader.GetString(0);
                            //Arma2Net.Utils.Log(commandText + ": " + result);
                            SQLiteConnection.Close();
                            return result;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Write("Exception: " + ex.Message);
                return null;
            }
        }
        public IDatabaseItem.Result SelectIds(string table)
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();

                    string commandText = string.Format("SELECT ItemId FROM {0}", table.ToLower());
                    using (SQLiteCommand SQLiteCommand = new SQLiteCommand(commandText, SQLiteConnection))
                    {
                        using (SQLiteDataReader sqlReader = SQLiteCommand.ExecuteReader())
                        {
                            List<string> results = new List<string>(32);
                            while (sqlReader.Read())
                            {
                                if (sqlReader.IsDBNull(0))
                                    return null;

                                results.Add(sqlReader.GetString(0));
                            }

                            //Arma2Net.Utils.Log(commandText + ": " + result);
                            IDatabaseItem.Result result = new IDatabaseItem.Result(results.ToArray());
                            SQLiteConnection.Close();
                            return result;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Write("Exception: " + ex.Message);
                return null;
            }
        }
    }

    public class DatabaseCargoSQLite : IDatabaseCargo, IDatabaseCargoGui
    {
        private string _ConnectionString;

        public DatabaseCargoSQLite()
        {
            _ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "DatabaseCargo.mdf") + ";Integrated Security=True";
        }

        private bool CreateTable(string table)
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();

                    string commandText = @"
                            CREATE TABLE [dbo].[" + table.ToLower() + @"] (
                                [Id]        BIGINT         IDENTITY (1, 1) NOT NULL,
                                [CargoId]   NVARCHAR (64)  NOT NULL,
                                [CargoType] NVARCHAR (3)   NOT NULL,
                                [CargoData] NVARCHAR (256) NOT NULL,
                                PRIMARY KEY CLUSTERED ([Id] ASC)
                            );";

                    using (SQLiteCommand SQLiteCommand = new SQLiteCommand(commandText, SQLiteConnection))
                    {
                        SQLiteCommand.ExecuteNonQuery();
                        LogManager.Write("New table created (Cargo): {0}", table.ToLower());
                        SQLiteConnection.Close();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Write("Exception: " + ex.Message);
                return false;
            }
        }
        private bool IsCargoIdValid(string cargoId)
        {
            if (string.IsNullOrWhiteSpace(cargoId))
                return false;

            return true;
        }
        private bool IsCargoTypeValid(string cargoType)
        {
            if (cargoType == null)
                return false;
            if (cargoType.Length != 3)
                return false;

            return true;
        }
        private bool IsCargoDataValid(string data)
        {
            if (data == null)
                return false;

            return true;
        }

        // IDatabaseCargo
        public bool Initialize(string table)
        {
            string[] tables = GetTables();
            if (tables == null)
                return false;

            if (tables.Contains(table.ToLower()))
                return true;

            return CreateTable(table);
        }
        public bool Insert(string table, string cargoId, string cargoType, string cargoData)
        {
            if (!IsCargoIdValid(cargoId))
                return false;
            if (!IsCargoTypeValid(cargoType))
                return false;
            if (!IsCargoDataValid(cargoData))
                return false;

            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();

                    string commandText = string.Format("INSERT into {0} (CargoId, CargoType, CargoData) VALUES ('{1}', '{2}', '{3}')", table.ToLower(), cargoId, cargoType.ToLower(), cargoData);
                    using (SQLiteCommand SQLiteCommand = new SQLiteCommand(commandText, SQLiteConnection))
                    {
                        int result = SQLiteCommand.ExecuteNonQuery();
                        //Arma2Net.Utils.Log(commandText + ": " + result);
                        SQLiteConnection.Close();
                        return (result == 1);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Write("Exception: " + ex.Message);
                return false;
            }
        }
        public bool DeleteCargoType(string table, string cargoId, string cargoType)
        {
            if (!IsCargoIdValid(cargoId))
                return false;
            if (!IsCargoTypeValid(cargoType))
                return false;

            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();

                    string commandText = string.Format("DELETE FROM {0} WHERE CargoId='{1}' AND CargoType='{2}'", table.ToLower(), cargoId, cargoType.ToLower());
                    using (SQLiteCommand SQLiteCommand = new SQLiteCommand(commandText, SQLiteConnection))
                    {
                        int result = SQLiteCommand.ExecuteNonQuery();
                        //Arma2Net.Utils.Log(commandText + ": " + result);
                        SQLiteConnection.Close();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Write("Exception: " + ex.Message);
                return false;
            }
        }
        public bool DeleteCargoId(string table, string cargoId)
        {
            if (!IsCargoIdValid(cargoId))
                return false;

            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();

                    string commandText = string.Format("DELETE FROM {0} WHERE CargoId='{1}'", table.ToLower(), cargoId);
                    using (SQLiteCommand SQLiteCommand = new SQLiteCommand(commandText, SQLiteConnection))
                    {
                        int result = SQLiteCommand.ExecuteNonQuery();
                        //Arma2Net.Utils.Log(commandText + ": " + result);
                        SQLiteConnection.Close();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Write("Exception: " + ex.Message);
                return false;
            }
        }
        public IDatabaseCargo.Result Select(string table, string cargoId, string cargoType)
        {
            if (!IsCargoIdValid(cargoId))
                return null;
            if (!IsCargoTypeValid(cargoType))
                return null;

            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();

                    string commandText = string.Format("SELECT CargoData FROM {0} WHERE CargoId='{1}' AND CargoType='{2}'", table.ToLower(), cargoId, cargoType.ToLower());
                    using (SQLiteCommand SQLiteCommand = new SQLiteCommand(commandText, SQLiteConnection))
                    {
                        List<string> items = new List<string>(8);
                        using (SQLiteDataReader sqlReader = SQLiteCommand.ExecuteReader())
                        {
                            while (sqlReader.Read())
                            {
                                if (sqlReader.IsDBNull(0))
                                    return null;

                                items.Add(sqlReader.GetString(0));
                            }

                            IDatabaseCargo.Result result = new IDatabaseCargo.Result(items.ToArray());
                            SQLiteConnection.Close();
                            return result;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Write("Exception: " + ex.Message);
                return null;
            }
        }
        public IDatabaseCargo.Result SelectIds(string table)
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();

                    string commandText = string.Format("SELECT CargoId FROM {0}", table.ToLower());
                    using (SQLiteCommand SQLiteCommand = new SQLiteCommand(commandText, SQLiteConnection))
                    {
                        List<string> items = new List<string>(8);
                        using (SQLiteDataReader sqlReader = SQLiteCommand.ExecuteReader())
                        {
                            while (sqlReader.Read())
                            {
                                if (sqlReader.IsDBNull(0))
                                    return null;

                                items.Add(sqlReader.GetString(0));
                            }

                            IDatabaseCargo.Result result = new IDatabaseCargo.Result(items.ToArray());
                            SQLiteConnection.Close();
                            return result;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Write("Exception: " + ex.Message);
                return null;
            }
        }

        // IDatabaseCargoEx 
        public string[] GetTables()
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();
                    using (System.Data.DataTable schema = SQLiteConnection.GetSchema("Tables"))
                    {
                        List<string> tables = new List<string>(8);
                        foreach (System.Data.DataRow row in schema.Rows)
                            tables.Add(row[2].ToString());

                        SQLiteConnection.Close();
                        return tables.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Write("Exception: " + ex.Message);
                return null;
            }
        }
        public bool DropTable(string table)
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();

                    string commandText = string.Format("DROP TABLE {0}", table);
                    using (SQLiteCommand SQLiteCommand = new SQLiteCommand(commandText, SQLiteConnection))
                    {
                        int result = SQLiteCommand.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Write("Exception: " + ex.Message);
                return false;
            }
        }
        public string[] GetCargoIds(string table)
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();

                    SQLiteCommand SQLiteCommand = new SQLiteCommand("SELECT DISTINCT CargoId FROM " + table + " ORDER BY CargoId DESC;", SQLiteConnection);
                    using (SQLiteDataReader sqlReader = SQLiteCommand.ExecuteReader())
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
                LogManager.Write("Exception: " + ex.Message);
                return null;
            }
        }
        public IDatabaseCargoGui.IdStringPair[] GetCargoData(string table, string cargoId, string cargoType)
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();

                    SQLiteCommand SQLiteCommand = new SQLiteCommand(string.Format("SELECT Id, CargoData FROM {0} WHERE CargoId='{1}' AND CargoType='{2}';", table, cargoId, cargoType), SQLiteConnection);
                    using (SQLiteDataReader sqlReader = SQLiteCommand.ExecuteReader())
                    {
                        List<IDatabaseCargoGui.IdStringPair> items = new List<IDatabaseCargoGui.IdStringPair>(32);

                        while (sqlReader.Read())
                        {
                            if (sqlReader.IsDBNull(0))
                                return null;
                            if (sqlReader.IsDBNull(1))
                                return null;

                            items.Add(new IDatabaseCargoGui.IdStringPair(sqlReader.GetInt64(0), sqlReader.GetString(1)));
                        }

                        return items.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Write("Exception: " + ex.Message);
                return null;
            }
        }
        public bool DeleteCargoType(string table, string cargoId, string cargoType)
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();

                    string commandText = string.Format("DELETE FROM {0} WHERE CargoId='{1}' AND CargoType='{2}'", table, cargoId, cargoType);
                    using (SQLiteCommand SQLiteCommand = new SQLiteCommand(commandText, SQLiteConnection))
                    {
                        int result = SQLiteCommand.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Write("Exception: " + ex.Message);
                return false;
            }
        }
        public bool DeleteCargoSingle(string table, Int64 id)
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();

                    string commandText = string.Format("DELETE FROM {0} WHERE Id='{1}'", table, id);
                    using (SQLiteCommand SQLiteCommand = new SQLiteCommand(commandText, SQLiteConnection))
                    {
                        int result = SQLiteCommand.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Write("Exception: " + ex.Message);
                return false;
            }
        }
        public bool DeleteCargoId(string table, string cargoId)
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();

                    string commandText = string.Format("DELETE FROM {0} WHERE CargoId='{1}'", table, cargoId);
                    using (SQLiteCommand SQLiteCommand = new SQLiteCommand(commandText, SQLiteConnection))
                    {
                        int result = SQLiteCommand.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Write("Exception: " + ex.Message);
                return false;
            }
        }
        public bool Insert(string table, string cargoId, string cargoType, string cargoData)
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();

                    string commandText = string.Format("INSERT into {0} (CargoId, CargoType, CargoData) VALUES ('{1}', '{2}', '{3}')", table, cargoId, cargoType, cargoData);
                    using (SQLiteCommand SQLiteCommand = new SQLiteCommand(commandText, SQLiteConnection))
                    {
                        int result = SQLiteCommand.ExecuteNonQuery();
                        return (result == 1);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Write("Exception: " + ex.Message);
                return false;
            }
        }
        public bool Update(string table, Int64 id, string cargoId, string cargoType, string cargoData)
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();

                    string commandText = string.Format("UPDATE {0} SET CargoId='{1}', CargoType='{2}', CargoData='{3}' WHERE Id={4}", table, cargoId, cargoType, cargoData, id);
                    using (SQLiteCommand SQLiteCommand = new SQLiteCommand(commandText, SQLiteConnection))
                    {
                        int result = SQLiteCommand.ExecuteNonQuery();
                        return (result == 1);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Write("Exception: " + ex.Message);
                return false;
            }
        }
    }
}
