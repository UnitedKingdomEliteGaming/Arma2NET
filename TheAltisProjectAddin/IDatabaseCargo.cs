using System;
namespace TheAltisProjectAddin
{
    public interface IDatabaseCargo
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

        bool DeleteCargoId(string table, string cargoId);
        bool DeleteCargoType(string table, string cargoId, string cargoType);
        bool Initialize(string table);
        bool Insert(string table, string cargoId, string cargoType, string cargoData);
        Result Select(string table, string cargoId, string cargoType);
        Result SelectIds(string table);
    }
    public interface IDatabaseCargoGui
    {
        #region public class IdStringPair
        public class IdStringPair
        {
            public Int64 Id;
            public string Text;

            public IdStringPair(Int64 id, string text)
            {
                Id = id;
                Text = text;
            }
            public override string ToString()
            {
                return Text;
            }
        }
        #endregion

        string[] GetTables();
        string[] GetCargoIds(string table);
        IdStringPair[] GetCargoData(string table, string cargoId, string cargoType);
        bool DropTable(string table);
        bool DeleteId(string table, Int64 id);
        bool DeleteCargoId(string table, string cargoId);
        bool DeleteCargoType(string table, string cargoId, string cargoType);
    }
}
