private["_cargoObject"];
_cargoObject = _this select 0;
private["_cargoId"];
_cargoId = _this select 1;

clearWeaponCargoGlobal _cargoObject;
clearMagazineCargoGlobal _cargoObject;
clearItemCargoGlobal _cargoObject;
clearBackpackCargoGlobal _cargoObject;

private["_dbResult", "_cargoArray","_cargoType"];
_cargoType = "WPN";
_dbResult = "Arma2NET" callExtension format["TAP cargo|select|%1|%2", _cargoId, _cargoType];
if (_dbResult == "OK") then {

	_dbResult = "Arma2NET" callExtension "TAP cargo|selectnext";	
player globalchat _dbResult;
	while { (_dbResult != "EOF") && (_dbResult != "ERROR") } do {
		_cargoArray = call compile _dbResult;
		_cargoObject addWeaponCargoGlobal _cargoArray;
		_dbResult = "Arma2NET" callExtension "TAP cargo|selectnext";	
player globalchat _dbResult;
	};
};

_cargoType = "MAG";
_dbResult = "Arma2NET" callExtension format["TAP cargo|select|%1|%2", _cargoId, _cargoType];
if (_dbResult == "OK") then {

	_dbResult = "Arma2NET" callExtension "TAP cargo|selectnext";	
player globalchat _dbResult;
	while { (_dbResult != "EOF") && (_dbResult != "ERROR") } do {
		_cargoArray = call compile _dbResult;
		_cargoObject addMagazineCargoGlobal _cargoArray;
		_dbResult = "Arma2NET" callExtension "TAP cargo|selectnext";	
player globalchat _dbResult;
	};
};

_cargoType = "ITM";
_dbResult = "Arma2NET" callExtension format["TAP cargo|select|%1|%2", _cargoId, _cargoType];
if (_dbResult == "OK") then {

	_dbResult = "Arma2NET" callExtension "TAP cargo|selectnext";	
player globalchat _dbResult;
	while { (_dbResult != "EOF") && (_dbResult != "ERROR") } do {
		_cargoArray = call compile _dbResult;
		_cargoObject addItemCargoGlobal _cargoArray;
		_dbResult = "Arma2NET" callExtension "TAP cargo|selectnext";	
player globalchat _dbResult;
	};
};

_cargoType = "BKP";
_dbResult = "Arma2NET" callExtension format["TAP cargo|select|%1|%2", _cargoId, _cargoType];
if (_dbResult == "OK") then {

	_dbResult = "Arma2NET" callExtension "TAP cargo|selectnext";	
player globalchat _dbResult;
	while { (_dbResult != "EOF") && (_dbResult != "ERROR") } do {
		_cargoArray = call compile _dbResult;
		_cargoObject addBackpackCargoGlobal _cargoArray;
		_dbResult = "Arma2NET" callExtension "TAP cargo|selectnext";	
player globalchat _dbResult;
	};
};