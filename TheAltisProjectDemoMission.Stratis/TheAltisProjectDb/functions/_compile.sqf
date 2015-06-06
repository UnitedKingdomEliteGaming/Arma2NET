if (isServer) then  {
	fncTapDb_CargoLoad = compile preprocessFileLineNumbers "TheAltisProjectDb\functions\fncTapDb_CargoLoad.sqf";
	fncTapDb_CargoSave = compile preprocessFileLineNumbers "TheAltisProjectDb\functions\fncTapDb_CargoSave.sqf";
	fncTapDb_ItemInit = compile preprocessFileLineNumbers "TheAltisProjectDb\functions\fncTapDb_ItemInit.sqf";
	fncTapDb_ItemDelete = compile preprocessFileLineNumbers "TheAltisProjectDb\functions\fncTapDb_ItemDelete.sqf";
	fncTapDb_ItemSelect = compile preprocessFileLineNumbers "TheAltisProjectDb\functions\fncTapDb_ItemSelect.sqf";
	fncTapDb_ItemUpdate = compile preprocessFileLineNumbers "TheAltisProjectDb\functions\fncTapDb_ItemUpdate.sqf";
	fncTapDb_ItemUpdateInsert = compile preprocessFileLineNumbers "TheAltisProjectDb\functions\fncTapDb_ItemUpdateInsert.sqf";
};