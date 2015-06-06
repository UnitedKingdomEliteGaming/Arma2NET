_result = ["MeinTable", "MeineUID"] call fncTapDb_ItemSelect;


if (_result != "ERROR") then {
	_result = call compile _result;
	player setpos _result;
	player globalchat "OK";
}
else
{
	player globalchat "Fehler";
};
