private["_table"];
_table = _this select 0;

private["_result","_dbResult", "_timeout"];
_result = [];
_timeout = 10;
_dbResult = "";
while { true } do
{
	_dbResult = "Arma2NET" callExtension format["TAP cargo|selectids|%1", _table];
	if ((_dbResult != "ERROR_CARGO_SELECTIDS_ACTIVE") || (_timeout <= 0)) exitWith {};	
	Sleep 1;
	_timeout = _timeout - 1;
};
if (_dbResult == "OK") then {
	_dbResult = "Arma2NET" callExtension "TAP cargo|selectnext";
	while { (_dbResult != "EOF") && (_dbResult != "ERROR") } do {
		_result pushBack _dbResult;
		_dbResult = "Arma2NET" callExtension "TAP cargo|selectnext";	
	};
};

_result;