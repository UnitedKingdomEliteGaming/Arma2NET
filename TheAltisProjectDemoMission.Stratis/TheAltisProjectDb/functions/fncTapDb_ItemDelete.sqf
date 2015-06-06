private["_table"];
_table = _this select 0;
private["_itemId"];
_itemId = _this select 1;

private["_dbResult"];	
_dbResult = "Arma2NET" callExtension format["TAP item|delete|%1|%2", _table, _itemId];

private["_result"];
_result = (_dbResult == "OK"); 
_result;