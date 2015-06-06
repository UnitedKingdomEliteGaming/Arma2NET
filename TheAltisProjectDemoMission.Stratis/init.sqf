if (isServer) then  {
	call compile preprocessFileLineNumbers "TheAltisProjectDb\init.sqf";
	["MeinTable"] call fncTapDb_ItemInit;
};