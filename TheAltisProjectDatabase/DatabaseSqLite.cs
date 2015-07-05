using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace TheAltisProjectDatabase
{
    public class DatabaseItemSQLite : IDatabaseItem, IDatabaseItemGui
    {
        private LogManagerBase _LogManager;
        private string _ConnectionString;

        public DatabaseItemSQLite(LogManagerBase logManager, string filename)
        {
            _LogManager = logManager;

            _ConnectionString = @"Data Source=" + filename + ";Version=3;UseUTF16Encoding=True;";
            _LogManager.Info(_ConnectionString);
        }

        private bool CreateTable(string table)
        {
            if (string.IsNullOrWhiteSpace(table))
                return false;

            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();

                    string commandText = "CREATE  TABLE \"main\".\"" + table.ToLower() + 
                        "\" (\"Id\" INTEGER PRIMARY KEY  AUTOINCREMENT  NOT NULL , \"ItemId\" VARCHAR NOT NULL , \"ItemData\" VARCHAR)";

                    using (SQLiteCommand SQLiteCommand = new SQLiteCommand(commandText, SQLiteConnection))
                    {
                        SQLiteCommand.ExecuteNonQuery();
                        _LogManager.Info("New table created (Item): {0}", table);
                        SQLiteConnection.Close();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                _LogManager.Error("Exception: " + ex.Message);
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
                            if (row[2].ToString().ToLower() != "sqlite_sequence")
                                tables.Add(row[2].ToString());

                        SQLiteConnection.Close();
                        return tables.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                _LogManager.Error(ex.Message);
                return null;
            }
        }
        public bool DropTable(string table)
        {
            if (string.IsNullOrWhiteSpace(table))
                return false;

            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();

                    string commandText = string.Format("DROP TABLE '{0}'", table.ToLower());
                    using (SQLiteCommand SQLiteCommand = new SQLiteCommand(commandText, SQLiteConnection))
                    {
                        int result = SQLiteCommand.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                _LogManager.Error("Exception: " + ex.Message);
                return false;
            }
        }
        public SqlItem[] GetItems(string table)
        {
            if (string.IsNullOrWhiteSpace(table))
                return new SqlItem[0];

            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();

                    SQLiteCommand SQLiteCommand = new SQLiteCommand(string.Format("SELECT Id, ItemId, ItemData FROM '{0}' ORDER BY ItemId DESC;", table.ToLower()), SQLiteConnection);
                    using (SQLiteDataReader sqlReader = SQLiteCommand.ExecuteReader())
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
                _LogManager.Error("Exception: " + ex.Message);
                return null;
            }
        }
        public bool OpenOrCreateTable(string table)
        {
            if (string.IsNullOrWhiteSpace(table))
                return false;

            string[] tables = GetTables();
            if (tables == null)
                return false;

            if (tables.Contains(table.ToLower()))
                return true;

            return CreateTable(table.ToLower());
        }
        public bool InsertItemId(string table, string itemId, string itemData)
        {
            if (string.IsNullOrWhiteSpace(table))
                return false;
            if (!IsIdValid(itemId))
                return false;
            if (!IsDataValid(itemData))
                return false;

            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();

                    string commandText = string.Format("INSERT into '{0}' (ItemId, ItemData) VALUES ('{1}', '{2}')", table.ToLower(), itemId.ToLower(), itemData);
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
                _LogManager.Error("Exception: " + ex.Message);
                return false;
            }
        }
        public bool UpdateId(string table, Int64 id, string itemId, string itemData)
        {
            if (string.IsNullOrWhiteSpace(table))
                return false;

            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();
                    
                    //string commandText = "UPDATE '" + table + "' SET ItemId='" + itemId + "', ItemData='" + itemData + "' WHERE Id='" + id + "'";
                    string commandText = string.Format("UPDATE '{0}' SET ItemId='{1}', ItemData='{2}' WHERE Id='{3}'", table.ToLower(), itemId.ToLower(), itemData, id);
                    using (SQLiteCommand SQLiteCommand = new SQLiteCommand(commandText, SQLiteConnection))
                    {
                        int result = SQLiteCommand.ExecuteNonQuery();
                        return (result == 1);
                    }
                }
            }
            catch (Exception ex)
            {
                _LogManager.Error("Exception: " + ex.Message);
                return false;
            }
        }
        public bool UpdateItemId(string table, string itemId, string itemData)
        {
            if (string.IsNullOrWhiteSpace(table))
                return false;
            if (!IsIdValid(itemId))
                return false;
            if (!IsDataValid(itemData))
                return false;

            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();

                    string commandText = string.Format("UPDATE '{0}' SET ItemData='{2}' WHERE ItemId='{1}'", table.ToLower(), itemId.ToLower(), itemData);
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
                _LogManager.Error("Exception: " + ex.Message);
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
            if (string.IsNullOrWhiteSpace(table))
                return false;

            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();

                    string commandText = string.Format("DELETE FROM '{0}' WHERE Id={1}", table, id);
                    using (SQLiteCommand SQLiteCommand = new SQLiteCommand(commandText, SQLiteConnection))
                    {
                        int result = SQLiteCommand.ExecuteNonQuery();
                        return (result == 1);
                    }
                }
            }
            catch (Exception ex)
            {
                _LogManager.Error("Exception: " + ex.Message);
                return false;
            }
        }
        public bool DeleteItemId(string table, string itemId)
        {
            if (string.IsNullOrWhiteSpace(table))
                return false;
            if (!IsIdValid(itemId))
                return false;

            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();

                    string commandText = string.Format("DELETE FROM '{0}' WHERE ItemId='{1}'", table.ToLower(), itemId.ToLower());
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
                _LogManager.Error("Exception: " + ex.Message);
                return false;
            }
        }
        public string Select(string table, string itemId)
        {
            if (string.IsNullOrWhiteSpace(table))
                return null;
            if (!IsIdValid(itemId))
                return null;

            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();

                    string commandText = string.Format("SELECT ItemData FROM '{0}' WHERE ItemId='{1}'", table.ToLower(), itemId.ToLower());
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
                _LogManager.Error("Exception: " + ex.Message);
                return null;
            }
        }
        public Result SelectIds(string table)
        {
            if (string.IsNullOrWhiteSpace(table))
                return null;
            
            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();

                    string commandText = string.Format("SELECT ItemId FROM '{0}'", table.ToLower());
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
                            Result result = new Result(results.ToArray());
                            SQLiteConnection.Close();
                            return result;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _LogManager.Error("Exception: " + ex.Message);
                return null;
            }
        }
    }

    public class DatabaseCargoSQLite : IDatabaseCargo, IDatabaseCargoGui
    {
        private LogManagerBase _LogManager;
        private string _ConnectionString;

        public DatabaseCargoSQLite(LogManagerBase logManager, string filename)
        {
            _LogManager = logManager;
            _ConnectionString = @"Data Source=" + filename + ";Version=3;UseUTF16Encoding=True;";
            _LogManager.Info(_ConnectionString);
        }

        private bool CreateTable(string table)
        {
            if (string.IsNullOrWhiteSpace(table))
                return false;
            
            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();

                    string commandText = "CREATE  TABLE 'main'.'" + table.ToLower() + "' ('Id' INTEGER PRIMARY KEY  AUTOINCREMENT  NOT NULL, 'CargoId' VARCHAR NOT NULL, 'CargoType' VARCHAR NOT NULL, 'CargoData' VARCHAR NOT NULL)";

                    using (SQLiteCommand SQLiteCommand = new SQLiteCommand(commandText, SQLiteConnection))
                    {
                        SQLiteCommand.ExecuteNonQuery();
                        _LogManager.Error("New table created (Cargo): {0}", table.ToLower());
                        SQLiteConnection.Close();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                _LogManager.Error("Exception: " + ex.Message);
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
                            if (row[2].ToString().ToLower() != "sqlite_sequence")
                                tables.Add(row[2].ToString());

                        SQLiteConnection.Close();
                        return tables.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                _LogManager.Error("Exception: " + ex.Message);
                return null;
            }
        }
        public bool DropTable(string table)
        {
            if (string.IsNullOrWhiteSpace(table))
                return false;

            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();

                    string commandText = string.Format("DROP TABLE '{0}'", table);
                    using (SQLiteCommand SQLiteCommand = new SQLiteCommand(commandText, SQLiteConnection))
                    {
                        int result = SQLiteCommand.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                _LogManager.Error("Exception: " + ex.Message);
                return false;
            }
        }
        public bool OpenOrCreateTable(string table)
        {
            if (string.IsNullOrWhiteSpace(table))
                return false;

            string[] tables = GetTables();
            if (tables == null)
                return false;

            if (tables.Contains(table.ToLower()))
                return true;

            return CreateTable(table);
        }
        public bool Insert(string table, string cargoId, string cargoType, string cargoData)
        {
            if (string.IsNullOrWhiteSpace(table))
                return false;
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

                    string commandText = string.Format("INSERT into '{0}' (CargoId, CargoType, CargoData) VALUES ('{1}', '{2}', '{3}')", table.ToLower(), cargoId.ToLower(), cargoType.ToLower(), cargoData);
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
                _LogManager.Error("Exception: " + ex.Message);
                return false;
            }
        }
        public bool DeleteCargoType(string table, string cargoId, string cargoType)
        {
            if (string.IsNullOrWhiteSpace(table))
                return false;
            if (!IsCargoIdValid(cargoId))
                return false;
            if (!IsCargoTypeValid(cargoType))
                return false;

            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();

                    string commandText = string.Format("DELETE FROM '{0}' WHERE CargoId='{1}' AND CargoType='{2}'", table.ToLower(), cargoId.ToLower(), cargoType.ToLower());
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
                _LogManager.Error("Exception: " + ex.Message);
                return false;
            }
        }
        public bool DeleteCargoId(string table, string cargoId)
        {
            if (string.IsNullOrWhiteSpace(table))
                return false;
            if (!IsCargoIdValid(cargoId))
                return false;

            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();

                    string commandText = string.Format("DELETE FROM '{0}' WHERE CargoId='{1}'", table.ToLower(), cargoId.ToLower());
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
                _LogManager.Error("Exception: " + ex.Message);
                return false;
            }
        }
        public bool DeleteId(string table, Int64 id)
        {
            if (string.IsNullOrWhiteSpace(table))
                return false;

            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();

                    string commandText = string.Format("DELETE FROM '{0}' WHERE Id='{1}'", table.ToLower(), id);
                    using (SQLiteCommand SQLiteCommand = new SQLiteCommand(commandText, SQLiteConnection))
                    {
                        int result = SQLiteCommand.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                _LogManager.Error("Exception: " + ex.Message);
                return false;
            }
        }
        public Result Select(string table, string cargoId, string cargoType)
        {
            if (string.IsNullOrWhiteSpace(table))
                return null;
            if (!IsCargoIdValid(cargoId))
                return null;
            if (!IsCargoTypeValid(cargoType))
                return null;

            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();

                    string commandText = string.Format("SELECT CargoData FROM '{0}' WHERE CargoId='{1}' AND CargoType='{2}'", table.ToLower(), cargoId.ToLower(), cargoType.ToLower());
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

                            Result result = new Result(items.ToArray());
                            SQLiteConnection.Close();
                            return result;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _LogManager.Error("Exception: " + ex.Message);
                return null;
            }
        }
        public Result SelectIds(string table)
        {
            if (string.IsNullOrWhiteSpace(table))
                return null;
            
            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();

                    string commandText = string.Format("SELECT CargoId FROM '{0}'", table.ToLower());
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

                            Result result = new Result(items.ToArray());
                            SQLiteConnection.Close();
                            return result;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _LogManager.Error("Exception: " + ex.Message);
                return null;
            }
        }
        public string[] GetCargoIds(string table)
        {
            if (string.IsNullOrWhiteSpace(table))
                return new string[0];

            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();

                    SQLiteCommand SQLiteCommand = new SQLiteCommand("SELECT DISTINCT CargoId FROM '" + table.ToLower() + "' ORDER BY CargoId DESC;", SQLiteConnection);
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
                _LogManager.Error("Exception: " + ex.Message);
                return null;
            }
        }
        public IdStringPair[] GetCargoData(string table, string cargoId, string cargoType)
        {
            if (string.IsNullOrWhiteSpace(table))
                return new IdStringPair[0];

            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();

                    SQLiteCommand SQLiteCommand = new SQLiteCommand(string.Format("SELECT Id, CargoData FROM {0} WHERE CargoId='{1}' AND CargoType='{2}';", table.ToLower(), cargoId.ToLower(), cargoType.ToLower()), SQLiteConnection);
                    using (SQLiteDataReader sqlReader = SQLiteCommand.ExecuteReader())
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
                _LogManager.Error("Exception: " + ex.Message);
                return null;
            }
        }
        public bool Update(string table, Int64 id, string cargoId, string cargoType, string cargoData)
        {
            if (string.IsNullOrWhiteSpace(table))
                return false;

            try
            {
                using (SQLiteConnection SQLiteConnection = new SQLiteConnection(_ConnectionString))
                {
                    SQLiteConnection.Open();

                    string commandText = string.Format("UPDATE '{0}' SET CargoId='{1}', CargoType='{2}', CargoData='{3}' WHERE Id={4}", table.ToLower(), cargoId.ToLower(), cargoType.ToLower(), cargoData, id);
                    using (SQLiteCommand SQLiteCommand = new SQLiteCommand(commandText, SQLiteConnection))
                    {
                        int result = SQLiteCommand.ExecuteNonQuery();
                        return (result == 1);
                    }
                }
            }
            catch (Exception ex)
            {
                _LogManager.Error("Exception: " + ex.Message);
                return false;
            }
        }
    }
}
