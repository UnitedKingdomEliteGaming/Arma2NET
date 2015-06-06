if (["MeinTable", "MeineUID", format["%1", getpos player]] call fncTapDb_ItemUpdateInsert) then
{
	player globalchat "OK";
} else {
	player globalchat "Fehler";
};
