using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TheAltisProjectDatabase
{
    public class DatabaseItemMsSql : IDatabaseItem, IDatabaseItemGui
    {
        private LogManagerBase _LogManager;
        private string _ConnectionString;

        public DatabaseItemMsSql(LogManagerBase logManager)
        {
            _LogManager = logManager;
            _ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "DatabaseItem.mdf") + ";Integrated Security=True";


            // Server=.\SQLExpress;AttachDbFilename=C:\MyFolder\MyDataFile.mdf;Database=dbname;Trusted_Connection=Yes;
            //Server=.\SQLExpress;AttachDbFilename=|DataDirectory|mydbfile.mdf;Database=dbname;Trusted_Connection = Yes;
        }

        private bool CreateTable(string table)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    sqlConnection.Open();

                    string commandText = @"
                            CREATE TABLE [dbo].[" + table.ToLower() + @"] (
                                [Id] BIGINT IDENTITY (1, 1) NOT NULL,
                                [ItemId]   NVARCHAR (64)  NOT NULL,
                                [ItemData] NVARCHAR (MAX) NOT NULL,
                                PRIMARY KEY CLUSTERED ([Id] ASC)
                            );";

                    using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                    {
                        sqlCommand.ExecuteNonQuery();
                        _LogManager.Error("New table created (Item): {0}", table);
                        sqlConnection.Close();
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
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    sqlConnection.Open();
                    using (System.Data.DataTable schema = sqlConnection.GetSchema("Tables"))
                    {
                        List<string> tables = new List<string>(8);
                        foreach (System.Data.DataRow row in schema.Rows)
                            tables.Add(row[2].ToString());

                        sqlConnection.Close();
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
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
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
                _LogManager.Error("Exception: " + ex.Message);
                return false;
            }
        }
        public SqlItem[] GetItems(string table)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
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
                _LogManager.Error("Exception: " + ex.Message);
                return null;
            }
        }
        public bool OpenOrCreateTable(string table)
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
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    sqlConnection.Open();

                    string commandText = string.Format("INSERT into {0} (ItemId, ItemData) VALUES ('{1}', '{2}')", table.ToLower(), itemId, itemData);
                    using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                    {
                        int result = sqlCommand.ExecuteNonQuery();
                        //Arma2Net.Utils.Log(commandText + ": " + result);
                        sqlConnection.Close();
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
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
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
                _LogManager.Error("Exception: " + ex.Message);
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
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    sqlConnection.Open();

                    string commandText = string.Format("UPDATE {0} SET ItemData='{2}' WHERE ItemId='{1}'", table.ToLower(), itemId, itemData);
                    using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                    {
                        int result = sqlCommand.ExecuteNonQuery();
                        //Arma2Net.Utils.Log(commandText + ": " + result);
                        sqlConnection.Close();
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
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
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
                _LogManager.Error("Exception: " + ex.Message);
                return false;
            }
        }
        public bool DeleteItemId(string table, string itemId)
        {
            if (!IsIdValid(itemId))
                return false;

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    sqlConnection.Open();

                    string commandText = string.Format("DELETE FROM {0} WHERE ItemId='{1}'", table.ToLower(), itemId);
                    using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                    {
                        int result = sqlCommand.ExecuteNonQuery();
                        //Arma2Net.Utils.Log(commandText + ": " + result);
                        sqlConnection.Close();
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
            if (!IsIdValid(itemId))
                return null;

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    sqlConnection.Open();

                    string commandText = string.Format("SELECT ItemData FROM {0} WHERE ItemId='{1}'", table.ToLower(), itemId);
                    using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                    {
                        using (SqlDataReader sqlReader = sqlCommand.ExecuteReader())
                        {
                            if (!sqlReader.Read())
                                return null;

                            if (sqlReader.IsDBNull(0))
                                return null;

                            string result = sqlReader.GetString(0);
                            //Arma2Net.Utils.Log(commandText + ": " + result);
                            sqlConnection.Close();
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
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    sqlConnection.Open();

                    string commandText = string.Format("SELECT ItemId FROM {0}", table.ToLower());
                    using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                    {
                        using (SqlDataReader sqlReader = sqlCommand.ExecuteReader())
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
                            sqlConnection.Close();
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

    public class DatabaseCargoMsSql : IDatabaseCargo, IDatabaseCargoGui
    {
        private LogManagerBase _LogManager;
        private string _ConnectionString;

        public DatabaseCargoMsSql(LogManagerBase logManager)
        {
            _LogManager = logManager;
            _ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "DatabaseCargo.mdf") + ";Integrated Security=True";
        }

        private bool CreateTable(string table)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    sqlConnection.Open();

                    string commandText = @"
                            CREATE TABLE [dbo].[" + table.ToLower() + @"] (
                                [Id]        BIGINT         IDENTITY (1, 1) NOT NULL,
                                [CargoId]   NVARCHAR (64)  NOT NULL,
                                [CargoType] NVARCHAR (3)   NOT NULL,
                                [CargoData] NVARCHAR (256) NOT NULL,
                                PRIMARY KEY CLUSTERED ([Id] ASC)
                            );";

                    using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                    {
                        sqlCommand.ExecuteNonQuery();
                        _LogManager.Error("New table created (Cargo): {0}", table.ToLower());
                        sqlConnection.Close();
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

        // IDatabaseCargo
        public bool OpenOrCreateTable(string table)
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
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    sqlConnection.Open();

                    string commandText = string.Format("INSERT into {0} (CargoId, CargoType, CargoData) VALUES ('{1}', '{2}', '{3}')", table.ToLower(), cargoId, cargoType.ToLower(), cargoData);
                    using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                    {
                        int result = sqlCommand.ExecuteNonQuery();
                        //Arma2Net.Utils.Log(commandText + ": " + result);
                        sqlConnection.Close();
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
        public bool DeleteId(string table, Int64 id)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
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
                _LogManager.Error("Exception: " + ex.Message);
                return false;
            }
        }
        public bool DeleteCargoId(string table, string cargoId)
        {
            if (!IsCargoIdValid(cargoId))
                return false;

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    sqlConnection.Open();

                    string commandText = string.Format("DELETE FROM {0} WHERE CargoId='{1}'", table.ToLower(), cargoId);
                    using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                    {
                        int result = sqlCommand.ExecuteNonQuery();
                        //Arma2Net.Utils.Log(commandText + ": " + result);
                        sqlConnection.Close();
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
        public bool DeleteCargoType(string table, string cargoId, string cargoType)
        {
            if (!IsCargoIdValid(cargoId))
                return false;
            if (!IsCargoTypeValid(cargoType))
                return false;

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    sqlConnection.Open();

                    string commandText = string.Format("DELETE FROM {0} WHERE CargoId='{1}' AND CargoType='{2}'", table.ToLower(), cargoId, cargoType.ToLower());
                    using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                    {
                        int result = sqlCommand.ExecuteNonQuery();
                        //Arma2Net.Utils.Log(commandText + ": " + result);
                        sqlConnection.Close();
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
            if (!IsCargoIdValid(cargoId))
                return null;
            if (!IsCargoTypeValid(cargoType))
                return null;

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    sqlConnection.Open();

                    string commandText = string.Format("SELECT CargoData FROM {0} WHERE CargoId='{1}' AND CargoType='{2}'", table.ToLower(), cargoId, cargoType.ToLower());
                    using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                    {
                        List<string> items = new List<string>(8);
                        using (SqlDataReader sqlReader = sqlCommand.ExecuteReader())
                        {
                            while (sqlReader.Read())
                            {
                                if (sqlReader.IsDBNull(0))
                                    return null;

                                items.Add(sqlReader.GetString(0));
                            }

                            Result result = new Result(items.ToArray());
                            sqlConnection.Close();
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
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    sqlConnection.Open();

                    string commandText = string.Format("SELECT CargoId FROM {0}", table.ToLower());
                    using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                    {
                        List<string> items = new List<string>(8);
                        using (SqlDataReader sqlReader = sqlCommand.ExecuteReader())
                        {
                            while (sqlReader.Read())
                            {
                                if (sqlReader.IsDBNull(0))
                                    return null;

                                items.Add(sqlReader.GetString(0));
                            }

                            Result result = new Result(items.ToArray());
                            sqlConnection.Close();
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

        // IDatabaseCargoEx 
        public string[] GetTables()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    sqlConnection.Open();
                    using (System.Data.DataTable schema = sqlConnection.GetSchema("Tables"))
                    {
                        List<string> tables = new List<string>(8);
                        foreach (System.Data.DataRow row in schema.Rows)
                            tables.Add(row[2].ToString());

                        sqlConnection.Close();
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
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
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
                _LogManager.Error("Exception: " + ex.Message);
                return false;
            }
        }
        public string[] GetCargoIds(string table)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
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
                _LogManager.Error("Exception: " + ex.Message);
                return null;
            }
        }
        public IdStringPair[] GetCargoData(string table, string cargoId, string cargoType)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
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
                _LogManager.Error("Exception: " + ex.Message);
                return null;
            }
        }
        public bool Update(string table, Int64 id, string cargoId, string cargoType, string cargoData)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    sqlConnection.Open();

                    string commandText = string.Format("UPDATE {0} SET CargoId='{1}', CargoType='{2}', CargoData='{3}' WHERE Id={4}", table, cargoId, cargoType, cargoData, id);
                    using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                    {
                        int result = sqlCommand.ExecuteNonQuery();
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
