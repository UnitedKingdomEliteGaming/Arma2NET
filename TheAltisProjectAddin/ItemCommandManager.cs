using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAltisProjectAddin
{
    class ItemCommandManager
    {
        public string Parse(string[] split)
        {
            try
            {
                if (split.Length < 2)
                    return "ERROR_ITEM_SPLIT_LENGTH";

                if (split[1].ToLower() == "select")
                {
                    #region item|select|table|uid
                    try
                    {
                        if (split.Length < 4)
                        {
                            Arma2Net.Utils.Log("ERROR: Item.Select ERROR_ITEM_SELECT_SPLIT_LENGTH");
                            return "ERROR"; // Nur über ERROR beenden, sonst kann die SQF sich nicht beenden.
                        }

                        MsSql.ItemManager sql = new MsSql.ItemManager(split[2].ToLower());
                        string result = sql.Select(split[3]);
                        if (result == null)
                        {
                            Arma2Net.Utils.Log("ERROR: Item.Select ERROR_ITEM_SELECT_NULL");
                            return "ERROR"; // Nur über ERROR beenden, sonst kann die SQF sich nicht beenden.
                        }

                        return result;
                    }
                    catch (Exception ex)
                    {
                        Arma2Net.Utils.Log("ERROR: Item.Select failed: " + ex.Message);
                        return "ERROR";
                    }
                    #endregion
                }
                else if (split[1].ToLower() == "update")
                {
                    #region item|update|table|uid|data
                    try
                    {
                        if (split.Length < 5)
                            return "ERROR_ITEM_UPDATE_SPLIT_LENGTH";

                        MsSql.ItemManager sql = new MsSql.ItemManager(split[2].ToLower());
                        if (!sql.Update(split[3], split[4]))
                            return "ERROR_ITEM_UPDATE";
                        
                        return "OK";
                    }
                    catch (Exception ex)
                    {
                        Arma2Net.Utils.Log("ERROR: Item.Update failed: " + ex.Message);
                        return "ERROR_ITEM_UPDATE_EXCEPTION";
                    }
                    #endregion
                }
                else if (split[1].ToLower() == "updateinsert")
                {
                    #region item|updateinsert|table|uid|data
                    try
                    {
                        if (split.Length < 5)
                            return "ERROR_ITEM_UPDATEINSERT_SPLIT_LENGTH";

                        MsSql.ItemManager sql = new MsSql.ItemManager(split[2].ToLower());
                        if (!sql.UpdateOrInsert(split[3], split[4]))
                            return "ERROR_ITEM_UPDATEINSERT";
                        
                        return "OK";
                    }
                    catch (Exception ex)
                    {
                        Arma2Net.Utils.Log("ERROR: Item.UpdateInsert failed: " + ex.Message);
                        return "ERROR_ITEM_UPDATEINSERT_EXCEPTION";
                    }
                    #endregion
                }
                else if (split[1].ToLower() == "init")
                {
                    #region item|init|table
                    try
                    {
                        if (split.Length < 3)
                            return "ERROR_ITEM_INIT_SPLIT_LENGTH";

                        MsSql.ItemManager sql = new MsSql.ItemManager(split[2].ToLower());
                        if (!sql.Initialize())
                            return "ERROR_ITEM_INIT";

                        return "OK";
                    }
                    catch (Exception ex)
                    {
                        Arma2Net.Utils.Log("ERROR: Item.Init failed: " + ex.Message);
                        return "ERROR_ITEM_INIT_EXCEPTION";
                    }
                    #endregion
                }
                else if (split[1].ToLower() == "delete")
                {
                    #region item|delete|table|uid
                    try
                    {
                        if (split.Length < 4)
                            return "ERROR_ITEM_DELETE_SPLIT_LENGTH";

                        MsSql.ItemManager sql = new MsSql.ItemManager(split[2].ToLower());
                        if (!sql.Delete(split[3]))
                            return "ERROR_ITEM_DELETE";

                        return "OK";
                    }
                    catch (Exception ex)
                    {
                        Arma2Net.Utils.Log("ERROR: Item.Delete failed: " + ex.Message);
                        return "ERROR_ITEM_DELETE_EXCEPTION";
                    }
                    #endregion
                }
                else
                    return "ERROR_ITEM_INVALID_COMMAND";
            }
            catch (Exception ex)
            {
                Arma2Net.Utils.Log("ERROR: Item-Exception: " + ex.Message);
                return "ERROR_ITEM_EXCEPTION";
            }
        }
    }
}
