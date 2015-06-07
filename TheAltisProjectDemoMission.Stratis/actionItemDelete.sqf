if (["TestTable", getPlayerUid player] call fncTapDb_ItemDelete) then
{
	player globalchat "OK";
} else {
	player globalchat "Fehler";
};
