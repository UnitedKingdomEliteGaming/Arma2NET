using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAltisProjectAddin
{
    class CargoCommandManager
    {
        private MsSql.CargoManager.Result _Result = null;

        public string Parse(string[] split)
        {
            try
            {
                if (split.Length < 2)
                    return "ERROR_CARGO_SPLIT_LENGTH";

                if (split[1].ToLower() == "select")
                {
                    #region cargo|select|boxid|type
                    try
                    {
                        if (split.Length < 4)
                            return "ERROR_CARGO_SELECT_SPLIT_LENGTH";

                        if (_Result != null)
                            return "ERROR_CARGO_SELECT_ACTIVE";

                        MsSql.CargoManager sql = new MsSql.CargoManager();
                        _Result = sql.Select(split[2], split[3]);

                        return "OK";
                    }
                    catch (Exception ex)
                    {
                        Arma2Net.Utils.Log("ERROR: CARGO.Select failed: " + ex.Message);
                        return "ERROR_CARGO_SELECT_EXCEPTION";
                    }
                    #endregion
                }
                else if (split[1].ToLower() == "selectnext")
                {
                    #region cargo|selectnext
                    try
                    {
                        if (split.Length < 2)
                        {
                            Arma2Net.Utils.Log("ERROR: CARGO.Selectnext ERROR_CARGO_SELECTNEXT_SPLIT_LENGTH");
                            return "ERROR"; // Nur über ERROR beenden, sonst kann die SQF sich nicht beenden.
                        }

                        if (_Result == null)
                        {
                            Arma2Net.Utils.Log("ERROR: CARGO.Selectnext ERROR_CARGO_SELECTNEXT_INACTIVE");
                            return "ERROR"; // Nur über ERROR beenden, sonst kann die SQF sich nicht beenden.
                        }

                        string result = _Result.Next();
                        if (result == null)
                        {
                            _Result = null;
                            return "EOF"; // Alles gut, das war der letzt Eintrag
                        }

                        return result;
                    }
                    catch (Exception ex)
                    {
                        Arma2Net.Utils.Log("ERROR: CARGO.Selectnext failed: " + ex.Message);
                        return "ERROR"; // Nur über ERROR beenden, sonst kann die SQF sich nicht beenden.
                    }
                    #endregion
                }
                else if (split[1].ToLower() == "insert")
                {
                    #region cargo|insert|boxid|type|data
                    try
                    {
                        if (split.Length < 5)
                            return "ERROR_CARGO_INSERT_SPLIT_LENGTH";

                        MsSql.CargoManager sql = new MsSql.CargoManager();
                        if (!sql.Insert(split[2], split[3], split[4]))
                            return "ERROR_CARGO_INSERT";
                        
                        return "OK";
                    }
                    catch (Exception ex)
                    {
                        Arma2Net.Utils.Log("ERROR: CARGO.Insert failed: " + ex.Message);
                        return "ERROR_CARGO_INSERT_EXCEPTION";
                    }
                    #endregion
                }
                else if (split[1].ToLower() == "deleteall")
                {
                    #region cargo|deleteall|boxid
                    try
                    {
                        if (split.Length < 3)
                            return "ERROR_CARGO_DELETEALL_SPLIT_LENGTH";

                        MsSql.CargoManager sql = new MsSql.CargoManager();
                        if (!sql.DeleteAll(split[2].ToLower()))
                            return "ERROR_CARGO_DELETEALL";

                        return "OK";
                    }
                    catch (Exception ex)
                    {
                        Arma2Net.Utils.Log("ERROR: CARGO.DeleteAll failed: " + ex.Message);
                        return "ERROR_CARGO_DELETEALL_EXCEPTION";
                    }
                    #endregion
                }
                else if (split[1].ToLower() == "deletetype")
                {
                    #region cargo|deletetype|boxid|type
                    try
                    {
                        if (split.Length < 4)
                            return "ERROR_CARGO_DELETETYPE_SPLIT_LENGTH";

                        MsSql.CargoManager sql = new MsSql.CargoManager();
                        if (!sql.DeleteType(split[2],split[3]))
                            return "ERROR_CARGO_DELETETYPE";

                        return "OK";
                    }
                    catch (Exception ex)
                    {
                        Arma2Net.Utils.Log("ERROR: CARGO.DeleteType failed: " + ex.Message);
                        return "ERROR_CARGO_DELETETYPE_EXCEPTION";
                    }
                    #endregion
                }
                else
                    return "ERROR_CARGO_INVALID_COMMAND";
            }
            catch (Exception ex)
            {
                Arma2Net.Utils.Log("ERROR: CARGO-Exception: " + ex.Message);
                return "ERROR_CARGO_EXCEPTION";
            }
        }
    }
}
