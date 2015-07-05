using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAltisProjectDatabase;

namespace TheAltisProjectAddin
{
    class ItemCommandManager
    {
        private IDatabaseItem _IDatabaseItem;
        private Result _Result = null;

        public ItemCommandManager()
        {
            _IDatabaseItem = new DatabaseItemSQLite(new LogManager(), System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "DatabaseItem.sqlite"));
        }

        private string SplitToString(string[] split)
        {
            if (split == null)
                return "split==null";
            if (split.Length == 0)
                return "split.Length==0";

            string result = "";
            for (int i = 0; i < split.Length; i++)
            {
                result += i.ToString() + "(";
                if (split[i] != null)
                    result += split[i] + ") ";
                else
                    result += "null) ";
            }

            return result;
        }

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
                            Arma2Net.Utils.Log("ERROR: Item.Select ERROR_ITEM_SELECT_SPLIT_LENGTH: Split=" + SplitToString(split));
                            return "ERROR"; // Nur über ERROR beenden, sonst kann die SQF sich nicht beenden.
                        }

                        string result = _IDatabaseItem.Select(split[2], split[3]);
                        if (result == null)
                        {
                            Arma2Net.Utils.Log("ERROR_ITEM_SELECT: Split=" + SplitToString(split));
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
                if (split[1].ToLower() == "selectids")
                {
                    #region item|selectids|table
                    try
                    {
                        if (split.Length < 3)
                        {
                            Arma2Net.Utils.Log("ERROR_ITEM_SELECTIDS_SPLIT_LENGTH: Split=" + SplitToString(split));
                            return "ERROR_ITEM_SELECTIDS_SPLIT_LENGTH";
                        }
                        if (_Result != null)
                        {
                            Arma2Net.Utils.Log("ERROR_ITEM_SELECTIDS_ACTIVE: Split=" + SplitToString(split));
                            return "ERROR_ITEM_SELECTIDS_ACTIVE";
                        }
                        _Result = _IDatabaseItem.SelectIds(split[2]);

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
                    #region item|selectnext
                    try
                    {
                        if (split.Length < 2)
                        {
                            Arma2Net.Utils.Log("ERROR: ITEM.Selectnext ERROR_ITEM_SELECTNEXT_SPLIT_LENGTH: Split=" + SplitToString(split));
                            return "ERROR"; // Nur über ERROR beenden, sonst kann die SQF sich nicht beenden.
                        }

                        if (_Result == null)
                        {
                            Arma2Net.Utils.Log("ERROR: ITEM.Selectnext ERROR_ITEM_SELECTNEXT_INACTIVE: Split=" + SplitToString(split));
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
                        Arma2Net.Utils.Log("ERROR: ITEM.Selectnext failed: " + ex.Message);
                        return "ITEM"; // Nur über ERROR beenden, sonst kann die SQF sich nicht beenden.
                    }
                    #endregion
                }
                else if (split[1].ToLower() == "update")
                {
                    #region item|update|table|uid|data
                    try
                    {
                        if (split.Length < 5)
                        {
                            Arma2Net.Utils.Log("ERROR_ITEM_UPDATE_SPLIT_LENGTH: Split=" + SplitToString(split));
                            return "ERROR_ITEM_UPDATE_SPLIT_LENGTH";
                        }
                        if (!_IDatabaseItem.UpdateItemId(split[2], split[3], split[4]))
                        {
                            Arma2Net.Utils.Log("ERROR_ITEM_UPDATE: Split=" + SplitToString(split));
                            return "ERROR_ITEM_UPDATE";
                        }
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
                        {
                            Arma2Net.Utils.Log("ERROR_ITEM_UPDATEINSERT_SPLIT_LENGTH: Split=" + SplitToString(split));
                            return "ERROR_ITEM_UPDATEINSERT_SPLIT_LENGTH";
                        }
                        if (!_IDatabaseItem.UpdateOrInsertItemId(split[2], split[3], split[4]))
                        {
                            Arma2Net.Utils.Log("ERROR_ITEM_UPDATEINSERT: Split=" + SplitToString(split));
                            return "ERROR_ITEM_UPDATEINSERT";
                        }
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
                        {
                            Arma2Net.Utils.Log("ERROR_ITEM_INIT_SPLIT_LENGTH: Split=" + SplitToString(split));
                            return "ERROR_ITEM_INIT_SPLIT_LENGTH";
                        }
                        if (!_IDatabaseItem.OpenOrCreateTable(split[2]))
                        {
                            Arma2Net.Utils.Log("ERROR_ITEM_INIT: Split=" + SplitToString(split));
                            return "ERROR_ITEM_INIT";
                        }
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
                        {
                            Arma2Net.Utils.Log("ERROR_ITEM_DELETE_SPLIT_LENGTH: Split=" + SplitToString(split));
                            return "ERROR_ITEM_DELETE_SPLIT_LENGTH";
                        }

                        if (!_IDatabaseItem.DeleteItemId(split[2], split[3]))
                        {
                            Arma2Net.Utils.Log("ERROR_ITEM_DELETE: Split=" + SplitToString(split));
                            return "ERROR_ITEM_DELETE";
                        }
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
