using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TheAltisProjectAddin
{
    public class MsSql
    {
        public static class Configuration
        {
            public static string ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Database.mdf") + ";Integrated Security=True";
        }

        public class ItemManager
        {
            private string _Table;

            public ItemManager(string table)
            {
                _Table = table;
            }

            private string[] GetTables()
            {
                try
                {
                    using (SqlConnection sqlConnection = new SqlConnection(MsSql.Configuration.ConnectionString))
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
                    Arma2Net.Utils.Log("Exception: " + ex.Message);
                    return null;
                }
            }
            private bool CreateTable()
            {
                try
                {
                    using (SqlConnection sqlConnection = new SqlConnection(MsSql.Configuration.ConnectionString))
                    {
                        sqlConnection.Open();

                        string commandText = @"
                            CREATE TABLE [dbo].[" + _Table + @"] (
                                [Id] BIGINT IDENTITY (1, 1) NOT NULL,
                                [ItemId]   NVARCHAR (64)  NOT NULL,
                                [ItemData] NVARCHAR (MAX) NOT NULL,
                                PRIMARY KEY CLUSTERED ([Id] ASC)
                            );";

                        using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                        {
                            sqlCommand.ExecuteNonQuery();
                            Arma2Net.Utils.Log("New table created: {0}", _Table);
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Arma2Net.Utils.Log("Exception: " + ex.Message);
                    return false;
                }
            }
            private bool IsIdValid(string id)
            {
                if (string.IsNullOrWhiteSpace(id))
                    return false;

                return true;
            }
            private bool IsDataValid(string data)
            {
                if (data == null)
                    return false;

                return true;
            }

            public bool Initialize()
            {
                string[] tables = GetTables();
                if (tables == null)
                    return false;

                if (tables.Contains(_Table))
                    return true;

                return CreateTable();
            }
            public bool Insert(string id, string data)
            {
                if (!IsIdValid(id))
                    return false;
                if (!IsDataValid(data))
                    return false;

                try
                {
                    using (SqlConnection sqlConnection = new SqlConnection(MsSql.Configuration.ConnectionString))
                    {
                        sqlConnection.Open();

                        string commandText = string.Format("INSERT into {0} (ItemId, ItemData) VALUES ('{1}', '{2}')", _Table, id, data);
                        using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                        {
                            int result = sqlCommand.ExecuteNonQuery();
                            //Arma2Net.Utils.Log(commandText + ": " + result);
                            return (result == 1);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Arma2Net.Utils.Log("Exception: " + ex.Message);
                    return false;
                }
            }
            public bool Update(string id, string data)
            {
                if (!IsIdValid(id))
                    return false;
                if (!IsDataValid(data))
                    return false;

                try
                {
                    using (SqlConnection sqlConnection = new SqlConnection(MsSql.Configuration.ConnectionString))
                    {
                        sqlConnection.Open();

                        string commandText = string.Format("UPDATE {0} SET ItemData='{2}' WHERE ItemId='{1}'", _Table, id, data);
                        using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                        {
                            int result = sqlCommand.ExecuteNonQuery();
                            //Arma2Net.Utils.Log(commandText + ": " + result);
                            return (result == 1);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Arma2Net.Utils.Log("Exception: " + ex.Message);
                    return false;
                }
            }
            public bool UpdateOrInsert(string id, string data)
            {
                if (Update(id, data))
                    return true;

                return Insert(id, data);
            }
            public bool Delete(string id)
            {
                if (!IsIdValid(id))
                    return false;

                try
                {
                    using (SqlConnection sqlConnection = new SqlConnection(MsSql.Configuration.ConnectionString))
                    {
                        sqlConnection.Open();

                        string commandText = string.Format("DELETE FROM {0} WHERE ItemId='{1}'", _Table, id);
                        using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                        {
                            int result = sqlCommand.ExecuteNonQuery();
                            //Arma2Net.Utils.Log(commandText + ": " + result);
                            return (result == 1);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Arma2Net.Utils.Log("Exception: " + ex.Message);
                    return false;
                }
            }
            public string Select(string id)
            {
                if (!IsIdValid(id))
                    return null;

                try
                {
                    using (SqlConnection sqlConnection = new SqlConnection(MsSql.Configuration.ConnectionString))
                    {
                        sqlConnection.Open();

                        string commandText = string.Format("SELECT ItemData FROM {0} WHERE ItemId='{1}'", _Table, id);
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
                                return result;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Arma2Net.Utils.Log("Exception: " + ex.Message);
                    return null;
                }
            }
        }

        public class CargoManager
        {
            public class Result
            {
                private int _CurrentIndex;
                private string[] _Results;

                public Result(string[] results)
                {
                    _Results = results;
                    _CurrentIndex = 0;
                }

                public string Next()
                {
                    if (_Results == null)
                        return null;
                    if (_CurrentIndex >= _Results.Length)
                        return null;

                    _CurrentIndex++;
                    return _Results[_CurrentIndex - 1];
                }
            }

            private string _Table = "Cargo";

            public CargoManager()
            {
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

            public bool Insert(string cargoId, string cargoType, string cargoData)
            {
                if (!IsCargoIdValid(cargoId))
                    return false;
                if (!IsCargoTypeValid(cargoType))
                    return false;
                if (!IsCargoDataValid(cargoData))
                    return false;

                try
                {
                    using (SqlConnection sqlConnection = new SqlConnection(MsSql.Configuration.ConnectionString))
                    {
                        sqlConnection.Open();

                        string commandText = string.Format("INSERT into {0} (CargoId, CargoType, CargoData) VALUES ('{1}', '{2}', '{3}')", _Table, cargoId, cargoType, cargoData);
                        using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                        {
                            int result = sqlCommand.ExecuteNonQuery();
                            //Arma2Net.Utils.Log(commandText + ": " + result);
                            return (result == 1);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Arma2Net.Utils.Log("Exception: " + ex.Message);
                    return false;
                }
            }
            public bool DeleteType(string cargoId, string cargoType)
            {
                if (!IsCargoIdValid(cargoId))
                    return false;
                if (!IsCargoTypeValid(cargoType))
                    return false;

                try
                {
                    using (SqlConnection sqlConnection = new SqlConnection(MsSql.Configuration.ConnectionString))
                    {
                        sqlConnection.Open();

                        string commandText = string.Format("DELETE FROM {0} WHERE CargoId='{1}' AND CargoType='{2}'", _Table, cargoId, cargoType);
                        using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                        {
                            int result = sqlCommand.ExecuteNonQuery();
                            //Arma2Net.Utils.Log(commandText + ": " + result);
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Arma2Net.Utils.Log("Exception: " + ex.Message);
                    return false;
                }
            }
            public bool DeleteAll(string cargoId)
            {
                if (!IsCargoIdValid(cargoId))
                    return false;

                try
                {
                    using (SqlConnection sqlConnection = new SqlConnection(MsSql.Configuration.ConnectionString))
                    {
                        sqlConnection.Open();

                        string commandText = string.Format("DELETE FROM {0} WHERE CargoId='{1}'", _Table, cargoId);
                        using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                        {
                            int result = sqlCommand.ExecuteNonQuery();
                            //Arma2Net.Utils.Log(commandText + ": " + result);
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Arma2Net.Utils.Log("Exception: " + ex.Message);
                    return false;
                }
            }
            public Result Select(string cargoId, string cargoType)
            {
                if (!IsCargoIdValid(cargoId))
                    return null;
                if (!IsCargoTypeValid(cargoType))
                    return null;

                try
                {
                    using (SqlConnection sqlConnection = new SqlConnection(MsSql.Configuration.ConnectionString))
                    {
                        sqlConnection.Open();

                        string commandText = string.Format("SELECT CargoData FROM {0} WHERE CargoId='{1}' AND CargoType='{2}'", _Table, cargoId, cargoType);
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

                                return new Result(items.ToArray());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Arma2Net.Utils.Log("Exception: " + ex.Message);
                    return null;
                }
            }
        }
    }
}