using System;
namespace TheAltisProjectDatabase
{
    public interface IDatabaseItem
    {
        bool DeleteItemId(string table, string id);
        bool OpenOrCreateTable(string table);
        bool InsertItemId(string table, string id, string data);
        string Select(string table, string id);
        Result SelectIds(string table);
        bool UpdateItemId(string table, string id, string data);
        bool UpdateOrInsertItemId(string table, string id, string data);
    }

    public interface IDatabaseItemGui
    {
        bool OpenOrCreateTable(string table);

        string[] GetTables();
        bool DropTable(string table);
        SqlItem[] GetItems(string table);
        bool InsertItemId(string table, string id, string itemData);
        bool UpdateId(string table, Int64 id, string itemId, string itemData);
        bool DeleteId(string table, Int64 id);
    }
}
