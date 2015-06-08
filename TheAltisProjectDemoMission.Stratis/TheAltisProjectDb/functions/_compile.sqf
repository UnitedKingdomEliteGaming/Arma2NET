if (isServer) then  {
	fncTapDb_CargoInit = compile preprocessFileLineNumbers "TheAltisProjectDb\functions\fncTapDb_CargoInit.sqf";
	fncTapDb_CargoLoad = compile preprocessFileLineNumbers "TheAltisProjectDb\functions\fncTapDb_CargoLoad.sqf";
	fncTapDb_CargoSave = compile preprocessFileLineNumbers "TheAltisProjectDb\functions\fncTapDb_CargoSave.sqf";
	fncTapDb_CargoSelectIds = compile preprocessFileLineNumbers "TheAltisProjectDb\functions\fncTapDb_CargoSelectIds.sqf";
	fncTapDb_ItemInit = compile preprocessFileLineNumbers "TheAltisProjectDb\functions\fncTapDb_ItemInit.sqf";
	fncTapDb_ItemDelete = compile preprocessFileLineNumbers "TheAltisProjectDb\functions\fncTapDb_ItemDelete.sqf";
	fncTapDb_ItemSelect = compile preprocessFileLineNumbers "TheAltisProjectDb\functions\fncTapDb_ItemSelect.sqf";
	fncTapDb_ItemSelectIds = compile preprocessFileLineNumbers "TheAltisProjectDb\functions\fncTapDb_ItemSelectIds.sqf";
	fncTapDb_ItemUpdate = compile preprocessFileLineNumbers "TheAltisProjectDb\functions\fncTapDb_ItemUpdate.sqf";
	fncTapDb_ItemUpdateInsert = compile preprocessFileLineNumbers "TheAltisProjectDb\functions\fncTapDb_ItemUpdateInsert.sqf";
};