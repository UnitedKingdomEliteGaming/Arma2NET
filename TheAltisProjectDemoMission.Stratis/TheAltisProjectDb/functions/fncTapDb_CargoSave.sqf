private["_cargoObject"];
_cargoObject = _this select 0;
private["_cargoId"];
_cargoId = _this select 1;

private["_dbResult"];	
_dbResult = "Arma2NET" callExtension format["TAP cargo|deleteall|%1", _cargoId];
if (_dbResult == "OK") then {
player globalchat "OK";

	private["_cargoArray","_cargoType","_classnames","_quantities","_c"];
	_cargoType = "WPN";
	_cargoArray = getWeaponCargo _cargoObject;	
	_classnames = _cargoArray select 0;
	_quantities = _cargoArray select 1;
	_c = (count _classnames) - 1;
	for "_i" from 0 to _c do {
player globalchat format["TAP cargo|insert|%1|%2|[%3,%4]", _cargoId, _cargoType, _classnames select _i, _quantities select _i];
		_dbResult = "Arma2NET" callExtension format["TAP cargo|insert|%1|%2|[""%3"",%4]", _cargoId, _cargoType, _classnames select _i, _quantities select _i];
		if (_dbResult != "OK") then {
			diag_log format["ERROR: Cargo.Insert failed: %1 / %2 [""%3"",%4]", _dbResult, _cargoType, _classnames select _i, _quantities select _i];
		};
	};

	_cargoType = "MAG";
	_cargoArray = getMagazineCargo _cargoObject;	
	_classnames = _cargoArray select 0;
	_quantities = _cargoArray select 1;
	_c = (count _classnames) - 1;
	for "_i" from 0 to _c do {
player globalchat format["TAP cargo|insert|%1|%2|[%3,%4]", _cargoId, _cargoType, _classnames select _i, _quantities select _i];
		_dbResult = "Arma2NET" callExtension format["TAP cargo|insert|%1|%2|[""%3"",%4]", _cargoId, _cargoType, _classnames select _i, _quantities select _i];
		if (_dbResult != "OK") then {
			diag_log format["ERROR: Cargo.Insert failed: %1 / %2 [""%3"",%4]", _dbResult, _cargoType, _classnames select _i, _quantities select _i];
		};
	};

	_cargoType = "ITM";
	_cargoArray = getItemCargo _cargoObject;	
	_classnames = _cargoArray select 0;
	_quantities = _cargoArray select 1;
	_c = (count _classnames) - 1;
	for "_i" from 0 to _c do {
player globalchat format["TAP cargo|insert|%1|%2|[%3,%4]", _cargoId, _cargoType, _classnames select _i, _quantities select _i];
		_dbResult = "Arma2NET" callExtension format["TAP cargo|insert|%1|%2|[""%3"",%4]", _cargoId, _cargoType, _classnames select _i, _quantities select _i];
		if (_dbResult != "OK") then {
			diag_log format["ERROR: Cargo.Insert failed: %1 / %2 [""%3"",%4]", _dbResult, _cargoType, _classnames select _i, _quantities select _i];
		};
	};

	_cargoType = "BKP";
	_cargoArray = getBackpackCargo _cargoObject;	
	_classnames = _cargoArray select 0;
	_quantities = _cargoArray select 1;
	_c = (count _classnames) - 1;
	for "_i" from 0 to _c do {
player globalchat format["TAP cargo|insert|%1|%2|[%3,%4]", _cargoId, _cargoType, _classnames select _i, _quantities select _i];
		_dbResult = "Arma2NET" callExtension format["TAP cargo|insert|%1|%2|[""%3"",%4]", _cargoId, _cargoType, _classnames select _i, _quantities select _i];
		if (_dbResult != "OK") then {
			diag_log format["ERROR: Cargo.Insert failed: %1 / %2 [""%3"",%4]", _dbResult, _cargoType, _classnames select _i, _quantities select _i];
		};
	};	
} else {
	diag_log format["ERROR: Cargo.DeleteAll failed: %1", _dbResult];
};