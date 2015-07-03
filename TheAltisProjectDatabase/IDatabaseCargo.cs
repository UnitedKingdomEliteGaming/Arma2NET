using System;
namespace TheAltisProjectDatabase
{
    public interface IDatabaseCargo
    {
        bool DeleteCargoId(string table, string cargoId);
        bool DeleteCargoType(string table, string cargoId, string cargoType);
        bool OpenOrCreateTable(string table);
        bool Insert(string table, string cargoId, string cargoType, string cargoData);
        Result Select(string table, string cargoId, string cargoType);
        Result SelectIds(string table);
    }
    public interface IDatabaseCargoGui
    {
        string[] GetTables();
        bool OpenOrCreateTable(string table);
        bool DropTable(string table);
        string[] GetCargoIds(string table);
        IdStringPair[] GetCargoData(string table, string cargoId, string cargoType);
        bool Insert(string table, string cargoId, string cargoType, string cargoData);
        bool DeleteId(string table, Int64 id);
        bool DeleteCargoId(string table, string cargoId);
        bool DeleteCargoType(string table, string cargoId, string cargoType);
        bool Update(string table, Int64 id, string cargoId, string cargoType, string cargoData);
    }
}
