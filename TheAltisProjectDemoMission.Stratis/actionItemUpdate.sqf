if (["TestTable", getPlayerUid player, format["%1", getpos player]] call fncTapDb_ItemUpdate) then
{
	player globalchat "OK";
} else {
	player globalchat "Fehler";
};
