if (["MeinTable", "MeineUID"] call fncTapDb_ItemDelete) then
{
	player globalchat "OK";
} else {
	player globalchat "Fehler";
};
