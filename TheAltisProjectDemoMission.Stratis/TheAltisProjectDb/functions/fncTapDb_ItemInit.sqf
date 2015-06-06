private["_table"];
_table = _this select 0;

private["_dbResult"];	
_dbResult = "Arma2NET" callExtension format["TAP item|init|%1", _table];
diag_log format["TAP item|init|%1 = %2", _table, _dbResult];

private["_result"];
_result = (_dbResult == "OK"); 
_result;