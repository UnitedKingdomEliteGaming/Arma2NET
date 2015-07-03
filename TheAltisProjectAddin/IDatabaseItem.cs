using System;
namespace TheAltisProjectAddin
{
    public interface IDatabaseItem
    {
        #region public class Result
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
        #endregion

        bool DeleteItemId(string table, string id);
        bool Initialize(string table);
        bool InsertItemId(string table, string id, string data);
        string Select(string table, string id);
        Result SelectIds(string table);
        bool UpdateItemId(string table, string id, string data);
        bool UpdateOrInsertItemId(string table, string id, string data);
    }

    public interface IDatabaseItemGui
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

        string[] GetTables();
        bool DropTable(string table);
        IDatabaseItemGui.SqlItem[] GetItems(string table);
        bool InsertItemId(string table, string id, string itemData);
        bool UpdateId(string table, Int64 id, string itemId, string itemData);
        bool DeleteId(string table, Int64 id);
    }
}
